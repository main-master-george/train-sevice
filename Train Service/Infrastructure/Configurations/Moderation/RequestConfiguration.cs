using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModerationModule.Domain;

namespace Infrastructure.Configurations.Moderation;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(r => r.CourseId)
            .IsRequired();

        builder
            .Property(r => r.Status)
            .HasConversion<string>()
            .IsRequired();
    }
}