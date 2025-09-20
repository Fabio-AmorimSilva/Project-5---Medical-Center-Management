namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(u => u.Id);

        builder
            .HasIndex(u => u.Email);

        builder
            .Property(u => u.Email)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .IsRequired();
    }
}