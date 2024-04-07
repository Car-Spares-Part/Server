using Microsoft.EntityFrameworkCore;

namespace ServerApplication;

public class DatabaseContext: DbContext
{
    public const string ConnectionString = "DatabaseContextDb";
    public const string Schema = "main";
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(entityType => entityType.GetProperties()).Where(property =>
                         property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?)))
        {
            property.SetColumnType($"decimal(12,3)");
        }
    }
}