namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .ToTable("Patients");
        
        builder
            .Property(p => p.Height)
            .HasPrecision(4, 2)
            .IsRequired();

        builder
            .Property(p => p.Weight)
            .HasPrecision(6, 2)
            .IsRequired();
    }
}