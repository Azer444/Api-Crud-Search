﻿using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        } 

        public async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<List<T>> GetAll()
        {
            return  await _entities.ToListAsync();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }


        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
