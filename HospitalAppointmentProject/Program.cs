using HospitalAppointmentProject.Repositories.Abstract;
using HospitalAppointmentProject.Repositories.Concretes;
using HospitalAppointmentProject.Services.Abstracts;
using HospitalAppointmentProject.Services.Concretes;
using Microsoft.EntityFrameworkCore;
using HospitalAppointmentProject.Context;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<MsSqlContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();



