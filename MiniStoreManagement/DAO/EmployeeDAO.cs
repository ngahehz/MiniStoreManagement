using MiniStoreManagement.DTO;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStoreManagement.DAO
{
    internal class EmployeeDAO
    {
        private static ConnectSQL conn = new ConnectSQL();

        public DataTable getEmployee()
        {
            return conn.ReadData("SELECT * FROM employee"); 
        }

        public bool addEmployee(EmployeeDTO employee)
        {
            string s = $"INSERT INTO employee VALUES ('{employee.Id}', N'{employee.Name}', N'{employee.Gender}', '{employee.DoB}', '{employee.Cell}', '{employee.Img}')";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool updateEmployee(EmployeeDTO employee)
        {
            string s = $"UPDATE employee SET ID = '{employee.Id}', NAME = N'{employee.Name}', GENDER = N'{employee.Gender}', DOB = '{employee.DoB}',"
                        + $"CELL = '{employee.Cell}', IMG = '{employee.Img}' WHERE ID = '{employee.Id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

        public bool removeEmployee(string id)
        {
            string s = $"DELETE FROM employee WHERE ID = '{id}'";
            if (conn.ChangeData(s))
                return true;
            return false;
        }

    }
}
