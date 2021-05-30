using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Forms;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.ChuyenChiNhanh;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.GetAllNhanVien;
using QLDungCuTheThao.Services.TaoTaiKhoan;
using QLDungCuTheThao.Services.XoaTaiKhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDungCuTheThao
{
    public partial class AdminForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private Employee _employeeProfile;
        private IGetAllNhanVienService _allEmployeeService;
        private ITaoTaiKhoanService _taoTaiKhoan;
        private IXoaTaiKhoanService _xoaTaiKhoan;
        private IChuyenChiNhanhService _chuyenChiNhanh;

        public AdminForm(IUnitOfWork unitOfWork, Employee employeeProfile)
        {
            _unitOfWork = unitOfWork;
            _employeeProfile = employeeProfile;
            _allEmployeeService = new GetAllNhanVienService(_unitOfWork);
            _taoTaiKhoan = new TaoTaiKhoanService(_unitOfWork);
            _chuyenChiNhanh = new ChuyenChiNhanhService(_unitOfWork);
            _xoaTaiKhoan = new XoaTaiKhoanService(_unitOfWork);
            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                var allEmployeeData = _allEmployeeService.getAllNhanVien().ToList();
                var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
                Employee_Data_Load(allEmployeeData2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi load data tu database \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void Employee_Data_Load(List<GetAllNhanVienModel> listNhanVien)
        {
            int branchID = 0;

            if (_employeeProfile.Position.ToString() == "Quản lý chi nhánh")
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

                dgvEmployees.DataSource = listNhanVien.FindAll(x => x.Branch == branchID);
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
                    dgvEmployees.DataSource = listNhanVien.FindAll(x => x.Branch == 1); 
                } else
                {
                    dgvEmployees.DataSource = listNhanVien.FindAll(x => x.Branch == branchID);
                }
            }            
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(_unitOfWork);
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void cbbBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
            Employee_Data_Load(allEmployeeData2);
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvEmployees.CurrentRow.Selected = true;

                string branchId = dgvEmployees.Rows[e.RowIndex].Cells["Branch"].FormattedValue.ToString();
                string fullName = dgvEmployees.Rows[e.RowIndex].Cells["FullName"].FormattedValue.ToString();

                string id = dgvEmployees.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                string position = dgvEmployees.Rows[e.RowIndex].Cells["Position"].FormattedValue.ToString();

                if (branchId == "1")
                {
                    txtBranch.Text = "Bùi Thị Xuân";
                }

                if (branchId == "2")
                {
                    txtBranch.Text = "Hòa Bình";
                }

                string username = Utils.FullNameToUserName(Utils.RemoveDiacritics(fullName));
               
                txtLoginName.Text = username;
                txtID.Text = id;
                txtPosition.Text = position;
            }
         }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_employeeProfile.Position.ToString() == "Quản lý chi nhánh")
            {
                string role = "";
                string loginName = txtLoginName.Text;
                string password = txtPassword.Text;
                string usernameId = txtID.Text;

                if (password == "")
                {
                    MessageBox.Show("Vui long nhap mat khau");
                    return;
                }

                if (txtPosition.Text == "Nhân viên bán hàng")
                {
                    role = "NHANVIEN";
                }

                if (txtPosition.Text == "Quản lý chi nhánh")
                {
                    role = "QLCHINHANH";
                }

                if (txtPosition.Text == "Giám đốc chi nhánh")
                {
                    role = "GIAMDOC";
                }

                try
                {
                    var result = _taoTaiKhoan.TaoTaiKhoan(loginName, password, usernameId, role);
                    if (result.Result == 1)
                    {
                        MessageBox.Show("LGNAME bi trung");
                    }

                    if (result.Result == 2)
                    {
                        MessageBox.Show("Nhan vien nay da duoc tao tai khoan");
                    }

                    if (result.Result == 0)
                    {
                        MessageBox.Show("Tao tai khoan thanh cong ^^");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Co loi xay ra " + ex.Message.ToString());
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn phải là Quản lý chi nhánh mới có thể thực hiện hành động này!");
                return;
            }
        }

        private void dgvEmployees_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                string moveBranch = "";

                if (WorkingContext.Instance.CurrentBranch == "Bùi Thị Xuân")
                {
                    moveBranch = "Hòa Bình";
                }

                if (WorkingContext.Instance.CurrentBranch == "Hòa Bình")
                {
                    moveBranch = "Bùi Thị Xuân";
                }

                int currentMouseOverRow = dgvEmployees.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Chuyển nhân viên này sang chi nhánh " + moveBranch, ShowDialogForSure100Percent));
                }

                m.Show(dgvEmployees, new Point(e.X, e.Y));
            }
        }

        private void ShowDialogForSure100Percent(object sender, EventArgs e)
        {
            if (_employeeProfile.Position.ToString() == "Quản lý chi nhánh")
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắc không? Sau khi chuyển sang chi nhánh mới, tài khoản đăng nhập của người này sẽ bị xóa");

                if (dialog == DialogResult.Cancel)
                {
                    MessageBox.Show("Cancel thanh cong! ^^");
                    return;
                }

                if (dialog == DialogResult.OK)
                {
                    MenuItem_Click(sender, e);
                }
            } else
            {
                MessageBox.Show("Bạn phải là Quản lý chi nhánh mới có thể thực hiện hành động này!");
            }
            
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            string moveBranchId = "";

            if (txtID.Text == "" || txtBranch.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tất cả hàng thuộc nhân viên đó, trước khi thực hiện tác vụ này!");
                return;
            }

            if (txtBranch.Text == "Bùi Thị Xuân")
            {
                moveBranchId = "2";
            }

            if (txtBranch.Text == "Hòa Bình")
            {
                moveBranchId = "1";
            }

            try
            {
                var chuyenChiNhanh = _chuyenChiNhanh.ChuyenChiNhanh(moveBranchId, txtID.Text);
                var xoaTaiKhoan = _xoaTaiKhoan.XoaTaiKhoan(txtLoginName.Text, txtID.Text);

                if (chuyenChiNhanh.Result == 1 && xoaTaiKhoan.Result == 1)
                {
                    MessageBox.Show("Chuyen thanh cong! ^^");

                    var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
                    Employee_Data_Load(allEmployeeData2);
                    Reload();
                    return;
                } else if (chuyenChiNhanh.Result == 1 && xoaTaiKhoan.Result == 0)
                {
                    MessageBox.Show("Chuyen thanh cong! ^^");

                    var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
                    Employee_Data_Load(allEmployeeData2);
                    Reload();
                    return;
                } else
                {
                    MessageBox.Show("Chuyen that bai! ^^");

                    var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
                    Employee_Data_Load(allEmployeeData2);
                    Reload();
                    return;
                }

            } catch (Exception ex)
            {
                MessageBox.Show("Co loi xay ra" + ex.Message.ToString());
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            var allEmployeeData2 = new GetAllNhanVienService(_unitOfWork).getAllNhanVien().ToList();
            Employee_Data_Load(allEmployeeData2);
            Reload();
        }

        private void Reload()
        {
            this.Refresh();
            Application.DoEvents();
        }



        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductManagementForm form = new ProductManagementForm(_unitOfWork);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceManagementForm form = new InvoiceManagementForm(_unitOfWork);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void BestSellingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMatHangBanChayForm form = new TopMatHangBanChayForm(_unitOfWork);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
