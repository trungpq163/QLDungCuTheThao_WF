using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Controllers
{
    public interface IUnitOfWork
    {
        bool Connect(string loginName, string password);
        int SaveChanges();

        int SprocNonQuery(string spName, params object[] parameters);

        IList<T> SprocQuery<T>(string spName, params object[] parameters);

        T SprocScalar<T>(string spName, params object[] parameters);

        IRepository<T> GetRepository<T>() where T : class, new();
    }
}
