using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Controllers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public int SprocNonQuery(string spName, params object[] parameters)
        {
            // EXEC TenThuTuc @p0, @p1, @p2
            var command = BuildCommand(spName, parameters);
            return _context.Database.ExecuteSqlCommand(command, parameters);
        }

        public IList<T> SprocQuery<T>(string spName, params object[] parameters)
        {
            var command = BuildCommand(spName, parameters);
            return _context.Database.SqlQuery<T>(command, parameters).ToList();
        }

        public T SprocScalar<T>(string spName, params object[] parameters)
        {
            var command = BuildCommand(spName, parameters);
            return _context.Database.SqlQuery<T>(command, parameters).SingleOrDefault();
        }

        private string BuildCommand(string spName, params object[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return $"EXEC {spName}";
            }

            var paramList = string.Join(", ", parameters.Select((item, idx) => $"@p{idx}"));
            return $"EXEC {spName} {paramList}";
        }

        public bool Connect(string loginName, string password)
        {
            // _context.Database
            return false;
        }
    }
}
