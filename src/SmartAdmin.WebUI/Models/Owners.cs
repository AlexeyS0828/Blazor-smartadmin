using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Owners
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string ManagerID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string ABN { get; set; }
        public string Address { get; set; }
        public int RAID { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
