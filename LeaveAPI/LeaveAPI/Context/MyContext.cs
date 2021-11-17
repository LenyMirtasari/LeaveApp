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
        {
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Employee)
                .HasForeignKey<Account>(b => b.EmployeeId);

            modelBuilder.Entity<Job>()
               .HasMany(a => a.Employee)
               .WithOne(b => b.Job);

            modelBuilder.Entity<Account>()
                .HasMany(c => c.AccountRole)
                .WithOne(e => e.Account);

            modelBuilder.Entity<Role>()
                .HasMany(c => c.AccountRole)
                .WithOne(e => e.Role);

            modelBuilder.Entity<LeaveDetail>()
                .HasOne(a => a.TotalLeave)
                .WithOne(b => b.LeaveDetail)
                .HasForeignKey<TotalLeave>(b => b.LeaveDetailId);

            modelBuilder.Entity<LeaveType>()
                .HasMany(c => c.LeaveDetail)
                .WithOne(e => e.LeaveType);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.LeaveDetailManager)
                .WithOne(e => e.Manager);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.LeaveDetailEmployee)
                .WithOne(e => e.Employee);






        }
    }
}
