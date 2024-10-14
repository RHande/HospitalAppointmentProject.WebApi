using HospitalAppointmentProject.Models;

namespace HospitalAppointmentProject.Repositories.Abstract;

public interface IAppointmentRepository : IRepository<Appointment, Guid>
{
    List <Appointment> GetAppointmentsByDoctorId(int doctorId);
    
    void DeleteExpiredAppointments();
}