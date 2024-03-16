﻿using System.Text;

namespace Domain.Entities;

public class Project
{
    private Guid _id { get; init; }
    public Guid Id { get => _id; init => _id = value; }
    
    private string _title { get; set; }
    public string Title { get => _title; set => _title = value; }
    
    private string _description { get; set; }
    public string Description { get => _description; set => _description = value; }
    
    private ProductOwner _productOwner { get; init; }
    public ProductOwner ProductOwner { get => _productOwner; init => _productOwner = value;}

    private ProjectBacklog _backlog { get; init; }
    public ProjectBacklog Backlog { get => _backlog; init => _backlog = value; }
    
    private User _createdBy { get; init; }
    public User CreatedBy { get => _createdBy; init => _createdBy = value;}
    
    private DateTime? _updatedAt { get; set; }
    public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
    
    private DateTime _createdAt { get; init; }
    public DateTime CreatedAt { get => _createdAt; init => _createdAt = value;}
    
    //TODO: implement Pipeline and VersionControl

    public Project(string title, string description, ProductOwner productOwner, User createdBy)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ProductOwner = productOwner;
        Backlog = new ProjectBacklog();
        CreatedBy = createdBy;
        CreatedAt = DateTime.Now;
    }

    //TODO: implement functions
    public override string ToString()
    {
        StringBuilder sb = new();
        
        sb.AppendLine($"Id: {_id}");
        sb.AppendLine($"Title: {_title}");
        sb.AppendLine($"Description: {_description}");
        sb.AppendLine($"ProductOwner: {_productOwner.ToString()}");
        sb.AppendLine($"Backlog: {_backlog.ToString()}");
        sb.AppendLine($"CreatedBy: {_createdBy.ToString()}");
        sb.AppendLine($"UpdatedAt: {_updatedAt}");
        sb.AppendLine($"CreatedAt: {_createdAt}");

        return sb.ToString();
    }
}