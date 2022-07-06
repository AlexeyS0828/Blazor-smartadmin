using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Services
{
    public interface IGetLoggedInUserService
    {
        LoggedInUser GetLoggedInUser();
    }
}

