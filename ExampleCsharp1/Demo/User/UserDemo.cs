using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Users;

namespace Demo
{
    class UserDemo
    {
        private const string UserType = "USR";

        private readonly UserService userService;
        private readonly Session session;
        private UserSummary userSummary;
        private User user;
        private IEnumerable<UserSummary> users;

        public UserDemo(Session session)
        {
            this.session = session;
            userService = new UserService(session);
        }

        public void Run()
        {
            var user = new User
            {
                Code = "API000122",
                Name = "tester",
                Shortname = "tester",
                Nameview = "",
                Type = "regular",
                Acceptextracost = "false",
                Demo = "true",
                Password = "test",
                Culture = "nl-NL",
                Email = "test@test.nl",
                Role = "",
                Support = "",
                Exchangequota = "",
                Filemanagerquota = "",
                Freetext1 = "",
                Freetext2 = "",
                Freetext3 = "",
                Smslogin = new Smslogin
                {
                    Phonenumber = "",
                    Service = "0"
                },
                Office = new Office
                {
                    Default = "",
                    Template = "false"
                },
                Account = new Account
                {
                    Sso = "0",
                    Expire = "",
                    Disable = new Disable
                    {
                        From = "",
                        To = ""
                    }
                },
                Time = new Time
                {
                    Authoriser = "9999",
                    Weekhours = "40"
                },
                Expenses = new Expenses
                {
                    Dimension1 = "",
                    Dimension2 = "",
                    Dimension3 = "",
                    Dimension4 = ""
                }
            };
//            userService.CreateUser(user);
            var delUser = new User
            {
                Code = "MARCEL",
                Deletereason = new Deletereason
                {
                    Code = "nolongeroperative",
                    Comment = "test"
                }
            };
            userService.DeleteUser(delUser);
            if (!FindUsers())
            {
                return;
            }

            if (!ReadUserDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindUsers()
        {
            Console.WriteLine("Searching for users");
            const int searchField = 2;
            var users = userService.FindUsers("*", UserType, searchField);

            DisplayUserSummaries(users);

            if (users.Count < 1)
            {
                return false;
            }
            else
            {
                this.users = users;
                userSummary = users.First();
                return true;
            }
        }

        private bool ReadUserDetails()
        {
            Console.WriteLine("Read user details");
            foreach (var u in users)
            {
                user = userService.ReadUser(u.Code);

                if (userSummary == null)
                {
                    Console.WriteLine("User {0} not found", user.Code);
                    return false;
                }
                DisplayUserDetails(user);
            }

            return true;
        }

        private static void DisplayUserSummaries(IEnumerable<UserSummary> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine("{0, -16} {1}", user.Code, user.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayUserDetails(User user)
        {
            Console.WriteLine("------");
            Console.WriteLine("User details of {0}", user.Name);
            Console.WriteLine("office = {0}", user.Office);
            Console.WriteLine("code = {0}", user.Code);
            Console.WriteLine("touched = {0}", user.Touched);
            Console.WriteLine("created = {0}", user.Created);
            Console.WriteLine("modified = {0}", user.Modified);
            Console.WriteLine("name = {0}", user.Name);
            Console.WriteLine("shortname = {0}", user.Shortname);
            Console.WriteLine("nameview = {0}", user.Nameview);
            Console.WriteLine("type = {0}", user.Type);
            Console.WriteLine("acceptextracost = {0}", user.Acceptextracost);
            Console.WriteLine("demo = {0}", user.Demo);
            Console.WriteLine("password = {0}", user.Password);
            Console.WriteLine("culture = {0}", user.Culture);
            Console.WriteLine("email = {0}", user.Email);
            Console.WriteLine("role = {0}", user.Role);
            Console.WriteLine("support = {0}", user.Support);
            Console.WriteLine("exchangequota = {0}", user.Exchangequota);
            Console.WriteLine("filemanagerquota = {0}", user.Filemanagerquota);
            Console.WriteLine("freetext1 = {0}", user.Freetext1);
            Console.WriteLine("freetext2 = {0}", user.Freetext2);
            Console.WriteLine("freetext3 = {0}", user.Freetext3);
            Console.WriteLine("------");
            Console.WriteLine("Smslogin:");
            Console.WriteLine("phonenumber = {0}", user.Smslogin.Phonenumber);
            Console.WriteLine("service = {0}", user.Smslogin.Service);
            Console.WriteLine("services = {0}", user.Smslogin.Services);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Office:");
            Console.WriteLine("default = {0}", user.Office.Default);
            Console.WriteLine("template = {0}", user.Office.Template);
            Console.WriteLine("offices = {0}", user.Office.Offices);
            Console.WriteLine("restricted = {0}", user.Office.Restricted);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Account:");
            Console.WriteLine("sso = {0}", user.Account.Sso);
            Console.WriteLine("expire = {0}", user.Account.Expire);
            Console.WriteLine("Disable:");
            Console.WriteLine("from = {0}", user.Account.Disable.From);
            Console.WriteLine("to = {0}", user.Account.Disable.To);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Time:");
            Console.WriteLine("authoriser = {0}", user.Time.Authoriser);
            Console.WriteLine("weekhours = {0}", user.Time.Weekhours);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("Expenses:");
            Console.WriteLine("dimesnion1 = {0}", user.Expenses.Dimension1);
            Console.WriteLine("dimension2 = {0}", user.Expenses.Dimension2);
            Console.WriteLine("dimension3 = {0}", user.Expenses.Dimension3);
            Console.WriteLine("dimension4 = {0}", user.Expenses.Dimension4);
            Console.WriteLine("------");
            Console.WriteLine("performance = {0}", user.Performance);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
