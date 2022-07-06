using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Syndicates
    {
        public string Id { get; set; }
        public string ManagerID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }
}
