using CleanArchitecture.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecture.MVC.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Department> Departments { get; set; }

        public Employee Employee { get; set; }

    }
}