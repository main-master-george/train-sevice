using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseManagement;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
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
            .Property(t => t.Text)
            .IsRequired();

        builder
            .Property(t => t.Number)
            .IsRequired();

        builder
            .Property(t => t.Value)
            .IsRequired();
    }
}