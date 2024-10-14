namespace HospitalAppointmentProject.Models.Dtos.Appointments.Response;

public class AppointmentResponseDto
{
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    
    public static explicit operator AppointmentResponseDto(Appointment appointment)
    {
        return new AppointmentResponseDto
        {
            PatientName = appointment.PatientName,
            AppointmentDate = appointment.AppointmentDate,
            DoctorId = appointment.DoctorId
        };
    }
}