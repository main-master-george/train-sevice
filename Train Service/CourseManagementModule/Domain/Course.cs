﻿namespace CourseManagementModule.Domain;

public class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool IsVisibleForUsers { get; set; }
}