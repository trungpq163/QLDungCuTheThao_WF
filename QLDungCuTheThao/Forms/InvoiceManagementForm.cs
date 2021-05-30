using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.GetAllBillDetail;
using QLDungCuTheThao.Services.GetAllNhanVien;
using QLDungCuTheThao.Services.XoaBill;
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
        private IXoaBillService _xoaBillService;

        private int _billID = 0;

        public InvoiceManagementForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _allBillDetail = new GetAllBillDetailService(_unitOfWork);
            _allEmployeeService =  new GetAllNhanVienService(_unitOfWork);
            _xoaBillService = new XoaBillService(_unitOfWork);

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

        private void dgvDSHoaDon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = dgvDSHoaDon.HitTest(e.X, e.Y).RowIndex;


                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Xóa hóa đơn này!", ShowDialogForSure100Percent));
                }

                m.Show(dgvDSHoaDon, new Point(e.X, e.Y));
            }
        }

        private void ShowDialogForSure100Percent(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (employeeProfile.Position.ToString() == "Giám đốc chi nhánh")
            {
                MessageBox.Show("Bạn phải là Quản Lý mới có thể thực hiện tác vụ này!");
                return;
            }

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắc không?");

            if (dialog == DialogResult.Cancel)
            {
                MessageBox.Show("Cancel thanh cong! ^^");
                return;
            }

            if (dialog == DialogResult.OK)
            {
                MenuItem_DeleteBill_Click(sender, e);
            }
        }

        private void MenuItem_DeleteBill_Click(object sender, EventArgs e)
        {
            if (_billID == 0)
            {
                MessageBox.Show("Vui lòng chọn tất cả hàng thuộc hóa đơn đó, trước khi thực hiện tác vụ này!");
                return;
            }

            try
            {
                var xoaBill = _xoaBillService.XoaBill(_billID);
                if (xoaBill.Result == 0)
                {
                    MessageBox.Show("Xóa bill thất bại!");
                    return;
                }

                if (xoaBill.Result == 1)
                {
                    MessageBox.Show("Xóa bill thành công! ^^");
                    LoadAllBillData();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
                return;
            }
        }

        private void dgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDSHoaDon.CurrentRow.Selected = true;

                _billID = Int32.Parse(dgvDSHoaDon.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
            }
        }
    }
}
