using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SmartAdmin.WebUI.Models.Horses> Horses { get; set; }
        public DbSet<SmartAdmin.WebUI.Models.Managers> Managers { get; set; }
        public DbSet<SmartAdmin.WebUI.Models.Owners> Owners { get; set; }
        public DbSet<SmartAdmin.WebUI.Models.Syndicates> Syndicates { get; set; }
    }
}
