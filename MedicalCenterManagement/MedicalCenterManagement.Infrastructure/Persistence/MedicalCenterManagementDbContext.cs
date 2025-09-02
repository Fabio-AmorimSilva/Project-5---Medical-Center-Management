namespace MedicalCenterManagement.Infrastructure.Persistence;

public class MedicalCenterManagementDbContext : DbContext, IMedicalCenterManagementDbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalCare> MedicalCares { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteEntityInterceptor());
        base.OnConfiguring(optionsBuilder);
    }    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}