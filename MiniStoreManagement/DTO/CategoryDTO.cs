using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryMiniId { get; set; }
        public CategoryDTO()
        {

        }
        public CategoryDTO(int id, string name, int categoryMiniId)
        {
            Id = id;
            Name = name;
            CategoryMiniId = categoryMiniId;
        }
    }
}
