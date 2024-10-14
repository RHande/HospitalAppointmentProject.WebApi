using HospitalAppointmentProject.Context;
using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentProject.Repositories.Concretes;

public class EfAppointmentRepository : IAppointmentRepository
{
    
    private MsSqlContext _context;
    public EfAppointmentRepository(MsSqlContext context)
    {
        _context = context;
    }
    
    
    public Appointment? GetById(Guid id)
    {
        Appointment appointment = _context.Appointments.Find(id);
        return appointment;
    }

    public List<Appointment> GetAll()
    {
        List<Appointment>  appointments = _context.Appointments.ToList();
        return appointments;
    }

    public Appointment Add(Appointment user)
    {
        _context.Appointments.Add(user);
        _context.SaveChanges();
        return user;
    }

    public Appointment Update(Appointment user)
    {
        _context.Appointments.Update(user);
        _context.SaveChanges();
        return user;
    }

    public Appointment Delete(Guid id)
    {
        Appointment appointment = _context.Appointments.Find(id);
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
        return appointment;
    }

    public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
    {
        List<Appointment> appointments = _context.Appointments.Where(a => a.DoctorId == doctorId).ToList();
        return appointments;
    }

    public void DeleteExpiredAppointments()
    {
        var expiredAppointments = _context.Appointments.Where(a => a.AppointmentDate < DateTime.Now).ToList();
        if(expiredAppointments.Count > 0)
        {
            _context.Appointments.RemoveRange(expiredAppointments);
            _context.SaveChanges();
        }
    }
}
