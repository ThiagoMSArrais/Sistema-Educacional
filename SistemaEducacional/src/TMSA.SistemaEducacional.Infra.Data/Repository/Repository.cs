using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Interfaces;
using TMSA.SistemaEducacional.Infra.Data.Context;

namespace TMSA.SistemaEducacional.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected SistemaEducacionalContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(SistemaEducacionalContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}