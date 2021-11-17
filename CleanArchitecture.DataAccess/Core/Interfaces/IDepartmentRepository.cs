using CleanArchitecture.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Core.Interfaces
{
    public interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetAll();
    }
}
