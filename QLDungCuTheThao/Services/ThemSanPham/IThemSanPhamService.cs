using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ThemSanPham
{
    public interface IThemSanPhamService
    {
        ResultModel ThemSanPham(string name, int price, int productCategory, string manufacturer);
    }
}
