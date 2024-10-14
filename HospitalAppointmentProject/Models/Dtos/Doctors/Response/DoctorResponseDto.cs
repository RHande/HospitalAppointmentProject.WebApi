namespace HospitalAppointmentProject.Models.Dtos.Doctors.Response;

public class DoctorResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DoctorBranch { get; set; }
    
    public static explicit operator DoctorResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto
        {
            Id = doctor.Id,
            Name = doctor.Name,
            DoctorBranch = doctor.DoctorBranch.ToString()
        };
    }
    
}