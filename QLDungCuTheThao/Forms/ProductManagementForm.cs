using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.ProductCategories;
using QLDungCuTheThao.Services.ThemSanPham;
using QLDungCuTheThao.Services.XemTatCaSP;
using QLDungCuTheThao.Services.XoaSanPham;
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
    public partial class ProductManagementForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private IXemTatCaSPService _xemTatCaSPService;
        private IProductCategoryService _productCategoryService;
        private IThemSanPhamService _themSPService;
        private IXoaSanPhamService _xoaSPService;

        private string _name = "";
        private int _price = 0;
        private int _productCategory = 0;
        private string _manufacturer = "";
        private int _id = 0;

        public ProductManagementForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _xemTatCaSPService = new XemTatCaSPService(_unitOfWork);
            _productCategoryService = new ProductCategoryService(_unitOfWork);
            _themSPService = new ThemSanPhamService(_unitOfWork);
            _xoaSPService = new XoaSanPhamService(_unitOfWork);

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

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            ProductData_Load();
            CbbProductCategory_Load();
        }

        private void CbbProductCategory_Load()
        {
            var dataProductCategory = _productCategoryService.GetAll().ToList();
            cbbDanhMucSP.DataSource = dataProductCategory;
            cbbDanhMucSP.DisplayMember = "Name";
            cbbDanhMucSP.ValueMember = "ID";
        }

        private void ProductData_Load()
        {
            decimal myDec;
            var data = _xemTatCaSPService.TatCaSP();

            if (decimal.TryParse(txtSearch.Text, out myDec))
            {
                dgvDSSP.DataSource = data.Where(x => x.ID.ToString() == txtSearch.Text).ToList();
                return;
            }

            if (txtSearch.Text == "")
            {
                dgvDSSP.DataSource = data;
                return;
            }
            dgvDSSP.DataSource = data.Where(x => Utils.RemoveDiacritics(x.Name.ToLower()).Contains(Utils.RemoveDiacritics(txtSearch.Text))).ToList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ProductData_Load();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ProductData_Load();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (txtTenSP.Text.ToString() == "" || txtGia.Text.ToString() == "" || cbbDanhMucSP.SelectedValue.ToString() == "" || txtNhaSX.Text.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin!");
                return;
            }

            if (employeeProfile.Position.ToString() == "Giám đốc chi nhánh")
            {
                MessageBox.Show("Bạn phải là quản lý mới có thể thực hiện tác vụ này!");
                return;
            } 

            if (employeeProfile.Position.ToString() == "Quản lý chi nhánh")
            {
                try
                {
                    _name = txtTenSP.Text.ToString();
                    _price = Int32.Parse(txtGia.Text.ToString());
                    _productCategory = Int32.Parse(cbbDanhMucSP.SelectedValue.ToString());
                    _manufacturer = txtNhaSX.Text.ToString();

                    var themSP = _themSPService.ThemSanPham(_name, _price, _productCategory, _manufacturer);
                    if (themSP.Result == 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra, Thêm sản phẩm thất bại!");
                        return;
                    }

                    if (themSP.Result == 1)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công! ^^");
                        ProductData_Load();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi" + ex.Message.ToString());
                }
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvDSSP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = dgvDSSP.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Xóa sản phẩm này!", ShowDialogForSure100Percent));
                }
                m.Show(dgvDSSP, new Point(e.X, e.Y));
            }
        }

        private void ShowDialogForSure100Percent(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (employeeProfile.Position.ToString() == "Quản lý chi nhánh")
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắc không?");

                if (dialog == DialogResult.Cancel)
                {
                    MessageBox.Show("Cancel thanh cong! ^^");
                    return;
                }

                if (dialog == DialogResult.OK)
                {
                    MenuItem_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải là Quản lý chi nhánh mới có thể thực hiện hành động này!");
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Vui lòng chọn tất cả hàng thuộc nhân viên đó, trước khi thực hiện tác vụ này!");
                return;
            }

            try
            {
                var xoaSP = _xoaSPService.XoaSanPham(_id);
                if (xoaSP.Result == 0)
                {
                    MessageBox.Show("Không xóa được sản phẩm này!");
                    return;
                }

                if (xoaSP.Result == 1)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    ProductData_Load();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
            }
        }

        private void dgvDSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSSP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDSSP.CurrentRow.Selected = true;
                _id = Int32.Parse(dgvDSSP.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
            }
        }
    }
}
