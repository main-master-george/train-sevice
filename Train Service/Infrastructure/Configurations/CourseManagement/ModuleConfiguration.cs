using CourseManagementModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.CourseManagement;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(m => m.CourseId)
            .IsRequired();

        builder
            .Property(m => m.Header)
            .IsRequired();

        builder
            .Property(m => m.Description)
            .IsRequired();

        builder
            .Property(m => m.Number)
            .IsRequired();
    }
}