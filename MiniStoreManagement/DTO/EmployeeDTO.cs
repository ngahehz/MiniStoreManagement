using MiniStoreManagement.GUI.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class EmployeeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Cell { get; set; }
        public string Img { get; set; }
        public string State { get; set; } // 0 là bình thường, 1 là xóa tạm
        public EmployeeDTO() 
        {
            State = "0";
        }
        public EmployeeDTO(DataRow row)
        {
            Id = row[0].ToString();
            Name = row[1].ToString();
            Gender = row[2].ToString();
            DoB = (DateTime)row[3];
            Cell = row[4].ToString();
            Img = row[5].ToString();
            State = row[6].ToString();
        }
    }
}
