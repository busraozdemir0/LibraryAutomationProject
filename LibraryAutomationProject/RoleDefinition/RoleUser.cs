using LibraryAutomation.Entities.Model.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LibraryAutomationProject.RoleDefinition
{
    // Rol tabanli yetkilendirme islemleri icin
    public class RoleUser : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username) // Roller icin kullanilacak
        {
            using (var context = new LibraryContext())
            {
                // Rol, Kullanici ve KullaniciRolleri tablosunu birbirine join etme
                var roles = (
                                from u in context.Users
                                 join
                                ur in context.UserRoles on u.Id equals ur.UserId
                                 join r in context.Roles on ur.RoleId equals r.Id
                                 where u.Email == username

                                 select r.RoleName
                             ).ToArray();

                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}