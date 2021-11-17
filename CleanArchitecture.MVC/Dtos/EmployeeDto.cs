using CleanArchitecture.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CleanArchitecture.MVC.Dtos
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int DepId { get; set; }
        public double Salary { get; set; }

        public DateTime HireDate { get; set; }
    }
}