using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class ProviderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cell { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ProviderDTO()
        {

        }
        public ProviderDTO(int id, string name, int cell, string address, string email)
        {
            Id = id;
            Name = name;
            Cell = cell;
            Address = address;
            Email = email;
        }
    }
}
