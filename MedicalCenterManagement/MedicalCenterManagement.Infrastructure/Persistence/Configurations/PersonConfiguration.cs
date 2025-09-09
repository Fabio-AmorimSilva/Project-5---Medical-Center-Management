namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .ToTable("Persons");

        builder
            .HasKey(p => p.Id);

        builder
            .HasIndex(p => new { p.Id });

        builder
            .Property(p => p.Name)
            .HasMaxLength(Person.NameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.LastName)
            .HasMaxLength(Person.LastNameMaxLength)
            .IsRequired();

        builder
            .Property(p => p.Birth)
            .HasPrecision(3)
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
            .Property(p => p.DeletedAt)
            .HasPrecision(3);
        
        builder
            .OwnsOne(p => p.Address, addressBuilder =>
            {
                addressBuilder
                    .Property(ad => ad.PublicArea)
                    .IsRequired();

                addressBuilder
                    .Property(ad => ad.City)
                    .IsRequired();

                addressBuilder
                    .Property(ad => ad.State)
                    .IsRequired();

                addressBuilder
                    .Property(ad => ad.Country)
                    .IsRequired();

                addressBuilder
                    .Property(ad => ad.ZipCode)
                    .IsRequired();
            });
    }
}