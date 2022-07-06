using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using SmartAdmin.WebUI.Models;
using System.Security.Claims;

namespace SmartAdmin.WebUI.Models
{
    public class LoggedInUser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public LoggedInUser(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            UserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var manager = _context.Managers.Where(a => a.UserID == UserID).Single();
            if (manager != null)
            {
                Role = "Manager";
                Firstname = manager.Firstname;
                Surname = manager.Surname;
                Email = manager.Email;
                ManagerID = manager.Id;
                Company = manager.Company;
                ABN = manager.ABN;
                Address = manager.Address;
                Avatar = manager.Avatar;
                Status = manager.Status;
            }
            else
            {
                var owner = _context.Owners.Where(a => a.UserID == UserID).Single();
                if (owner != null)
                {
                    Role = "Owner";
                    Firstname = owner.Firstname;
                    Surname = owner.Surname;
                    Email = owner.Email;
                    OwnerID = owner.Id;
                    Company = owner.Company;
                    ABN = owner.ABN;
                    Address = owner.Address;
                    Avatar = owner.Avatar;
                    RAID = owner.RAID;
                }
                else
                {
                    // Must be administrator or not logged in                    
                }
            }
        }
        public string Firstname { get; }
        public string Surname { get; }
        public string Company { get; }
        public string ABN { get; }
        public string Address { get; }
        public string Avatar { get; }
        public string Status { get; }
        public string Email { get; }
        public string UserID { get; }
        public string ManagerID { get; }
        public int RAID { get; }
        public string OwnerID { get; }
        public string Role { get; }
    }
}

