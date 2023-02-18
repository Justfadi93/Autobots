using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.Defaults
{
    public class RequiredIfRole : RequiredAttribute
    {
        private string Role { get; set; }

        public RequiredIfRole(string role)
        {
            Role = role;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (HttpContext.Current.User.IsInRole(Role) && base.IsValid(value, context) == ValidationResult.Success)
            {
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}