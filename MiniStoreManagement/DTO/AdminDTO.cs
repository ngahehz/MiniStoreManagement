using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStoreManagement.DTO
{
    internal class AdminDTO
    {
        public string ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }

        public AdminDTO(string id, string name, string uname, string pass)
        {
            ID = id;
            NAME = name;
            USERNAME = uname;
            PASSWORD = pass;
        }

        public AdminDTO()
        {
        }

        public AdminDTO(DataRow row)
        {
            this.ID = row["ID"].ToString();
            this.USERNAME = row["USERNAME"].ToString();
            this.PASSWORD = row["PASSWORD"].ToString();
            this.NAME = row["NAME"].ToString();
        }
    }


}
