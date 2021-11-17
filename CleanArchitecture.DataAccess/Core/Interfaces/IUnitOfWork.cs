using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DataAccess.Core.Interfaces
{
    public interface IUnitOfWork  :IDisposable
    {
        IDepartmentRepository Departments { get; }

        IEmployeeRepository Employees { get; }

        void Complete();
    }
}
