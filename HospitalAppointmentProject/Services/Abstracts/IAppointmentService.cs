using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Appointments.Request;
using HospitalAppointmentProject.Models.Dtos.Appointments.Response;

namespace HospitalAppointmentProject.Services.Abstracts;

public interface IAppointmentService
{
   Appointment? GetAppointmentById(Guid id);
   List<AppointmentResponseDto> GetAllAppointments();
   Appointment AddAppointment(AppointmentRequestDto appointment);
   Appointment UpdateAppointment(Appointment user);
   Appointment DeleteAppointment(Guid id);
   List<Appointment> GetAppointmentsByDoctorId(int doctorId);
   void DeleteExpiredAppointments();
}