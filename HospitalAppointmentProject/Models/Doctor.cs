using HospitalAppointmentProject.Models.Enum;

namespace HospitalAppointmentProject.Models;

public class Doctor : Entity<int>
{
    public string Name { get; set; }
    public Branch DoctorBranch { get; set; }
    public List<Appointment> Appointments { get; set; }
    
}