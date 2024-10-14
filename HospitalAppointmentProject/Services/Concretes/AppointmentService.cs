using HospitalAppointmentProject.Exceptions;
using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Appointments.Request;
using HospitalAppointmentProject.Models.Dtos.Appointments.Response;
using HospitalAppointmentProject.Repositories.Abstract;
using HospitalAppointmentProject.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalAppointmentProject.Services.Concretes;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private  readonly IDoctorRepository _doctorRepository;
    
    public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
    }
   

    
    public Appointment AddAppointment(AppointmentRequestDto appointmentRequestDto)
    {
        try
        {
            Appointment appointment = (Appointment)appointmentRequestDto;
            ValidateDoctorExist(appointment.DoctorId);
            ValidateAppointmentDate(appointment.AppointmentDate);
            ValidatePatientName(appointment.PatientName);
            ValidateDoctorAppointmentCount(appointment.DoctorId);
            
            return _appointmentRepository.Add(appointment);
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Message);
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException(e.Message);
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException(e.Message);
        }
        catch (Exception e)
        {
            throw new Exception($"Beklenmedik bir hata oluştu: {e.Message}");
        }
    }
    

    //Randevu için doktorun seçilmesini sağlayan validation:
    private void ValidateDoctorExist(int doctorId)
    {
        if (_doctorRepository.GetById(doctorId) == null)
        {
            throw new NotFoundException("Randevu için geçerli bir doktor seçiniz.");
        }
    }
    
    //Randevu tarihinin en az 3 gün sonra olmasına dair validation:
    private void ValidateAppointmentDate(DateTime appointmentDate)
    {
        if(appointmentDate < DateTime.Now.AddDays(3))
        {
            throw new ValidationException("Randevu tarihi en az 3 gün sonra olmalıdır.");
        }
    }
    
    //Randevu için hastanın adının girilmesini sağlayan validation:
    private void ValidatePatientName(string appointmentPatientName)
    {
        if(string.IsNullOrWhiteSpace(appointmentPatientName) || string.IsNullOrEmpty(appointmentPatientName))
        {
            throw new ValidationException("Randevu için hastanın adını giriniz.");
        }
    }
    
    //Bir doktorun max 10 hastası olabilir. Buna dair validation:
    private void ValidateDoctorAppointmentCount(int appointmentDoctorId)
    {
        if (_appointmentRepository.GetAppointmentsByDoctorId(appointmentDoctorId).Count >= 10)
        {
            throw new InvalidOperationException("Doktorun randevu kapasitesi dolmuştur.");
        }
    }
    
     
    
    public Appointment? GetAppointmentById(Guid id)
    {
        try
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                throw new NotFoundException("Randevu bulunamadı.");
            }
            return appointment;
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
        catch (Exception e)
        {
            throw new Exception($"Randevu girilirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    
    
    public List<AppointmentResponseDto> GetAllAppointments()
    {
        try
        {
            return _appointmentRepository.GetAll().Select(x => (AppointmentResponseDto)x).ToList();
        }
        catch (Exception e)
        {
            throw new Exception($"Randevular listelenirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    
    
    public Appointment DeleteAppointment(Guid id)
    {
        try
        {
            var appointment = GetAppointmentById(id);
            if (appointment == null)
            {
                throw new NotFoundException("Randevu bulunamadı.");
            }
            return _appointmentRepository.Delete(id);
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
        catch (Exception e)
        {
            throw new Exception($"Randevu silinirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    
    public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
    {
        try
        {
            return _appointmentRepository.GetAppointmentsByDoctorId(doctorId);
        }
        catch (Exception e)
        {
            throw new Exception($"Doktor randevuları listelenirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

    //Randevu tarihi geçmiş olan randevuları silen metot:
    public void DeleteExpiredAppointments()
    {
        try
        {
            _appointmentRepository.DeleteExpiredAppointments();
        }
        catch (Exception e)
        {
            throw new Exception($"Geçmiş tarihli randevular silinirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }
    
    public Appointment UpdateAppointment(Appointment user)
    {
        try
        {
            ValidateDoctorExist(user.DoctorId);
            ValidateAppointmentDate(user.AppointmentDate);
            ValidatePatientName(user.PatientName);
            ValidateDoctorAppointmentCount(user.DoctorId);
            return _appointmentRepository.Update(user);
        }
        catch (NotFoundException e)
        {
            throw new NotFoundException(e.Message);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Message);
        }
        catch(InvalidOperationException e)
        {
            throw new InvalidOperationException(e.Message);
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException(e.Message);
        }
        catch (Exception e)
        {
            throw new Exception($"Randevu güncellenirken beklenmedik bir hata oluştu: {e.Message}");
        }
    }

}