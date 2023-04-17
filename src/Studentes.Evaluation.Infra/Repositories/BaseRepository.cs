﻿using Studentes.Evaluation.Infra.SqlContext;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
         where TEntity : class, IEntity
    {
        private readonly Oiga_DBContext _context;

        public BaseRepository(Oiga_DBContext context)
        {
            _context = context;
        }


        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Delete(Guid id)
        {
            var entityToDelete = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public void Edit(TEntity entity)
        {
            var editedEntity = _context.Set<TEntity>().Where(e => e.Id == entity.Id).FirstOrDefault();
            editedEntity = entity;
            _context.Set<TEntity>().Update(editedEntity);
            _context.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> Filter()
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
        public void SaveChanges() => _context.SaveChanges();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
