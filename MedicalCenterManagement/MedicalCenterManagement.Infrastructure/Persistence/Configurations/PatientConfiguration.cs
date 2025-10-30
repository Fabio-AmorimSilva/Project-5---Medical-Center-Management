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
        
        builder.OwnsMany(p => p.Attachments, attachmentBuilder =>
        {
            attachmentBuilder
                .Property<Guid>("Id")
                .ValueGeneratedOnAdd();
            
            attachmentBuilder
                .Property(att => att.Name)
                .IsRequired();
            
            attachmentBuilder
                .Property(att => att.ContentType)
                .IsRequired();
            
            attachmentBuilder
                .Property(att => att.Size)
                .IsRequired();
            
            attachmentBuilder
                .Property(att => att.Type)
                .IsRequired();
        });
        
        builder
            .HasOne(p => p.User)
            .WithOne(u => u.Patient)
            .HasForeignKey<Patient>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}