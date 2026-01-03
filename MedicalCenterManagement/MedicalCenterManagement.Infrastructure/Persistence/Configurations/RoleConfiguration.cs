namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("Roles");
        
        builder
            .HasKey(r => r.Id);

        builder
            .HasIndex(r => r.Name);
        
        builder
            .Property(r => r.Name)
            .IsRequired();
    }
}