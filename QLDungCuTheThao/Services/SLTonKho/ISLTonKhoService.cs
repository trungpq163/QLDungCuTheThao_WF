using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.SLTonKho
{
    public interface ISLTonKhoService
    {
        List<SLTonKhoModel> GetSLTonKho();
    }
}
