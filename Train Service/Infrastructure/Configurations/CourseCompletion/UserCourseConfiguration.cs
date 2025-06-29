using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseCompletion;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        builder
            .HasKey(uc => new {uc.UserId, uc.CourseId});

        builder
            .Property(uc => uc.UserId)
            .IsRequired();

        builder
            .Property(uc => uc.CourseId)
            .IsRequired();

        builder
            .Property(uc => uc.StartDateTime)
            .IsRequired();
    }
}