using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseManagement;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(c => c.Name)
            .IsRequired();

        builder
            .Property(c => c.Description)
            .IsRequired();

        builder
            .Property(c => c.IsVisibleForUsers)
            .IsRequired();
    }
}