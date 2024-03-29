﻿using System.Text;
using Domain.Helpers;
using Domain.States.BacklogItem;

namespace Domain.Entities
{
    public class Thread
    {
        private Guid _id { get; init; }
        public Guid Id { get => _id; init => _id = value; }

        private string _subject { get; set; }

        public string Subject
        {
            get => _subject;
            set
            {
                if (ValidateUpdate())
                {
                    _subject = value;
                    Logger.DisplayUpdatedAlert(nameof(Subject), _subject);
                }
            }
        }

        private string _description { get; set; }

        public string Description
        {
            get => _description; 
            set
            {
                if (ValidateUpdate())
                {
                    _description = value;
                    Logger.DisplayUpdatedAlert(nameof(Description), _description);
                }
            }
        }

        private Item _item { get; init; }
        public Item Item { get => _item; init => _item = value; }

        private IList<ThreadMessage> _threadMessages { get; init; }
        public IList<ThreadMessage> ThreadMessages { get => _threadMessages; init => _threadMessages = value; }

        public Thread(string title, string body, Item item)
        {
            _id = Guid.NewGuid();
            _subject = title;
            _description = body;
            _item = item;
            _threadMessages = new List<ThreadMessage>();
            
            Logger.DisplayCreatedAlert(nameof(Thread), _subject);
        }
        
        public void AddThreadMessage(ThreadMessage threadMessage)
        {
            if (_item.CurrentStatus.GetType() != typeof(ClosedState))
            {
                _threadMessages.Add(threadMessage);

                Logger.DisplayAddedAlert(nameof(ThreadMessages), threadMessage.Title);
                
                Notification notification = new("New message in thread", $"New message has been posted in thread: {_subject}!");

                var developers = _item.SprintBacklog?.Sprint.Developers;
                var scrumMaster = _item.SprintBacklog!.Sprint.ScrumMaster;

                if (developers?.Count is not 0)
                {
                    if (!developers!.Contains(scrumMaster))
                    {
                        developers.Add(scrumMaster);
                    }

                    foreach (var developer in developers)
                    {
                        notification.AddTargetUser(developer);
                    }

                    _item.SprintBacklog!.Sprint.NotifyObservers(notification);
                }
            } 
            else
            {
                Logger.DisplayCustomAlert(nameof(Thread), nameof(AddThreadMessage), "Can't add thread message when item status is closed!");
            }
        }
    
        public void RemoveThreadMessage(ThreadMessage threadMessage)
        {
            if (_item.CurrentStatus.GetType() != typeof(ClosedState))
            {
                _threadMessages.Remove(threadMessage);

                Logger.DisplayRemovedAlert(nameof(ThreadMessages), threadMessage.Title);
            }
            else
            {
                Logger.DisplayCustomAlert(nameof(Thread), nameof(AddThreadMessage), "Can't remove thread message when item status is closed!");
            }
        }

        private bool ValidateUpdate()
        {
            if (_item.CurrentStatus.GetType() == typeof(ClosedState))
            {
                Logger.DisplayCustomAlert(nameof(Thread), nameof(ValidateUpdate), "Can't update thread when item status is closed!");
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Id: {_id}");
            sb.AppendLine($"Subject: {_subject}");
            sb.AppendLine($"Description: {_description}");
            sb.AppendLine($"ThreadMessages: {_threadMessages.Count}");

            foreach (var threadMessage in _threadMessages)
            {
                sb.AppendLine(threadMessage.ToString());
            }

            return sb.ToString();
        }
    }
}
