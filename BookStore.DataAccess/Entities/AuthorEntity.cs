﻿namespace BookStore.DataAccess.Entities;

public class AuthorEntity
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Name { get; set; } = string.Empty;

    public List<AuthorBookEntity> AuthorBooks { get; set; } = new();
}