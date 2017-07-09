using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Entities
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string phone_no { get; set; }
        public string gender { get; set; }
        public Boolean isAdmin { get; set; }
        public Boolean isActive { get; set; }
    }
}
