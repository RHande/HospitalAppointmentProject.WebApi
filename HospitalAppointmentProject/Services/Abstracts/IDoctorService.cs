using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Doctors.Request;
using HospitalAppointmentProject.Models.Dtos.Doctors.Response;
using HospitalAppointmentProject.Models.Enum;
using HospitalAppointmentProject.Models.Return;

namespace HospitalAppointmentProject.Services.Abstracts;

public interface IDoctorService
{
    Doctor? GetDoctorById(int id);
    ReturnModel<List<DoctorResponseDto>> GetAllDoctors();
    Doctor AddDoctor(DoctorRequestDto doctorRequestDto);
    Doctor UpdateDoctor(Doctor user);
    Doctor DeleteDoctor(int id);
    List<Doctor> GetDoctorsByBranch(Branch branch);
}