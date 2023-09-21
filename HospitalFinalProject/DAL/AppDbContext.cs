using HospitalFinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalFinalProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PatientStatus> PatientStatuses { get; set; }
        public DbSet<DoctorStatus> DoctorStatuses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<RoomAllotment> RoomAllotments { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Doctors)
                .WithOne(d => d.Department) 
                .HasForeignKey(d => d.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.HeadDoctor)
                .WithOne()
                .HasForeignKey<Department>(d => d.HeadDoctorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
