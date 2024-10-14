using HospitalAppointmentProject.Context;
using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Enum;
using HospitalAppointmentProject.Repositories.Abstract;

namespace HospitalAppointmentProject.Repositories.Concretes;

public class EfDoctorRepository : IDoctorRepository
{

    private MsSqlContext _context;
    public EfDoctorRepository(MsSqlContext context)
    {
        _context = context;
    }
    
    
    public Doctor? GetById(int id)
    {
        Doctor doctor = _context.Doctors.Find(id);
        return doctor;
    }

    public List<Doctor> GetAll()
    {
        List<Doctor>  doctors = _context.Doctors.ToList();
        return doctors;
    }

    public Doctor Add(Doctor user)
    {
        _context.Doctors.Add(user);
        _context.SaveChanges();
        return user;
    }

    public Doctor Update(Doctor user)
    {
        _context.Doctors.Update(user);
        _context.SaveChanges();
        return user;
    }

    public Doctor Delete(int id)
    {
        Doctor doctor = _context.Doctors.Find(id);
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return doctor;
    }

    public List<Doctor> GetDoctorsByBranch(Branch branch)
    {
        List<Doctor> doctors = _context.Doctors.Where(d => d.DoctorBranch == branch).ToList();
        return doctors;
    }
}