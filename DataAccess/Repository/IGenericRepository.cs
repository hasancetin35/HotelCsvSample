using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T Add(T model);

        T Delete(T model);

        T GetById(int id);

        List<T> GetAll();

        T Update(int d, T model);

    }
}
