using LeaveAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<LeaveDetail> LeaveDetails{ get; set; }
        public DbSet<LeaveType> LeaveTypes{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TotalLeave> TotalLeaves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Employe - Account
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Employee)
                .HasForeignKey<Account>(b => b.EmployeeId);

            //Job - Employee
            modelBuilder.Entity<Job>()
               .HasMany(a => a.Employee)
               .WithOne(b => b.Job);

            //Account - AccountRole
            modelBuilder.Entity<Account>()
                .HasMany(c => c.AccountRole)
                .WithOne(e => e.Account);

            //Role - AccountRole
            modelBuilder.Entity<Role>()
                .HasMany(c => c.AccountRole)
                .WithOne(e => e.Role);

            //LeaveDetail - Employee
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.TotalLeave)
                .WithOne(e => e.Employee);

            //LeaveType - LeaveDetail
            modelBuilder.Entity<LeaveType>()
                .HasMany(c => c.LeaveDetail)
                .WithOne(e => e.LeaveType);

            //Employee - Leave Detail Manager
            /* modelBuilder.Entity<LeaveDetail>()
                 .HasOne(a => a.Manager)
                 .WithMany(b => b.LeaveDetailManager)
                 .HasForeignKey(a => a.ManagerId);*/
            /* modelBuilder.Entity<Employee>()
                 .HasMany(c => c.LeaveDetailManager)
                 .WithOne(e => e.Manager);*/
            modelBuilder.Entity<LeaveDetail>()
                    .HasOne(m => m.Manager)
                    .WithMany(t => t.LeaveDetailManager)
                    .HasForeignKey(m => m.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);


            //Employee - Leave Detail Employee
            modelBuilder.Entity<LeaveDetail>()
                    .HasOne(m => m.Employee)
                    .WithMany(t => t.LeaveDetailEmployee)
                    .HasForeignKey(m => m.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<LeaveDetail>()
                 .HasOne(a => a.Employee)
                 .WithMany(b => b.LeaveDetailEmployee)
                 .HasForeignKey(a => a.EmployeeId);
            /*modelBuilder.Entity<Employee>()
                .HasMany(c => c.LeaveDetailEmployee)
                .WithOne(e => e.Employee);*/

            //SelfJoin Employee-Manager
            modelBuilder.Entity<Employee>()
                 .HasMany(a => a.Employees)
                 .WithOne(b => b.Manager)
                 .HasForeignKey(a => a.ManagerId)
                 .OnDelete(DeleteBehavior.ClientSetNull); 
          




        }
    }
}
