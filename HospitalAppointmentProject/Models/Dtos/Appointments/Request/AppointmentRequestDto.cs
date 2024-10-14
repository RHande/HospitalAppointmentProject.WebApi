namespace HospitalAppointmentProject.Models.Dtos.Appointments.Request;

public class AppointmentRequestDto
{
   public string PatientName { get; set; }
   public DateTime AppointmentDate { get; set; }
   public int DoctorId { get; set; }
   
   public static explicit operator Appointment(AppointmentRequestDto appointmentRequestDto)
   {
       return new Appointment
       {
           PatientName = appointmentRequestDto.PatientName,
           AppointmentDate = appointmentRequestDto.AppointmentDate,
           DoctorId = appointmentRequestDto.DoctorId
       };
   }
}