using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFAndIdentity.Entities
{
    public partial class JobContext : DbContext
    {
        public virtual DbSet<Job> Job { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\;Database=Jobs;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Applied).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(1550);

                entity.Property(e => e.JobName).HasMaxLength(1550);
            });
        }
    }
}
