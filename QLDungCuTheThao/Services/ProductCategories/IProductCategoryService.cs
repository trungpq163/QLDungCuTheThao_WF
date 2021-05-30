using QLDungCuTheThao.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ProductCategories
{
    public interface IProductCategoryService
    {
        IQueryable<ProductCategory> GetAll();
    }
}
