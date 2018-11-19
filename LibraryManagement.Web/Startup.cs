using LibraryManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryManagement.Web.Startup))]
namespace LibraryManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup I am creating first Admin Role and creating a default Admin User   
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin role   
                var admin = new IdentityRole { Name = "Admin" };
                roleManager.Create(admin);

                var regularUser = new IdentityRole { Name = "RegularUser" };
                roleManager.Create(regularUser);

                //Here we create a Admin super user who will maintain the website                 
                var user = new ApplicationUser
                {
                    UserName = "administrator@gmail.com",
                    Email = "administrator@gmail.com",
                };

                var chkUser = userManager.Create(user, "Admin!234");

                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }

                var user1 = new ApplicationUser
                {
                    UserName = "user1@gmail.com",
                    Email = "user1@gmail.com",
                };

                var chkUser1 = userManager.Create(user1, "User1!234");
                if (chkUser1.Succeeded)
                {
                    userManager.AddToRole(user1.Id, "RegularUser");
                }

                var user2 = new ApplicationUser
                {
                    UserName = "user2@gmail.com",
                    Email = "user2@gmail.com",
                };

                var chkUser2 = userManager.Create(user2, "User2!234");
                if (chkUser2.Succeeded)
                {
                    userManager.AddToRole(user2.Id, "RegularUser");
                }

            }
        }
    }
}