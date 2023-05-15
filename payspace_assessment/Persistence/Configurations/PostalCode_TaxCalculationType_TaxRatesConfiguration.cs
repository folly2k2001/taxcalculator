using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class PostalCode_TaxCalculationType_TaxRatesConfiguration : IEntityTypeConfiguration<PostalCode_TaxCalculationType_TaxRates>
    {
        public void Configure(EntityTypeBuilder<PostalCode_TaxCalculationType_TaxRates> builder)
        {
            builder.HasData(
                new PostalCode_TaxCalculationType_TaxRates
                {
                    Id = 1,
                    PostalCode_TaxCalculationTypeId = 1,
                    TaxRateId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 2,
                     PostalCode_TaxCalculationTypeId = 1,
                     TaxRateId = 2,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 3,
                     PostalCode_TaxCalculationTypeId = 1,
                     TaxRateId = 3,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 }, 
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 4,
                     PostalCode_TaxCalculationTypeId = 1,
                     TaxRateId = 4,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 5,
                     PostalCode_TaxCalculationTypeId = 1,
                     TaxRateId = 5,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 6,
                     PostalCode_TaxCalculationTypeId = 1,
                     TaxRateId = 6,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 }
                 ,
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 7,
                     PostalCode_TaxCalculationTypeId = 2,
                     TaxRateId = 7,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 8,
                     PostalCode_TaxCalculationTypeId = 2,
                     TaxRateId = 8,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 },
                 new PostalCode_TaxCalculationType_TaxRates
                 {
                     Id = 9,
                     PostalCode_TaxCalculationTypeId = 3,
                     TaxRateId = 9,
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now
                 }
            );

            builder.Property(q => q.PostalCode_TaxCalculationTypeId)
               .IsRequired();
            builder.Property(q => q.TaxRateId)
               .IsRequired();
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd();
        }
    }
}
