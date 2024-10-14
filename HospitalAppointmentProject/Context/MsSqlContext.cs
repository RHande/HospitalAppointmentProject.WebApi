using HospitalAppointmentProject.Models;
using Microsoft.EntityFrameworkCore;




namespace HospitalAppointmentProject.Context;

public class MsSqlContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433; Database=HospitalAppointmentDb; User=sa; Password=yourStrong(!)Password; TrustServerCertificate=True");
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasOne(a=>a.Doctor)
            .WithMany(d=>d.Appointments)
            .HasForeignKey(a=>a.DoctorId);
        base.OnModelCreating(modelBuilder);
    }
}

