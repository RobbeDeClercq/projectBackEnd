using Microsoft.AspNetCore.Identity;
using QuizDerFlandriens.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizDerFlandriens.Models.Data
{
    public static class QuizDerFlandriensContextExtensions
    {
        private static readonly QuizDerFlandriensContext context;

        public async static Task SeedRoles(RoleManager<IdentityRole> RoleMgr)
        {
            IdentityResult roleResult;
            string[] roleNames = { "Admin", "Player" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleMgr.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleMgr.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        public async static Task SeedUsers(UserManager<Person> userMgr)
        {
            try
            {
                if (await userMgr.FindByNameAsync("Docent@MCT") == null)  //controleer de UserName
                {
                    var user = new Person()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "Docent@MCT",
                        Name = "Docent Van Howest",
                        Email = "Docent@MCT.BE",
                    };

                    var userResult = await userMgr.CreateAsync(user, "Docent@1");
                    var roleResult = await userMgr.AddToRoleAsync(user, "Admin");

                    if (!roleResult.Succeeded)
                    {
                        throw new InvalidOperationException("Failed to build user and roles");
                    }
                }
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}
