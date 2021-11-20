using HiringSonda.Domain.Interfaces;
using HiringSonda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringSonda.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Context.Context DB;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(Context.Context db)
        {
            DB = db;
            dbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            DB?.Dispose();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await DB.SaveChangesAsync();
        }
    }
}
