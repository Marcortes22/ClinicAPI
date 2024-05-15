using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entities;
using System.Reflection.Metadata;
namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MARCOPC\\SQLEXPRESS;Database=ClinicAPI;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    
        public DbSet<Clinic> clinics { get; set; }

        public DbSet<ClinicBranch> clinicBranches { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        public DbSet<AppointmentType> appointmentTypes { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Role> roles { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>()
                .HasMany(clinic => clinic.clinicBranch)
                .WithOne(clinicBranch => clinicBranch.clinic)
                .HasForeignKey(clinicBranch => clinicBranch.clinicId)
                 .OnDelete(DeleteBehavior.Restrict); 



            modelBuilder.Entity<Clinic>()
               .HasMany(clinic => clinic.users)
               .WithOne(users => users.clinic)
               .HasForeignKey(users => users.clinicId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>()
             .HasMany(user => user.appointment)
             .WithOne(appointment => appointment.user)
             .HasForeignKey(appointment => appointment.userId)
              .OnDelete(DeleteBehavior.Restrict); 



            modelBuilder.Entity<ClinicBranch>()
             .HasMany(clinicBranch => clinicBranch.appointment)
             .WithOne(appointment => appointment.clinicBranch)
             .HasForeignKey(appointment => appointment.clinicBranchId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
            .HasOne(appointment => appointment.appointmentType)
            .WithOne(appointmenttype => appointmenttype.appointment)
            .HasForeignKey<AppointmentType>(appointmenttype => appointmenttype.appointmentId)
             .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<User>()
         .HasMany(e => e.roles)
         .WithMany(e => e.users)
         .UsingEntity<UserRole>();


        }




    }
}
