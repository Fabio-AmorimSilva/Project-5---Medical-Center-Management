﻿namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface IMedicalCenterManagementDbContext
{
    DbSet<Person> Persons { get; set; }
    DbSet<Doctor> Doctors { get; set; }
    DbSet<Patient> Patients { get; set; }
    DbSet<MedicalCare> MedicalCares { get; set; }
    DbSet<Service> Services { get; set; }
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}