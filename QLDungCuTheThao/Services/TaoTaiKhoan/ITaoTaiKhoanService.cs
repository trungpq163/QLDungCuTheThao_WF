using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.TaoTaiKhoan
{
    public interface ITaoTaiKhoanService
    {
        ResultModel TaoTaiKhoan(string loginName, string password, string username, string role);
    }
}
