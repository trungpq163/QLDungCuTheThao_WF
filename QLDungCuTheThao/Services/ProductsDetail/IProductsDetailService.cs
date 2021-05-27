using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDungCuTheThao.Models;

namespace QLDungCuTheThao.Services.ProductsDetail
{
    public interface IProductsDetailService
    {
        List<ProductsDetailModel> GetProductsDetail();
    }
}
