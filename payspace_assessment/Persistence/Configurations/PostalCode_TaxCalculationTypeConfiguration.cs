using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class PostalCode_TaxCalculationTypeConfiguration : IEntityTypeConfiguration<PostalCode_TaxCalculationType>
    {
        public void Configure(EntityTypeBuilder<PostalCode_TaxCalculationType> builder)
        {
            builder.HasData
                (
                    new PostalCode_TaxCalculationType
                    {
                        Id = 1,
                        PostalCodeId = 1,
                        TaxCalculationTypeId = 1,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    }, 
                    new PostalCode_TaxCalculationType
                    {
                        Id = 2,
                        PostalCodeId = 2,
                        TaxCalculationTypeId = 2,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                    new PostalCode_TaxCalculationType
                    {
                        Id = 3,
                        PostalCodeId = 3,
                        TaxCalculationTypeId = 3,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    },
                    new PostalCode_TaxCalculationType
                    {
                        Id = 4,
                        PostalCodeId = 4,
                        TaxCalculationTypeId = 1,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    }


                );
            builder.Property(q => q.TaxCalculationTypeId)
             .IsRequired();
            builder.Property(q => q.PostalCodeId)
               .IsRequired();
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd();
            builder.HasKey(q => new {q.Id, q.TaxCalculationTypeId, q.PostalCodeId});
            builder.HasOne(q => q.PostalCode).WithMany(q => q.PostalCode_TaxCalculationTypes).HasForeignKey(q => q.PostalCodeId);
            builder.HasOne(q => q.TaxCalculationType).WithMany(q => q.PostalCode_TaxCalculationTypes).HasForeignKey(q => q.TaxCalculationTypeId);


        }
    }
}
