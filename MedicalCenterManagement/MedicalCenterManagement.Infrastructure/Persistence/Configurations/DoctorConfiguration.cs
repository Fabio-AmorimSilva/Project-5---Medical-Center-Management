namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .ToTable("Doctors");

        builder
            .HasKey(d => d.Id);

        builder
            .HasIndex(d => new { d.Id, d.Crm });

        builder
            .Property(d => d.Name)
            .HasMaxLength(Doctor.NameMaxLength)
            .IsRequired();

        builder
            .Property(d => d.LastName)
            .HasMaxLength(Doctor.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(d => d.Birth)
            .IsRequired();

        builder
            .Property(d => d.PhoneNumber)
            .IsRequired();

        builder
            .Property(d => d.Email)
            .IsRequired();

        builder
            .Property(d => d.Cpf)
            .IsRequired();

        builder
            .Property(d => d.BloodType)
            .IsRequired();

        builder
            .Property(d => d.Speciality)
            .IsRequired();

        builder
            .Property(d => d.Crm)
            .IsRequired();

        builder
            .Property(d => d.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .OwnsOne(d => d.Address, addressBuilder =>
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