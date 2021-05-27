using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDungCuTheThao
{
    public sealed class WorkingContext
    {
        private static WorkingContext _instance = null;

        public static WorkingContext Instance => _instance ?? (_instance = new WorkingContext());

        private QLDungCuTheThaoContext _dbContext = null;
        private IUnitOfWork _unitOfWork;
        private string _currentConnectionString;

        public LoginModel CurrentLoginInfo { get; set; }

        public string CurrentBranch { get; set; }

        public string CurrentLoginName { get; set; }

        private WorkingContext()
        {

        }

        public void Initialize(string connectionString)
        {
            _currentConnectionString = connectionString;
            _dbContext = new QLDungCuTheThaoContext(_currentConnectionString);
            _unitOfWork = new UnitOfWork(_dbContext);
        }


        public IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }
    }
}
