using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Doctors.Request;
using HospitalAppointmentProject.Models.Enum;
using HospitalAppointmentProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        try
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("getbyid/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var doctor = _doctorService.GetDoctorById(id);
            return Ok(doctor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("add")]
    public IActionResult Add(DoctorRequestDto doctorRequestDto)
    {
        try
        {
            var doctor = _doctorService.AddDoctor(doctorRequestDto);
            return Ok(doctor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("update")]
    public IActionResult Update(Doctor doctor)
    {
        try
        {
            var updatedDoctor = _doctorService.UpdateDoctor(doctor);
            return Ok(updatedDoctor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var doctor = _doctorService.DeleteDoctor(id);
            return Ok(doctor);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("getbybranch/{branch}")]
    public IActionResult GetByBranch(Branch branch)
    {
        try
        {
            var doctors = _doctorService.GetDoctorsByBranch(branch);
            return Ok(doctors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}