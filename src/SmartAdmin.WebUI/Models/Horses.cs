using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Models
{
    public class Horses
    {
        public string Id { get; set; }
        public string ManagerID { get; set; }
        public string Name { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public DateTime FoalDate { get; set; }
        public string Country { get; set; }
        public byte[] Pedigree { get; set; }
    }
}
