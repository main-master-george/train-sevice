using CourseCompletionModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseCompletion;

public class UserModuleConfiguration : IEntityTypeConfiguration<UserModule>
{
    public void Configure(EntityTypeBuilder<UserModule> builder)
    {
        builder
            .HasKey(um => new {um.UserId, um.ModuleId});

        builder
            .Property(um => um.UserId)
            .IsRequired();

        builder
            .Property(um => um.ModuleId)
            .IsRequired();

        builder
            .Property(um => um.IsOpen)
            .IsRequired();
    }
}