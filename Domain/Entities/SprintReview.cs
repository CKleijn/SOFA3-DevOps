﻿using System.Text;
using Domain.Helpers;
using Domain.States.Sprint;

namespace Domain.Entities;

public class SprintReview : Sprint
{
    private IList<Review> _reviews { get; init; }
    public IList<Review> Reviews { get => _reviews; init => _reviews = value; }
    
    public SprintReview(string title, DateTime startDate, DateTime endDate, Developer scrumMaster, Project project) : base(title, startDate, endDate, scrumMaster, project)
    {
        _reviews = new List<Review>();
        Logger.DisplayCreatedAlert(nameof(SprintReview), Title);
    }
    
    public void AddReview(Review review)
    {
        if (CurrentStatus.GetType() != typeof(ReviewState))
        {
            return;
        }

        _reviews.Add(review);
        Logger.DisplayAddedAlert(nameof(Reviews), review.Title);
    }
    
    public void RemoveReview(Review review)
    {
        if (CurrentStatus.GetType() != typeof(ReviewState))
        {
            return;
        }

        _reviews.Remove(review);
        Logger.DisplayRemovedAlert(nameof(Reviews), review.Title);
    }

    protected override bool ValidateChange()
    {
        //Don't allow mutation whenever sprint's state differs from the initial state
        if (CurrentStatus.GetType() != typeof(InitialState))
        {
            Logger.DisplayCustomAlert(nameof(Sprint), nameof(ValidateChange), $"Can't update sprint in current state ({CurrentStatus.GetType()})!");
            
            return false;
        }
        
        //Don't allow mutation whenever pipeline's state differs from the initial state
        if (Pipeline?.CurrentStatus.GetType() != typeof(States.Pipeline.InitialState))
        {
            Logger.DisplayCustomAlert(nameof(Sprint), nameof(ValidateChange), $"Can't update sprint when it's corresponding pipeline isn't in its initial state ({Pipeline?.CurrentStatus.GetType()})!");
            
            return false;
        }
        
        //Perform actions alteration is done on a sprint that has already ended
        if (EndDate < DateTime.Now)
        {
            
            //Set sprint to finished state if it isn't already
            if(CurrentStatus.GetType() != typeof(FinishedState))
            {
                CurrentStatus = new FinishedState(this);
            }

            Logger.DisplayCustomAlert(nameof(SprintReview), nameof(ValidateChange), $"Can't update sprint after end date. Sprint will be set to finished and corresponding actions will be performed!");
    
            //Check if sprint input is valid
            ReviewSprint();
            
            //Review sprint 
            if (CurrentStatus.GetType() == typeof(ReviewState))
            {
                ReviewSprint();
            }
            
            return false;
        }
        
        return true;
    }

    public override string ToString()
    {
        base.ToString();

        StringBuilder sb = new();

        sb.AppendLine($"Reviews: {Reviews.Count}");

        foreach (var review in Reviews)
        {
            sb.AppendLine(review.ToString());
        }

        return sb.ToString();
    }
}
