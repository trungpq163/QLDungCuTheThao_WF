using QLDungCuTheThao.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Common
{
    public abstract class CrudService<T> : ICrudService<T> where T : class, new()
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public CrudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T>();
        }

        public virtual T Delete(int id)
        {
            T temp = _repository.Delete(id);
            if (temp != null)
                _unitOfWork.SaveChanges();
            return temp;
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Insert(T entity)
        {
            _repository.Insert(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
