using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseManagement;

public class TextConfiguration : IEntityTypeConfiguration<Text>
{
    public void Configure(EntityTypeBuilder<Text> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(t => t.PageId)
            .IsRequired();

        builder
            .Property(t => t.Data)
            .IsRequired();

        builder
            .Property(t => t.Number)
            .IsRequired();
    }
}