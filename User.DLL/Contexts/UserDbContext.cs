using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Models;

namespace User_DLL.Contexts
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }
     
        protected  override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(et =>
            {
                et.HasKey(t => t.Id);
                et.Property(t => t.Name).HasMaxLength(36);
                et.Property(t => t.CreateTime).HasDefaultValueSql("getdate()");
                et.Property(t => t.UserName).HasMaxLength(36);
                et.Property(t => t.UserPwd).HasMaxLength(32);
                et.Property(t => t.PhoneNumber).HasMaxLength(11);
                et.Property(t => t.AddressDetail).HasMaxLength(128);
                et.Property(t => t.Remarks).HasMaxLength(64);
                et.Property(t => t.CurrentUnit).HasMaxLength(32);
                et.Property(t => t.IDCard).HasMaxLength(18);
                et.HasMany(t => t.CheckRecords).WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
            });
            builder.Entity<CheckRecord>(et =>
            {
                et.HasKey(t => t.Id);
                et.Property(t => t.Name).HasMaxLength(12);
                et.Property(t => t.CreateTime).HasDefaultValueSql("getdate()");
            });

        }
       

    }
}
