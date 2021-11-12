using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API
{
    public interface ISeedData
    {
        Task<bool> Seed();
    }

    public class SeedData : ISeedData
    {
        private readonly UserManager<ML.User> _userManager = null;
        public SeedData(UserManager<ML.User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<bool> Seed()
        {
            bool result = false;

            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseSqlite(@"Data Source=..\..\DB\PhoneBook.db;");


            using (var db = new DatabaseContext(options.Options))
            {
                ML.Role role = null;
                ML.User user = null;
                ML.PhoneBook phoneBook = null;
                ML.UserRole userRole = null;
                string testPassword = "1234";

                if (!db.Roles.Any())
                {
                    role = new ML.Role()
                    {
                        Name = "Owner",
                        NormalizedName = "Owner"
                    };

                    await db.Roles.AddAsync(role);
                }

                if (!db.Users.Any())
                {
                    string username = "moses@phonebook.com";
                    user = new ML.User()
                    {
                        UserName = username,
                        NormalizedUserName = username,
                        Email = username,
                        NormalizedEmail = username,
                        EmailConfirmed = true,
                        PhoneNumber = "0761118787",
                        PhoneNumberConfirmed = true,
                        CreatedDatestamp = DateTime.Now,
                        LogReason = "Creating test data"
                    };

                    await db.Users.AddAsync(user);
                }

                result = (await db.SaveChangesAsync() > 0);

                if (result)
                {
                    await _userManager.AddPasswordAsync(user, testPassword);

                    if (user != null && role != null)
                    {
                        if (!db.UserRoles.Any(ur => ur.RoleId == role.Id && ur.UserId == user.Id))
                        {
                            userRole = new ML.UserRole()
                            {
                                RoleId = role.Id,
                                UserId = user.Id
                            };

                            await db.UserRoles.AddAsync(userRole);
                        }
                    }

                    if (!db.PhoneBooks.Any())
                    {
                        phoneBook = new ML.PhoneBook()
                        {
                            OwnerId = user.Id,
                            Name = "My Phonebook",
                            CreatedById = user.Id,
                            CreatedDatestamp = DateTime.Now,
                            LogReason = "Creating test data"
                        };

                        await db.PhoneBooks.AddAsync(phoneBook);
                    }

                    result = (await db.SaveChangesAsync() > 0);
                }
            }

            return result;
        }
    }
}
