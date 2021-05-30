using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.TopMatHangBanChay
{
    public interface ITopMatHangBanChayService
    {
        List<TopMatHangBanChayModel> getAllMatHangBanChay(string start, string end);
    }
}
