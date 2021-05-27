using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Products
{
    public class ProductsService : CrudService<Product>, IProductsService
    {
        public ProductsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IQueryable<Product> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
