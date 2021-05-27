using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao.Services.GetAllNhanVien
{
    public class GetAllNhanVienService : CrudService<GetAllNhanVienModel>, IGetAllNhanVienService
    {
        public GetAllNhanVienService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<GetAllNhanVienModel> getAllNhanVien()
        {
            return _unitOfWork.SprocQuery<GetAllNhanVienModel>("sp_GetAllNhanVien", new object[] { }).ToList();
        }
    }
}
