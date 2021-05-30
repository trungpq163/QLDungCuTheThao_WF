using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Common;

namespace QLDungCuTheThao.Services.ProductCategories
{
    public class ProductCategoryService : CrudService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IQueryable<ProductCategory> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
