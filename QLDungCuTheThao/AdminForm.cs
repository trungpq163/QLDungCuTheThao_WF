using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.GetAllNhanVien;
using QLDungCuTheThao.Services.TaoTaiKhoan;
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

        public AdminForm(IUnitOfWork unitOfWork, Employee employeeProfile)
        {
            _unitOfWork = unitOfWork;
            _employeeProfile = employeeProfile;
            _allEmployeeService = new GetAllNhanVienService(_unitOfWork);
            _taoTaiKhoan = new TaoTaiKhoanService(_unitOfWork);
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
                Employee_Data_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi load data tu database \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void Employee_Data_Load()
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

                var allEmployeeData = _allEmployeeService.getAllNhanVien().ToList().FindAll(x => x.Branch == branchID);
                dgvEmployees.DataSource = allEmployeeData;
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
                    var allEmployeeData = _allEmployeeService.getAllNhanVien().ToList().FindAll(x => x.Branch == 1);
                    dgvEmployees.DataSource = allEmployeeData;
                } else
                {
                    var allEmployeeData = _allEmployeeService.getAllNhanVien().ToList().FindAll(x => x.Branch == branchID);
                    dgvEmployees.DataSource = allEmployeeData;
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
            Employee_Data_Load();
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
            } catch (Exception ex)
            {
                MessageBox.Show("Co loi xay ra " + ex.Message.ToString());
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
                    m.MenuItems.Add(new MenuItem("Chuyển nhân viên này sang chi nhánh " + moveBranch, MenuItem_Click));
                }

                m.Show(dgvEmployees, new Point(e.X, e.Y));
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tất cả hàng thuộc nhân viên đó, trước khi thực hiện tác vụ này!");
                return;
            }
        }
    }
}
