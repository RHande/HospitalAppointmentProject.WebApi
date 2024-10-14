using HospitalAppointmentProject.Models;
using HospitalAppointmentProject.Models.Dtos.Appointments.Request;
using HospitalAppointmentProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        try
        {
            var appointments = _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("getbyid")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            return Ok(appointment);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("add")]
    public IActionResult Add(AppointmentRequestDto appointment)
    {
        try
        {
            var addedAppointment = _appointmentService.AddAppointment(appointment);
            return Ok(addedAppointment);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("update")]
    public IActionResult Update(Appointment appointment)
    {
        try
        {
            var updatedAppointment = _appointmentService.UpdateAppointment(appointment);
            return Ok(updatedAppointment);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("delete")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            var deletedAppointment = _appointmentService.DeleteAppointment(id);
            return Ok(deletedAppointment);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("getbydoctorid")]
    public IActionResult GetByDoctorId(int doctorId)
    {
        try
        {
            var appointments = _appointmentService.GetAppointmentsByDoctorId(doctorId);
            return Ok(appointments);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("deleteexpired")]
    public IActionResult DeleteExpired()
    {
        try
        {
            _appointmentService.DeleteExpiredAppointments();
            return Ok("Başarılı");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}