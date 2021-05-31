using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.SLHangDaBanDoanhThu
{
    public interface ISLHangDaBanDoanhThuService
    {
        List<SLHangDaBanDoanhThuModel> GetSLHangDaBanDoanhThu(string start, string end);
    }
}
