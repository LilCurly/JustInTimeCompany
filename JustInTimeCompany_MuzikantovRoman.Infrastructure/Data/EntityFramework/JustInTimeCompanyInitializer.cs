using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework
{
    public class JustInTimeCompanyInitializer
    {
        public static void Initiliaze(JustInTimeCompanyDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(context.Users.Any())
            {
                return;
            }

            CreateRoles(roleManager);
            context.SaveChanges();

            var helis = new Plane[]
            {
                new Plane{ Name = "Eurocopter AS 355 F1/F2 Ecureuil III", Capacity = 5, Motor = "Deux turbines du modèle de Rolls Royce 250-C20F", Speed = 220},
                new Plane{ Name = "Bell 206 JetRanger", Capacity = 4, Motor = "Une turbine du type Rolls Royce 250-C20B", Speed = 190},
                new Plane{ Name = "Robinson R44 Raven II", Capacity = 3, Motor = "Un piston du type Lycoming modèle IO-540", Speed = 190}
            };
            foreach(Plane heli in helis)
            {
                context.Planes.Add(heli);
            }
            context.SaveChanges();

            var airports = new Airport[]
            {
                new Airport{ Name = "Liège" },
                new Airport{ Name = "Charleroi" },
                new Airport{ Name = "Bruxelles" },
                new Airport{ Name = "Oostende" }
            };
            foreach(Airport airport in airports)
            {
                context.Airports.Add(airport);
            }
            context.SaveChanges();

            CreateDirector(userManager);
            context.SaveChanges();

            CreatePilots(userManager);
            context.SaveChanges();
        }

        private static void CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            IdentityRole member = new IdentityRole
            {
                Name = "Member"
            };
            roleManager.CreateAsync(member).Wait();

            IdentityRole pilot = new IdentityRole
            {
                Name = "Pilot"
            };
            roleManager.CreateAsync(pilot).Wait();

            IdentityRole director = new IdentityRole
            {
                Name = "Director"
            };
            roleManager.CreateAsync(director).Wait();
        }

        private static void CreateDirector(UserManager<AppUser> userManager)
        {
            MakeUser(userManager, "Mo", "Ney", "M.Ney@jitc.com", "M.Ney@jitc.com", "NeyMo_1", "Director", false);
        }

        private static void CreatePilots(UserManager<AppUser> userManager)
        {
            MakeUser(userManager, "Danièle", "Balav", "D.Balav@jitc.com", "D.Balav@jitc.com", "BalavDaniel_1", "Pilot", true);
            MakeUser(userManager, "Thierry", "Sabine", "T.Sabine@jitc.com", "T.Sabine@jitc.com", "SabineThierry_1", "Pilot", true);
            MakeUser(userManager, "Eli", "Coptère", "E.Coptere@jitc.com", "E.Coptere@jitc.com", "CoptereEli_1", "Pilot", true);
        }

        private static void MakeUser(UserManager<AppUser> userManager, string firstName, string lastName, string email, string username, string password, string role, bool isPilot)
        {
            AppUser user = new AppUser
            { 
                User = new User{ FirstName = firstName, LastName = lastName, Mail = email, Password = password, IsPilot = isPilot}, 
                Email = email, 
                UserName = username
            };

            IdentityResult result = userManager.CreateAsync(user, user.User.Password).Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, role).Wait();
            }
        }
    }
}
