using CleanArchitecture.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {

        public EmployeeConfiguration()
        {
            //Properties
            
            Property(e=>e.ID)
                .IsRequired();

            Property(e=>e.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            Property(e=>e.LastName)
                .HasMaxLength(255)
                .IsRequired();

            Property(e=> e.DepId)
                .IsRequired();

            Property(e=>e.HireDate)
                .IsRequired();

            Property(e => e.Salary)
                .IsRequired();

            //Relationships

            HasRequired(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepId);

        }
    }
}
