using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DatabaseContext
{
    public class TaxCalculationDbContext : DbContext
    {
        public TaxCalculationDbContext(DbContextOptions<TaxCalculationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<CalculatedTax> CalculatedTaxes { get; set; }
        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<PostalCode_TaxCalculationType> PostalCode_TaxCalculationType { get; set; }
        public virtual DbSet<TaxCalculationType> TaxCalculationType { get; set; }
        public virtual DbSet<TaxRate> TaxRates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxCalculationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
               .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
