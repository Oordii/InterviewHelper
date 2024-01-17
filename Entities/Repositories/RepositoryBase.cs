using Entities.Models;
using Entities.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly InterviewDbContext _context;

        public RepositoryBase(InterviewDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public void Update(T entity) 
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
