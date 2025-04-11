using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Models;

namespace Repository.Interface
{
   public interface IEmployeeRepo
    {
        bool CreateEmployee(EmployeeMaster employee);

        EmployeeMaster GetEmployeeById(string id);

        IEnumerable<EmployeeView> EmployeeList();

        bool DeleteEmployee(string ID);

        bool UpdateEmployee(EmployeeMaster employee);

    
    }
}
