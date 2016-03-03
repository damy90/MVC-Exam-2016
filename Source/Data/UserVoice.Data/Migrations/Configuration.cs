namespace UserVoice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using GenericTools;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using UserVoice.Common;
    using UserVoice.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private static Random random = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "user1@site.com";
            const string AdministratorPassword = "user1";
            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);
            }

            if (!context.Ideas.Any())
            {
                var idea = new Idea()
                {
                    Title = "XNA 5",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!"
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Allow .NET games on Xbox One",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One."
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Support web.config style Transforms on any file in any project type",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other files."
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Bring back Macros",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs."
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Open source Silverlight",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Blog post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/"
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Native DirectX 11 support for WPF",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "n 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF."
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Make WPF open-source and accept pull-requests from the community",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community."
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Fix 260 character file name length limitation",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation"
                };

                context.Ideas.Add(idea);

                idea = new Idea()
                {
                    Title = "Support for ES6 modules",
                    AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                    CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                    Description = "Add support for the new JavaScript ES6 module syntax, including module definition and imports."
                };

                context.Ideas.Add(idea);

                //Абе мързи ме да пиша
            }

            context.SaveChanges();

            if (!context.Comments.Any())
            {
                var ideas = context.Ideas.ToList();
                var loremIpsum =
                    "Quo ei lorem dicam. Qui putent accusamus referrentur cu, sed illud intellegat efficiantur ea. Qui ad decore complectitur, pro novum tollit delicatissimi an, nobis cotidieque ei quo. Ignota delicatissimi ea duo, has consul cetero at, eum sale atqui eu. Ne ius case atqui, eos at autem inermis deseruisse, cu malis bonorum sit.";

                foreach (var idea in ideas)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var comment = new Comment()
                        {
                            Content = loremIpsum.Substring(0, random.Next(0, loremIpsum.Length - 10)),
                            AuthorEmail = "MrsSpammer@spam.spam",
                            AuthorIp = RandomIpAddressGenerator.Generate(),
                            CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                            IdeaId = idea.Id
                        };

                        context.Comments.Add(comment);
                    }
                }
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!context.Votes.Any())
            {
                var ideas = context.Ideas.ToList();

                foreach (var idea in ideas)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var vote = new Vote()
                        {
                            AuthorIpAddress = RandomIpAddressGenerator.Generate(),
                            CreatedOn = DateTime.Now.AddDays(-random.Next(0, 100)).AddHours(random.Next(0, 12)),
                            IdeaId = idea.Id,
                            Value = random.Next(1, 4)
                        };

                        context.Votes.Add(vote);
                    }
                }
            }

            context.SaveChanges();
            /*if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }*/
        }
    }
}
