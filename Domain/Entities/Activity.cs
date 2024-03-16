﻿using System.Text;

namespace Domain.Entities
{
    public class Activity
    {
        private Guid _id {  get; init; }
        public Guid Id { get => _id; init => _id = value; }

        private string _title { get; set; }
        public string Title { get => _title; set => _title = value; }

        private bool _isFinished { get; set; }
        public bool IsFinished { get => _isFinished; set => _isFinished = value; }

        private Developer _developer { get; set; }
        public Developer Developer { get => _developer; set => _developer = value; }

        private User _creator { get; init; }
        public User Creator { get => _creator; init => _creator = value; }

        private DateTime? _updatedAt { get; set; }
        public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }

        private DateTime _createdAt { get; init; }
        public DateTime CreatedAt { get => _createdAt; init => _createdAt = value; }

        public Activity(string title, Developer developer, User creator)
        {
            _id = Guid.NewGuid();
            _title = title;
            _isFinished = false;
            _developer = developer;
            _creator = creator;
            _createdAt = DateTime.Now;
        }

        //TODO: implement functions
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Id: {_id}");
            sb.AppendLine($"Title: {_title}");
            sb.AppendLine($"IsFinished: {_isFinished}");
            sb.AppendLine($"Developer: {_developer.ToString()}");
            sb.AppendLine($"Creator: {_creator.ToString()}");
            sb.AppendLine($"UpdatedAt: {_updatedAt}");
            sb.AppendLine($"CreatedAt: {_createdAt}");

            return sb.ToString();
        }
    }
}