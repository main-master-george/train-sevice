using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseCompletion;

public class UserTestConfiguration : IEntityTypeConfiguration<UserTest>
{
    public void Configure(EntityTypeBuilder<UserTest> builder)
    {
        builder
            .HasKey(ut => new {ut.UserId, ut.TestId});

        builder
            .Property(ut => ut.TestId)
            .IsRequired();

        builder
            .Property(ut => ut.UserId)
            .IsRequired();
    }
}