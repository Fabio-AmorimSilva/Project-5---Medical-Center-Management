﻿namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class MedicalCareConfiguration : IEntityTypeConfiguration<MedicalCare>
{
    public void Configure(EntityTypeBuilder<MedicalCare> builder)
    {
        builder
            .ToTable("MedicalCares");

        builder
            .HasKey(mc => mc.Id);

        builder
            .HasIndex(mc => mc.Id);

        builder
            .Property(mc => mc.Insurance)
            .IsRequired();

        builder
            .Property(mc => mc.Start)
            .IsRequired();

        builder
            .Property(mc => mc.End)
            .IsRequired();

        builder
            .Property(mc => mc.TypeOfService)
            .IsRequired();

        builder
            .Property(mc => mc.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();

        builder
            .HasOne(mc => mc.Doctor)
            .WithMany()
            .HasForeignKey(mc => mc.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(mc => mc.Patient)
            .WithMany()
            .HasForeignKey(mc => mc.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(mc => mc.Service)
            .WithMany()
            .HasForeignKey(mc => mc.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}