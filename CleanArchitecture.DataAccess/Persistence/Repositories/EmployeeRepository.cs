using CleanArchitecture.DataAccess.Core.Entities;
using CleanArchitecture.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Add(employee);

            
        }

        public IQueryable<Employee> Get()
        {
            return _context.Employees; ;
        }


        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var employee = GetById(id);

            if (employee == null)
                throw new Exception("Employee not found");

            _context.Employees.Remove(employee);
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Employees.Find(id);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
