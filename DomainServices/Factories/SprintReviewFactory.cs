﻿using Domain.Entities;
using DomainServices.Interfaces;

namespace DomainServices.Factories;

public class SprintReviewFactory : ISprintFactory
{
    public Sprint CreateSprint(string title, DateTime startDate, DateTime endDate, User createdBy, User scrumMaster)
    {
        return new SprintReview(title, startDate, endDate, createdBy, scrumMaster);
    }
}