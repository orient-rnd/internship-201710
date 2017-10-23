//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EFAndIdentity.Models
//{
//    public class CustomUser : IUser<string>
//    {
//        public string Id { get; set; }

//        public string UserName { get; set; }

//        public string PassWordHash { get; set; }
//    }

//    public class CustomUserDbContext : DbContext
//    {
//        public CustomUserDbContext() : base("dsadas") {            
//        }

//        public DbSet<CustomUser> Users { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            var user = modelBuilder.Entity<CustomUser>();
//            user.ToTable("Users");
//            user.HasKey(x => x.Id);
//            user.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
//            user.Property(x => x.UserName).IsRequired().HasMaxLength(256);

//            base.OnModelCreating(modelBuilder);
//        }
//    }

//    public class CustomUserStore : IUserPasswordStore<CustomUser, string>
//    {
//        private readonly CustomUserDbContext _context;

//        public CustomUserStore(CustomUserDbContext context)
//        {
//            this._context = context;
//        }

//        public Task CreateAsync(CustomUser user)
//        {
//            _context.Users.Add(user);
//            return _context.SaveChangesAsync();
//        }

//        public Task DeleteAsync(CustomUser user)
//        {
//            _context.Users.Remove(user);
//            return _context.SaveChangesAsync();
//        }

//        public void Dispose()
//        {
//            _context.Dispose();
//        }

//        public Task<CustomUser> FindByIdAsync(string userId)
//        {
//            return _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
//        }

//        public Task<CustomUser> FindByNameAsync(string userName)
//        {
//            return _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
//        }

//        public Task<string> GetPasswordHashAsync(CustomUser user)
//        {
//            return Task.FromResult(user.PassWordHash);
//        }

//        public Task<bool> HasPasswordAsync(CustomUser user)
//        {
//            return Task.FromResult(user.PassWordHash != null);

//        }

//        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
//        {
//            user.PassWordHash = passwordHash;
//            return Task.CompletedTask;
//        }

//        public Task UpdateAsync(CustomUser user)
//        {
//            _context.Users.Attach(user);
//            return _context.SaveChangesAsync();
//        }
//    }
//}
