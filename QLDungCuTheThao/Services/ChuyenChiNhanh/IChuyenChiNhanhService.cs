using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ChuyenChiNhanh
{
    public interface IChuyenChiNhanhService
    {
        ResultModel ChuyenChiNhanh(string Branch, string ID);
    }
}
