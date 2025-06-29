using CourseCompletionModule.Domain;
using CourseManagementModule.Domain;
using Infrastructure.Configurations.CourseCompletion;
using Infrastructure.Configurations.CourseManagement;
using Infrastructure.Configurations.Moderation;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModerationModule.Domain;

namespace Infrastructure;

public class ApplicationDbContext : IdentityDbContext<UserModel>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<Course> Courses { get; set; }
    
    public DbSet<Module> Modules { get; set; }
    
    public DbSet<Page> Pages { get; set; }
    
    public DbSet<Test> Tests { get; set; }
    
    public DbSet<TestPoint> TestPoints { get; set; }
    
    public DbSet<Text> Texts { get; set; }

    public DbSet<UserCourse> UserCourses { get; set; }
    
    public DbSet<UserModule> UserModules { get; set; }
    
    public DbSet<UserTest> UserTests { get; set; }
    
    public DbSet<Request> Requests { get; set; }
    
    public DbSet<Response> Responses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new ModuleConfiguration());
        modelBuilder.ApplyConfiguration(new PageConfiguration());
        modelBuilder.ApplyConfiguration(new TestConfiguration());
        modelBuilder.ApplyConfiguration(new TestPointConfiguration());
        modelBuilder.ApplyConfiguration(new TextConfiguration());

        modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
        modelBuilder.ApplyConfiguration(new UserModuleConfiguration());
        modelBuilder.ApplyConfiguration(new UserTestConfiguration());

        modelBuilder.ApplyConfiguration(new RequestConfiguration());
        modelBuilder.ApplyConfiguration(new ResponseConfiguration());
    }
}