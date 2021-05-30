using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ThemSanPham
{
    public class ThemSanPhamService : CrudService<ResultModel>, IThemSanPhamService
    {
        public ThemSanPhamService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultModel ThemSanPham(string name, int price, int productCategory, string manufacturer)
        {
            return _unitOfWork.SprocQuery<ResultModel>("sp_TaoSP", new object[] { name, price, productCategory, manufacturer }).FirstOrDefault();
        }
    }
}
