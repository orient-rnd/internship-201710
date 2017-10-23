using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFAndIdentity.Models
{
    public class CustomUer : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string PassWordHash { get; set; }
    }

    public class CustomUerDbContext : DbContext
    {
        public CustomUerDbContext() : base("dsadas") {            
        }

        public DbSet<CustomUer> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<CustomUer>();
            user.ToTable("Users");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            user.Property(x => x.UserName).IsRequired().HasMaxLength(256);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomUserStore : IUserPasswordStore<CustomUer, string>
    {
        private readonly CustomUerDbContext _context;

        public CustomUserStore(CustomUerDbContext context)
        {
            this._context = context;
        }

        public Task CreateAsync(CustomUer user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(CustomUer user)
        {
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<CustomUer> FindByIdAsync(string userId)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task<CustomUer> FindByNameAsync(string userName)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public Task<string> GetPasswordHashAsync(CustomUer user)
        {
            return Task.FromResult(user.PassWordHash);
        }

        public Task<bool> HasPasswordAsync(CustomUer user)
        {
            return Task.FromResult(user.PassWordHash != null);

        }

        public Task SetPasswordHashAsync(CustomUer user, string passwordHash)
        {
            user.PassWordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(CustomUer user)
        {
            _context.Users.Attach(user);
            return _context.SaveChangesAsync();
        }
    }
}
