using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Core.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepId { get; set; }

        public double Salary { get; set; }

        public DateTime HireDate { get; set; }

        public Department Department { get; set; }

    }
}
