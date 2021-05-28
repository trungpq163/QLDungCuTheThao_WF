using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.XoaTaiKhoan
{
    public interface IXoaTaiKhoanService
    {
        ResultModel XoaTaiKhoan(string loginName, string id);
    }
}
