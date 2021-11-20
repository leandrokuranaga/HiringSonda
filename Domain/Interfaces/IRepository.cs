using HiringSonda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringSonda.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
