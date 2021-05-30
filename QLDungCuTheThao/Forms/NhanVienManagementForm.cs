using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.NhanVienBanMatHangNhieuNhat;
using QLDungCuTheThao.Services.NhanVienKhongBanDuocHang;
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
    public partial class NhanVienManagementForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private INhanVienKhongBanDuocHangService _nhanvienKhongBanDuocHangService;
        private INhanVienBanMatHangNhieuNhatService _nhanvienBanDuocNhieuHangService;

        public NhanVienManagementForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _nhanvienKhongBanDuocHangService = new NhanVienKhongBanDuocHangService(_unitOfWork);
            _nhanvienBanDuocNhieuHangService = new NhanVienBanMatHangNhieuNhatService(_unitOfWork);

            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NhanVienKhongBanDuocHangForm_Load(object sender, EventArgs e)
        {
            DSNhanvienKoBanDuocHangData_Load();
            DSNhanvienBanNhieuHangNhatData_Load();
        }

        private void DSNhanvienKoBanDuocHangData_Load()
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);
            int branchID = 0;

            string start = dateStart_TopNVKoBanDuoc.Value.ToString();
            string end = dateEnd_TopNVKoBanDuoc.Value.ToString();
            try
            {
                if (employeeProfile.Position.ToString() == "Quản lý chi nhánh")
                {
                    cbbBranch_2.Text = WorkingContext.Instance.CurrentBranch;
                    cbbBranch_2.Enabled = false;

                    if (cbbBranch_2.Text == "Bùi Thị Xuân")
                    {
                        branchID = 1;
                    }

                    if (cbbBranch_2.Text == "Hòa Bình")
                    {
                        branchID = 2;
                    }

                    var data = _nhanvienKhongBanDuocHangService.getAllNhanVienKhongBanDuocHang(start, end).FindAll(x => x.Branch == branchID);
                    dgv_DSNVKoBanDuocHang.DataSource = data;

                } else
                {
                    if (cbbBranch_2.Text == "Bùi Thị Xuân")
                    {
                        branchID = 1;
                    }

                    if (cbbBranch_2.Text == "Hòa Bình")
                    {
                        branchID = 2;
                    }

                    if (branchID == 0)
                    {
                        cbbBranch_2.Text = "Bùi Thị Xuân";
                        var data = _nhanvienKhongBanDuocHangService.getAllNhanVienKhongBanDuocHang(start, end).FindAll(x => x.Branch == 1);
                        dgv_DSNVKoBanDuocHang.DataSource = data;
                    }
                    else
                    {
                        var data = _nhanvienKhongBanDuocHangService.getAllNhanVienKhongBanDuocHang(start, end).FindAll(x => x.Branch == branchID);
                        dgv_DSNVKoBanDuocHang.DataSource = data;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
            }
        }

        private void DSNhanvienBanNhieuHangNhatData_Load()
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);
            int branchID = 0;

            string start = dateStart_TopNVBanNhieuHang.Value.ToString();
            string end = dateEnd_TopNVBanNhieuHang.Value.ToString();
            try
            {
                if (employeeProfile.Position.ToString() == "Quản lý chi nhánh")
                {
                    cbbBranch_1.Text = WorkingContext.Instance.CurrentBranch;
                    cbbBranch_1.Enabled = false;

                    if (cbbBranch_1.Text == "Bùi Thị Xuân")
                    {
                        branchID = 1;
                    }

                    if (cbbBranch_1.Text == "Hòa Bình")
                    {
                        branchID = 2;
                    }

                    var data = _nhanvienBanDuocNhieuHangService.getAllNhanVienBanDuocNhieuHangNhat(start, end).FindAll(x => x.Branch == branchID);
                    dgvTopNVBanDuocNhieuHang.DataSource = data;

                }
                else
                {
                    if (cbbBranch_1.Text == "Bùi Thị Xuân")
                    {
                        branchID = 1;
                    }

                    if (cbbBranch_1.Text == "Hòa Bình")
                    {
                        branchID = 2;
                    }

                    if (branchID == 0)
                    {
                        cbbBranch_1.Text = "Bùi Thị Xuân";
                        var data = _nhanvienBanDuocNhieuHangService.getAllNhanVienBanDuocNhieuHangNhat(start, end).FindAll(x => x.Branch == 1);
                        dgvTopNVBanDuocNhieuHang.DataSource = data;
                    }
                    else
                    {
                        var data = _nhanvienBanDuocNhieuHangService.getAllNhanVienBanDuocNhieuHangNhat(start, end).FindAll(x => x.Branch == branchID);
                        dgvTopNVBanDuocNhieuHang.DataSource = data;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            AdminForm adminForm = new AdminForm(_unitOfWork, employeeProfile);
            this.Hide();
            adminForm.ShowDialog();
            this.Close();
        }

        private void dateStart_TopNVBanNhieuHang_ValueChanged(object sender, EventArgs e)
        {
            DSNhanvienBanNhieuHangNhatData_Load();
        }

        private void dateEnd_TopNVBanNhieuHang_ValueChanged(object sender, EventArgs e)
        {
            DSNhanvienBanNhieuHangNhatData_Load();
        }

        private void btnReload1_Click(object sender, EventArgs e)
        {
            DSNhanvienBanNhieuHangNhatData_Load();
        }

        private void dateStart_TopNVKoBanDuoc_ValueChanged(object sender, EventArgs e)
        {
            DSNhanvienKoBanDuocHangData_Load();
        }

        private void dateEnd_TopNVKoBanDuoc_ValueChanged(object sender, EventArgs e)
        {
            DSNhanvienKoBanDuocHangData_Load();
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            DSNhanvienKoBanDuocHangData_Load();
        }

        private void cbbBranch_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DSNhanvienKoBanDuocHangData_Load();
        }

        private void cbbBranch_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DSNhanvienBanNhieuHangNhatData_Load();
        }
    }
}
