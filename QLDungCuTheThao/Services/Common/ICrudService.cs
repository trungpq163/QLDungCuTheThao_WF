using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Common
{
    public interface ICrudService<T> where T : class, new()
    {
        void Insert(T entity);

        void Update(T entity);

        T Delete(int id);

        void Delete(T entity);

        T GetById(int id);
    }
}
