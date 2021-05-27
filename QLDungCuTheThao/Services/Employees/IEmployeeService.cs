using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Employees
{
    public interface IEmployeeService : ICrudService<Employee>
    {
        IQueryable<Employee> GetAll();
    }
}
