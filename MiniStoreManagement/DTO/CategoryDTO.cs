using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class CategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public CategoryDTO()
        {
            State = "0";
        }
        public CategoryDTO(string id, string name, string state)
        {
            Id = id;
            Name = name;
            State = state;
        }
    }
}
