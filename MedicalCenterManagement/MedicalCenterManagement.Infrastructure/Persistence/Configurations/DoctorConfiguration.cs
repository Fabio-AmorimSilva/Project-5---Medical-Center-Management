﻿namespace MedicalCenterManagement.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .ToTable("Doctors");

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
            .HasOne(d => d.User)
            .WithOne(d => d.Doctor)
            .HasForeignKey<Doctor>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}