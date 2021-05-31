using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.SLHangDaBanDoanhThu;
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
    public partial class SLHangDaBanDoanhThuForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private ISLHangDaBanDoanhThuService _slVaDanhThuService;

        public SLHangDaBanDoanhThuForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _slVaDanhThuService = new SLHangDaBanDoanhThuService(_unitOfWork);
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

        private void SLHangDaBanDoanhThuForm_Load(object sender, EventArgs e)
        {
            SLHangDaBanDoanhThuData_Load();
        }

        private void SLHangDaBanDoanhThuData_Load()
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);
            int branchID = 0;

            string start = datePickerStart.Value.ToString();
            string end = datePickerEnd.Value.ToString();

            try
            {
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

                    var data = _slVaDanhThuService.GetSLHangDaBanDoanhThu(start, end).Find(x => x.ID == branchID);
                    lbDoanhThu.Text = data.DoanhThu.ToString();
                    lbSLHangDaBan.Text = data.SLHangDaBan.ToString();
                }
                else
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
                        var data = _slVaDanhThuService.GetSLHangDaBanDoanhThu(start, end).Find(x => x.ID == 1);
                        lbDoanhThu.Text = data.DoanhThu.ToString();
                        lbSLHangDaBan.Text = data.SLHangDaBan.ToString();
                    }
                    else
                    {
                        var data = _slVaDanhThuService.GetSLHangDaBanDoanhThu(start, end).Find(x => x.ID == branchID);
                        lbDoanhThu.Text = data.DoanhThu.ToString();
                        lbSLHangDaBan.Text = data.SLHangDaBan.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
            }
        }

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            SLHangDaBanDoanhThuData_Load();
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            SLHangDaBanDoanhThuData_Load();
        }

        private void cbbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SLHangDaBanDoanhThuData_Load();
        }
    }
}
