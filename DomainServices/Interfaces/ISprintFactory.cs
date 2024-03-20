﻿using Domain.Entities;

namespace DomainServices.Interfaces;

public interface ISprintFactory<T> where T : Sprint
{
    public T CreateSprint(string title, DateTime startDate, DateTime endDate, Developer scrumMaster, Project project);
}