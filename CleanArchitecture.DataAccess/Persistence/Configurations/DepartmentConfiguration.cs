using CleanArchitecture.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence.Configurations
{
    public class DepartmentConfiguration :EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            //Properties

            Property(d => d.ID)
                .IsRequired();

            Property(d => d.Name)
                .HasMaxLength(255)
                .IsRequired();

            //Relationships

            HasMany(d => d.Employees)
                .WithRequired(e => e.Department);
        
        }
    }
}
