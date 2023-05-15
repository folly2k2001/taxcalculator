using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CalculatedTaxConfiguration : IEntityTypeConfiguration<CalculatedTax>
    {
        public void Configure(EntityTypeBuilder<CalculatedTax> builder)
        {
            builder.Property(q => q.Id)
               .ValueGeneratedOnAdd();
            builder.HasKey(q => q.Id);
        }
    }
}
