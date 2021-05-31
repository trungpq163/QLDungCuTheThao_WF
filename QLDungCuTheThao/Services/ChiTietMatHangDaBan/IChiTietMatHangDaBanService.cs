using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.ChiTietMatHangDaBan
{
    public interface IChiTietMatHangDaBanService
    {
        List<ChiTietMatHangDaBanModel> chiTietMatHangDaBan(string start, string end);
    }
}
