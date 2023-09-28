using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployees.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(s => s.BirthDate).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Employee>().Property(s => s.JobPosition).HasDefaultValue(JobPosition.Junior);
            modelBuilder.Entity<Employee>()
                .HasOne(s => s.Department)
                .WithMany(s => s.Employees)
                .HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Department>().Property(s => s.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Department>().HasMany(s => s.Employees);

            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Contract>().Property(s => s.StartDate).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<Contract>().Property(s => s.EndDate).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<Contract>().HasOne(s => s.Employee);

        }
    }
}
