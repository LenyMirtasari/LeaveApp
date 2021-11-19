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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<LeaveDetail> LeaveDetails { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TotalLeave> TotalLeaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One => Employee to Account
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Employee)
                .HasForeignKey<Account>(b => b.EmployeeId);

            //One to Many => Account to AccountRole
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(b => b.AccountRole)
                .HasForeignKey(ar => ar.EmployeeId);

            //One to Many => Role to AccountRole
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(c => c.AccountRole)
                .HasForeignKey(ar => ar.RoleId);

            //One to Many => Job to Employee
            modelBuilder.Entity<Job>()
                .HasMany(c => c.Employee)
                .WithOne(e => e.Job);

            //One to Many => Employee to LeaveDetailEmployee
            modelBuilder.Entity<LeaveDetail>()
                    .HasOne(m => m.Manager)
                    .WithMany(t => t.LeaveDetailManager)
                    .HasForeignKey(m => m.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            //One to Many => Employee to LeaveDetailManager
            modelBuilder.Entity<LeaveDetail>()
                    .HasOne(m => m.Employee)
                    .WithMany(t => t.LeaveDetailEmployee)
                    .HasForeignKey(m => m.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            //One to Many => Employee to TotalLeave
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.TotalLeave)
                .WithOne(e => e.Employee);

            //One to Many => LeaveType to LeaveDetail
            modelBuilder.Entity<LeaveType>()
                .HasMany(c => c.LeaveDetail)
                .WithOne(e => e.LeaveType);

            //One to Many => Employee to Manager
            modelBuilder.Entity<Employee>()
                    .HasOne(m => m.Manager)
                    .WithMany(t => t.Employees)
                    .HasForeignKey(m => m.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
