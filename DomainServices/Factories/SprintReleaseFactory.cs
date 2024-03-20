﻿using Domain.Entities;
using Domain.Helpers;
using DomainServices.Interfaces;

namespace DomainServices.Factories;

public class SprintReleaseFactory : ISprintFactory<SprintRelease>
{
    public SprintRelease CreateSprint(string title, DateTime startDate, DateTime endDate, Developer scrumMaster, Project project)
    {
        return new SprintRelease(title, startDate, endDate, scrumMaster, project);
    }
}