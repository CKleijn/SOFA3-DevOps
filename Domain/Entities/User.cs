﻿using System.Text;

namespace Domain.Entities;

public abstract class User
{
    private Guid _id { get; init; }
    public Guid Id { get => _id; init => _id = value; }
    
    private string _name { get; set; }
    public string Name { get => _name; set => _name = value; }
    
    private string _email { get; set; }
    public string Email { get => _email; set => _email = value; }
    
    private string _password { get; set; }
    public string Password { get => _password; set => _password = value; }
    
    private DateTime? _updatedAt { get; set; }
    public DateTime? UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
    
    private DateTime _createdAt { get; init; }
    public DateTime CreatedAt { get => _createdAt; init => _createdAt = value;}

    public User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = DateTime.Now;
    }
    
    //TODO: implement functions (Update observers, etc)

    public override string ToString()
    {
        StringBuilder sb = new();
        
        sb.AppendLine($"Id: {_id}");
        sb.AppendLine($"Name: {_name}");
        sb.AppendLine($"Email: {_email}");
        sb.AppendLine($"UpdatedAt: {_updatedAt}");
        sb.AppendLine($"CreatedAt: {_createdAt}");
        
        return sb.ToString();
    }
}