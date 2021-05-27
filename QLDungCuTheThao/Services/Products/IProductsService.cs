using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.Products
{
    public interface IProductsService : ICrudService<Product>
    {
        IQueryable<Product> GetAll();
    }
}
