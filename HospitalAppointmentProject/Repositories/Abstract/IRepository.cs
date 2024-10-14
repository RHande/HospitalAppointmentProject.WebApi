using HospitalAppointmentProject.Models;

namespace HospitalAppointmentProject.Repositories.Abstract;

public interface IRepository <TEntity, TId>
       where TEntity : Entity<TId>, new() 
{
    TEntity? GetById(TId id);
    List<TEntity> GetAll();
    TEntity Add(TEntity user);
    TEntity Update(TEntity user);
    TEntity Delete(TId id);
}