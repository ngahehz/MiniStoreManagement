using System;
using System.Collections.Generic;
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
        public EmployeeDTO(string id, string name, string gender, DateTime doB, string cell, string img, string state)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DoB = doB;
            Cell = cell;
            Img = img;
            State = state;
        }
    }
}
