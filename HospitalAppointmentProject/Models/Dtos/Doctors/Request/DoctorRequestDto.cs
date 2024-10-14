using HospitalAppointmentProject.Models.Enum;

namespace HospitalAppointmentProject.Models.Dtos.Doctors.Request;

public class DoctorRequestDto
{
    public string Name { get; set; }
    public Branch DoctorBranch { get; set; }
    
    public static explicit operator Doctor(DoctorRequestDto doctorRequestDto)
    {
        return new Doctor
        {
            Name = doctorRequestDto.Name,
            DoctorBranch = doctorRequestDto.DoctorBranch
        };
    }
}