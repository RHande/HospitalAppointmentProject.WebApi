using HospitalAppointmentProject.Exceptions;
using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Doctors.Request;
using HospitalAppointmentProject.Models.Dtos.Doctors.Response;
using HospitalAppointmentProject.Models.Enum;
using HospitalAppointmentProject.Models.Return;
using HospitalAppointmentProject.Repositories.Abstract;
using HospitalAppointmentProject.Services.Abstracts;
using System;

namespace HospitalAppointmentProject.Services.Concretes;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    
    public Doctor AddDoctor(DoctorRequestDto doctorRequestDto)
    {
        try
        {
            Doctor doctor = (Doctor)doctorRequestDto;
            ValidateDoctorName(doctorRequestDto.Name);
            return _doctorRepository.Add(doctor);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Message);
        }
        catch(Exception e)
        {
            throw new Exception($"Doktor eklenirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    //Randevu alınırken doktorun adı kontrol edilir:
    private void ValidateDoctorName(string name)
    {
        if(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Doktor adı boş bırakılamaz.");
        }
    }


    
    public Doctor? GetDoctorById(int id)
    {
        try
        {
            var doctor = _doctorRepository.GetById(id);
            if(doctor == null)
            {
                throw new Exception("Doktor bulunamadı.");
            }
            return doctor;
        }
        catch(Exception e)
        {
            throw new Exception($"Doktor getirilirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    public ReturnModel<List<DoctorResponseDto>> GetAllDoctors()
    {
        try
        {
            var doctors = _doctorRepository.GetAll();
            if(doctors == null)
            {
                throw new Exception("Doktor bulunamadı.");
            }
            return new ReturnModel<List<DoctorResponseDto>>(true, "Doktorlar başarıyla getirildi.", doctors.Select(x => (DoctorResponseDto)x).ToList());
        }
        catch(Exception e)
        {
            throw new Exception($"Doktorlar getirilirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }
    
    

    public Doctor DeleteDoctor(int id)
    {
        try
        {
            return _doctorRepository.Delete(id);
        }
        catch(Exception e)
        {
            throw new Exception($"Doktor silinirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    public List<Doctor> GetDoctorsByBranch(Branch branch)
    {
        try
        {
            return _doctorRepository.GetDoctorsByBranch(branch);
        }
        catch(Exception e)
        {
            throw new Exception($"Branşa ait doktor getirilirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }
    
    public Doctor UpdateDoctor(Doctor user)
    {
        try
        {
            ValidateDoctorName(user.Name);
            return _doctorRepository.Update(user);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Message);
        }
        catch(Exception e)
        {
            throw new Exception($"Doktor güncellenirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }
}