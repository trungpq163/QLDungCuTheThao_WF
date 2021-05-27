using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ProductsDetail
{
    public class ProductsDetailService : CrudService<ProductsDetailModel>, IProductsDetailService
    {
        public ProductsDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<ProductsDetailModel> GetProductsDetail()
        {
            return _unitOfWork.SprocQuery<ProductsDetailModel>("sp_ChitietTatCaSP", new object[] { }).ToList();
        }
    }
}
