using DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly Context _context;

        private readonly DbSet<T> _dbset;



        public EfGenericRepository(Context context)
        {
            _context = context;
            _dbset = _context.Set<T>();

        }

        public T Add(T model)
        {
            var result = new T();
            _dbset.Add(model);
            _context.SaveChanges();
            result = model;
            return result;
        }

        public T Delete(T model)
        {
            var result = new T();
            _dbset.Remove(model);
            _context.SaveChanges();
            result = model;
            return result;


        }

        public List<T> GetAll()
        {
            var result = new List<T>();
            var list = _dbset.ToList();

            if (list != null)
                result = list;
            else
                result = null;

            return result;


        }



        public T GetById(int id)
        {

            var result = new T();

            result = _dbset.Find(id);

            return result;


        }

        public T Update(int id, T model)
        {
            var result = new T();

            result = _dbset.Find(id);

            if (model == null)
                return null;

            var response = _context.Entry(model);
            response.State = EntityState.Modified;

            _context.SaveChanges();
            result = response.Entity;

            return result;
        }
    


}
}
