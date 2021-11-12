using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DL
{
    public class DatabaseContext : IdentityDbContext<ML.User, ML.Role, int>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=..\..\DB\PhoneBook.db;");
        }

        /// <summary>
        /// On Modelcreating override
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            #region [ASP.NET Identity Custom Models]
            builder.Entity<ML.Role>(bk =>
            {
                bk.ToTable(name: "Role");
                bk.HasKey(rol => rol.Id);
            });

            builder.Entity<ML.RoleClaim>(bk =>
            {
                bk.ToTable(name: "RoleClaim");
                //bk.HasKey(rol => rol.Id);
            });

            builder.Entity<ML.User>(bk =>
            {
                bk.ToTable(name: "User");
                bk.HasKey(rol => rol.Id);
            });

            builder.Entity<ML.UserClaim>(bk =>
            {
                bk.ToTable(name: "UserClaim");
                //bk.HasKey(rol => rol.Id);
            });

            builder.Entity<IdentityUserLogin<int>>(bk =>
            {
                bk.ToTable(name: "UserLogin");
                bk.HasKey(rol => rol.UserId);
            });

            builder.Entity<IdentityUserRole<int>>(bk =>
            {
                bk.ToTable(name: "UserRole");
                bk.HasKey(rol => new { rol.UserId, rol.RoleId});
            });

            builder.Entity<IdentityUserToken<int>>(bk =>
            {
                bk.ToTable(name: "UserToken");
                bk.HasKey(rol => rol.UserId);
            });
            #endregion

            #region [PhoneBook Models]
            builder.Entity<ML.PhoneBook>(bk =>
            {
                bk.ToTable(name: "PhoneBook");
            });

            builder.Entity<ML.Entry>(bk =>
            {
                bk.ToTable(name: "Entry");
            });
            #endregion
        }

        public virtual DbSet<ML.PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<ML.Entry> Entries { get; set; }
    }
}
