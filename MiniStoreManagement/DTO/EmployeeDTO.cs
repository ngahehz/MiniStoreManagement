using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Cell { get; set; }
        public string Img { get; set; }
        public EmployeeDTO()
        {

        }
        public EmployeeDTO(int id, string name, string gender, DateTime doB, string cell, string img)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DoB = doB;
            Cell = cell;
            Img = img;
        }
    }
}
