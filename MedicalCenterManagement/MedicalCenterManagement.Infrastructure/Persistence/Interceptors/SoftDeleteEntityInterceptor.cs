namespace MedicalCenterManagement.Infrastructure.Persistence.Interceptors;

public class SoftDeleteEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result
    )
    {
        AuditSoftDeleteInfo(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new()
    )
    {
        AuditSoftDeleteInfo(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void AuditSoftDeleteInfo(DbContext? context)
    {
        if (context is null)
            return;

        var entities = context.ChangeTracker
            .Entries<IHasIsDeleted>()
            .Where(e => e.State == EntityState.Deleted);

        foreach (var entity in entities)
        {
            entity.State = EntityState.Modified;
            entity.Entity.IsDeleted = true;
            entity.Entity.DeletedAt = DateTime.Now;
        }
    }
}