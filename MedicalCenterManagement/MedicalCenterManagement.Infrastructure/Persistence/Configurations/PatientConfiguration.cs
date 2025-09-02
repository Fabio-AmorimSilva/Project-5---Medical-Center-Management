namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .ToTable("Patients");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(Patient.NameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasMaxLength(Patient.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Birth)
            .IsRequired();

        builder
            .Property(p => p.PhoneNumber)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .IsRequired();

        builder
            .Property(p => p.Cpf)
            .IsRequired();

        builder
            .Property(p => p.BloodType)
            .IsRequired();

        builder
            .Property(p => p.Height)
            .IsRequired();

        builder
            .Property(p => p.Weight)
            .IsRequired();

        builder
            .Property(p => p.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .OwnsOne(p => p.Address, addressBuilder =>
            {
                addressBuilder
                    .Property(add => add.PublicArea)
                    .IsRequired();

                addressBuilder
                    .Property(add => add.City)
                    .IsRequired();

                addressBuilder
                    .Property(add => add.State)
                    .IsRequired();

                addressBuilder
                    .Property(add => add.Country)
                    .IsRequired();

                addressBuilder
                    .Property(add => add.ZipCode)
                    .IsRequired();
            });
    }
}