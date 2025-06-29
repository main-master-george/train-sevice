using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModerationModule.Domain;

namespace Infrastructure.Configurations.Moderation;

public class ResponseConfiguration : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(r => r.RequestId)
            .IsRequired();

        builder
            .Property(r => r.Message)
            .IsRequired();
    }
}