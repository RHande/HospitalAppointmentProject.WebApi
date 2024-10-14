using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Enum;

namespace HospitalAppointmentProject.Repositories.Abstract;

public interface IDoctorRepository : IRepository<Doctor, int>
{
    List<Doctor> GetDoctorsByBranch(Branch branch);
}