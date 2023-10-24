using MiniStoreManagement.DAO;
using MiniStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.BUS
{
    internal class EmployeeBUS
    {
        private static EmployeeDAO EmployeeDAO = new EmployeeDAO();
        public static DataTable EmployeeList;

        public void getEmployee()
        {
            EmployeeList = EmployeeDAO.getEmployee();
        }
        public bool addEmployee(EmployeeDTO employee)
        {
            if (EmployeeDAO.addEmployee(employee))
                return true;
            return false;
        }
        public bool updateEmployee(EmployeeDTO employee)
        {
            if (EmployeeDAO.updateEmployee(employee))
                return true;
            return false;
        }
        public bool removeEmployee(string id)
        {
            if (EmployeeDAO.removeEmployee(id))
                return true;
            return false;
        }
    }
}
