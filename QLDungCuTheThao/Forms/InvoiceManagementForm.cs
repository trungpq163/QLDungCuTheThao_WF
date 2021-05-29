using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.GetAllBillDetail;
using QLDungCuTheThao.Services.GetAllNhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDungCuTheThao.Forms
{
    public partial class InvoiceManagementForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private IGetAllBillDetailService _allBillDetail;
        private IGetAllNhanVienService _allEmployeeService;

        public InvoiceManagementForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _allBillDetail = new GetAllBillDetailService(_unitOfWork);
            _allEmployeeService =  new GetAllNhanVienService(_unitOfWork);

            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            AdminForm adminForm = new AdminForm(_unitOfWork, employeeProfile);
            this.Hide();
            adminForm.ShowDialog();
            this.Close();
        }

        private void InvoiceManagementForm_Load(object sender, EventArgs e)
        {
            LoadAllBillData();
        }

        private void SearchAllBillData(List<GetAllBillDetailModel> allbill)
        {
            decimal myDec;
            if (decimal.TryParse(txtSearch.Text, out myDec))
            {
                dgvDSHoaDon.DataSource = allbill.Where(x => x.ID.ToString() == txtSearch.Text).ToList();
                return;
            }

            if (txtSearch.Text == "")
            {
                dgvDSHoaDon.DataSource = allbill;
                return;
            }
            dgvDSHoaDon.DataSource = allbill.Where(x => Utils.RemoveDiacritics(x.Customer.ToLower()).Contains(Utils.RemoveDiacritics(txtSearch.Text))).ToList();
        }

        private void LoadAllBillData()
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);
            int branchID = 0;

            if (employeeProfile.Position.ToString() == "Quản lý chi nhánh")
            {
                cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
                cbbBranch.Enabled = false;

                if (cbbBranch.Text == "Bùi Thị Xuân")
                {
                    branchID = 1;
                }

                if (cbbBranch.Text == "Hòa Bình")
                {
                    branchID = 2;
                }

                var data = _allBillDetail.getAllBillDetail().FindAll(x => x.Branch == branchID);
                SearchAllBillData(data);
            } else
            {
                if (cbbBranch.Text == "Bùi Thị Xuân")
                {
                    branchID = 1;
                }

                if (cbbBranch.Text == "Hòa Bình")
                {
                    branchID = 2;
                }

                if (branchID == 0)
                {
                    cbbBranch.Text = "Bùi Thị Xuân";
                    var data = _allBillDetail.getAllBillDetail().FindAll(x => x.Branch == 1);
                    SearchAllBillData(data);
                }
                else
                {
                    var data = _allBillDetail.getAllBillDetail().FindAll(x => x.Branch == branchID);
                    SearchAllBillData(data);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadAllBillData();
        }

        private void cbbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadAllBillData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAllBillData();
        }
    }
}
