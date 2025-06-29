using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseManagement;

public class TestPointConfiguration : IEntityTypeConfiguration<TestPoint>
{
    public void Configure(EntityTypeBuilder<TestPoint> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.TestId)
            .IsRequired();

        builder
            .Property(p => p.Text)
            .IsRequired();

        builder
            .Property(p => p.IsValid)
            .IsRequired();
    }
}