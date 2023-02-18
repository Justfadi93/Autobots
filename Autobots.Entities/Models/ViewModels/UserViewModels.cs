using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class UserVm
    {
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        public int? usertype { get; set; }

    }

    public class RolesVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}