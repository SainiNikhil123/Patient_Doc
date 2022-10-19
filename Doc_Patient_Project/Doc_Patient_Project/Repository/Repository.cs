using Doc_Patient_Project.Models;
using Doc_Patient_Project.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doc_Patient_Project.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly Hospital_ProjectContext _context;
        public Repository(Hospital_ProjectContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _context.Remove<T>(entity);
        }

        public void Remove(int id)
        {
            var entity = _context.Find<T>(id);
            _context.Remove<T>(entity);
        }
        public void Update(T entity)
        {
            _context.Update<T>(entity);
        }
    }
}

