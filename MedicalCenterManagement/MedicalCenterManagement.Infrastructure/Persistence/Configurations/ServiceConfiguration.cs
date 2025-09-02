namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder
            .ToTable("Services");
        
        builder
            .HasKey(s => s.Id);

        builder
            .HasIndex(s => s.Id);
    
        builder
            .Property(s => s.Name)
            .HasMaxLength(Patient.NameMaxLength)
            .IsRequired();
        
        builder
            .Property(s => s.Description)
            .HasMaxLength(Service.DescriptionMaxLength)
            .IsRequired();

        builder
            .Property(s => s.Price)
            .IsRequired();

        builder
            .Property(s => s.Period)
            .IsRequired();
        
        builder
            .Property(s => s.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}