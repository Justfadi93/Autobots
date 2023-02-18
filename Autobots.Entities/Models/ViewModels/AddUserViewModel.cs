using Autobots.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class AddUserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string rolename { get; set; }
        public int type { get; set; }
        public List<ApplicationUser> userlist { get; set; }
        public AddUserViewModel()
        {
            userlist = new List<ApplicationUser>();
        }




    }
}