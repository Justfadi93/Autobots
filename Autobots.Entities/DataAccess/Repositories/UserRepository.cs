using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.Context;
using Autobots.Entities.Models.Defaults;
using Autobots.Entities.Models.ViewModels;

namespace Autobots.Entities.DataAccess.Repositories
{
    public class UserRepository
    {
        readonly ApplicationDbContext _context;
        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }
        public List<RolesVM> GetRoles()
        {
            return _context.Roles.Select(x => new RolesVM() { Id = x.Id, Name = x.Name }).ToList();
        }
        public string GetRoleId(string roleName)
        {
            return _context.Roles.Where(x => x.Name.ToLower().Equals(roleName.ToLower())).Select(x => x.Id).FirstOrDefault();
        }
        public string GetRoleName(string roleId)
        {
            return _context.Roles.Where(x => x.Id.ToLower().Equals(roleId.ToLower())).Select(x => x.Name).FirstOrDefault();
        }
        public List<UserVm> GetUsersByRole(string roleName)
        {
            var roleId = GetRoleId(roleName);
            return _context.Users.Where(x => x.Roles.FirstOrDefault().RoleId.Equals(roleId)).Select(x => new UserVm()
            {
                UserId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                EmailAddress = x.Email,
                PhoneNo = x.PhoneNumber,
                RoleName = roleName,
                UserName = x.UserName,
                IsActive = x.IsActive
            }).ToList();
        }
        public List<UserVm> GetUsers()
        {
            var roles = GetRoles();
            return _context.Users.Select(x => new UserVm()
            {
                UserId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                EmailAddress = x.Email,
                PhoneNo = x.PhoneNumber,
                RoleName = roles.FirstOrDefault(y => y.Id.Equals(x.Roles.FirstOrDefault().RoleId)).Name,
                UserName = x.UserName,
                IsActive = x.IsActive
            }).ToList();
        }

        public List<ApplicationUser> GetAllCustomuser()
        {
            return _context.Users.Where(x => x.usertype == (int)RolesEnum.CustomUser).ToList();
        }

        public List<ApplicationUser> GetallCustomuser()
        {
            var roles = GetRoles();
            return _context.Users.Where(x => x.usertype == (int)RolesEnum.Customer && x.IsActive.Equals(true)).ToList();
        }




        public UserVm GetUserById(string userId)
        {
            var roles = GetRoles();
            var user = _context.Users.FirstOrDefault(x => x.Id.Equals(userId));
            return new UserVm()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                EmailAddress = user.Email,
                PhoneNo = user.PhoneNumber,
                RoleName = roles.FirstOrDefault(y => y.Id.Equals(user.Roles.FirstOrDefault().RoleId)).Name,
                UserName = user.UserName,
                IsActive = user.IsActive
            };
        }
        public UserVm GetUserByEmail(string userEmail)
        {
            var roles = GetRoles();
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(userEmail));
            return new UserVm()
            {
                UserId = user?.Id,
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                Address = user?.Address,
                EmailAddress = user?.Email,
                PhoneNo = user?.PhoneNumber,
                RoleName = roles.FirstOrDefault(y => y.Id.Equals(user.Roles.FirstOrDefault().RoleId)).Name,
                UserName = user?.UserName,
                IsActive = user?.IsActive
            };
        }
        public IQueryable<ApplicationUser> GetUsersIq(string roleName)
        {
            var roleId = GetRoleId(roleName);
            return _context.Users.Where(x => x.Roles.FirstOrDefault().RoleId.Equals(roleId));
        }
    }
}