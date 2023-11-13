using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    public class ProviderDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string State { get; set; } // 0 là bth, 1 là xóa
        public ProviderDTO()
        {
            State = "0";
        }
        public ProviderDTO(string id, string name, string cell, string address, string email, string state)
        {
            Id = id;
            Name = name;
            Cell = cell;
            Address = address;
            Email = email;
            State = state;
        }
    }
}
