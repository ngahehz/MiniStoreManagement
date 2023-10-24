using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class CategoryMiniDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryMiniDTO()
        {

        }
        public CategoryMiniDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
