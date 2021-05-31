using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Forms;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.Products;
using QLDungCuTheThao.Services.ProductsDetail;
using QLDungCuTheThao.Services.ThemBill;
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
    public partial class MainForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private IProductsDetailService _productsDetailService;
        private IProductsService _productsService;
        private IThemBillService _themBillService;

        private int _productDetailId = 0;
        private string _productName = "";
        private string _productDetail = "";
        private int _price = 0;
        private string _size = "";
        private int _quantity = 0;
        private int _quantityOrder = 0;
        private int _totalAmount = 0;

        DataTable dgvChiTietSPTable = new DataTable();


        public MainForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _productsDetailService = new ProductsDetailService(_unitOfWork);
            _productsService = new ProductsService(_unitOfWork);
            _themBillService = new ThemBillService(_unitOfWork);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dataEmployees = _empService.GetAll().ToList();
                var dataProductsDetail = _productsDetailService.GetProductsDetail();

                var employeeProfile = dataEmployees.Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);
                var dataProducts = _productsService.GetAll().ToList();

                loadDatagrvProducts(dataProductsDetail);
                LoadDgVBillChiTietSP();

                loadStatusStrip(employeeProfile);

                loadDataCbbProducts(dataProducts);
                loadDataCbbProductDetails(dataProductsDetail);
                LoadAutomaticBilling();
                nudQuantity.Maximum = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai thông tin đăng nhập \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void loadDataCbbProductDetails(List<ProductsDetailModel> products)
        {
            var valueCbbProducts = Utils.RemoveDiacritics(cbbItems.SelectedValue.ToString());
            var product = products.FindAll(x => Utils.RemoveDiacritics(x.Name) == valueCbbProducts).ToList();
            cbbItemDetails.DataSource = product;
            cbbItemDetails.DisplayMember = "ProductDescription";
            cbbItemDetails.ValueMember = "ID";
        }

        private void loadDataCbbProducts(List<Product> products)
        {
            cbbItems.DataSource = products;
            cbbItems.DisplayMember = "Name";
            cbbItems.ValueMember = "Name";
        }

        private void loadDatagrvProducts(List<ProductsDetailModel> products)
        {
            decimal myDec;
            if (decimal.TryParse(txtSearch.Text, out myDec))
            {
                dgvProduct.DataSource = products.Where(x => x.ID.ToString() == txtSearch.Text).ToList();
                return;
            }

            if (txtSearch.Text == "")
            {
                dgvProduct.DataSource = products;
                return;
            }
            dgvProduct.DataSource = products.Where(x => Utils.RemoveDiacritics(x.Name.ToLower()).Contains(Utils.RemoveDiacritics(txtSearch.Text))).ToList();
        }

        private void loadStatusStrip(Employee employee)
        {
            tsslLoginName.Text = "Username: " + WorkingContext.Instance.CurrentLoginName;
            tsslBranch.Text = "Branch: " + WorkingContext.Instance.CurrentBranch;
            tsslGroup.Text = "Group: " + employee.Position.ToString();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            var dataProductsDetail = _productsDetailService.GetProductsDetail();
            loadDatagrvProducts(dataProductsDetail);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var dataProductsDetail = _productsDetailService.GetProductsDetail();
            loadDatagrvProducts(dataProductsDetail);
        }

        private void accountDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm(_unitOfWork);
            this.Hide();
            accountForm.ShowDialog();
            this.Close();
        }

        private void cbbItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dataProductsDetail = _productsDetailService.GetProductsDetail();
            loadDataCbbProductDetails(dataProductsDetail);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void tsmiAdmin_Click(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (employeeProfile.Position.ToString() == "Nhân viên bán hàng")
            {
                MessageBox.Show("Bạn phải là QL hoặc Giám Đốc mới có thể được vào");
                return;
            }

            AdminForm adminForm = new AdminForm(_unitOfWork, employeeProfile);
            this.Hide();
            adminForm.ShowDialog();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvProduct.CurrentRow.Selected = true;

                _productDetailId = Int32.Parse(dgvProduct.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                _productName = dgvProduct.Rows[e.RowIndex].Cells["ProductName"].FormattedValue.ToString();
                _productDetail = dgvProduct.Rows[e.RowIndex].Cells["ProductDescription"].FormattedValue.ToString();
                _price = Int32.Parse(dgvProduct.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString());
                _size = dgvProduct.Rows[e.RowIndex].Cells["Size"].FormattedValue.ToString();
                _quantity = Int32.Parse(dgvProduct.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString());
            }
        }

        private void dgvProduct_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                int currentMouseOverRow = dgvProduct.HitTest(e.X, e.Y).RowIndex;


                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Thêm sản phẩm vào hóa đơn", ShowDialogForSure100Percent));
                }

                m.Show(dgvProduct, new Point(e.X, e.Y));
            }
        }

        private void ShowDialogForSure100Percent(object sender, EventArgs e)
        { 
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (employeeProfile.Position.ToString() == "Giám đốc chi nhánh")
            {
                MessageBox.Show("Bạn phải là Quản Lý hoặc Nhân Viên mới có thể thực hiện tác vụ này!");
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
                MenuItem_AddBill_Click(sender, e);
            }

        }

        private void MenuItem_AddBill_Click(object sender, EventArgs e)
        {
            if (_productDetailId == 0
                || _productName == ""
                || _productDetail == ""
                || _price == 0
                || _quantity == 0
            )
            {
                MessageBox.Show("Vui lòng chọn tất cả hàng thuộc nhân viên đó, trước khi thực hiện tác vụ này!");
                return;
            }

            try
            {
                var data = dgvChiTietSP.Rows[0].Cells["ID"].FormattedValue.ToString();

                if (data == _productDetailId.ToString())
                {
                    dgvChiTietSP.Rows[0].Cells["Số lượng đặt hàng"].Value = Int32.Parse(dgvChiTietSP.Rows[0].Cells["Số lượng đặt hàng"].Value.ToString()) + 1;
                    _quantityOrder = Int32.Parse(dgvChiTietSP.Rows[0].Cells["Số lượng đặt hàng"].Value.ToString());
                    MessageBox.Show("Bạn đã thêm thành công!");
                    LoadAutomaticBilling();
                    return;
                }

                if (dgvChiTietSP.Rows.Count > 1)
                {
                    MessageBox.Show("Bạn chỉ có thể thêm một sản phẩm");
                    return;
                }

                dgvChiTietSPTable.Rows.Add(_productDetailId, _productDetail, _productDetail, 1, _price, _size);
                _quantityOrder = Int32.Parse(dgvChiTietSP.Rows[0].Cells["Số lượng đặt hàng"].Value.ToString());
                LoadAutomaticBilling();

                MessageBox.Show("Bạn đã thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message.ToString());
                return;
            }
        }

        private void LoadDgVBillChiTietSP()
        {
            dgvChiTietSPTable.Columns.Add("ID", typeof(int));
            dgvChiTietSPTable.Columns.Add("Tên sản phẩm", typeof(string));
            dgvChiTietSPTable.Columns.Add("Chi tiết sản phẩm", typeof(string));
            dgvChiTietSPTable.Columns.Add("Số lượng đặt hàng", typeof(int));
            dgvChiTietSPTable.Columns.Add("Giá", typeof(int));
            dgvChiTietSPTable.Columns.Add("Size", typeof(string));

            dgvChiTietSP.DataSource = dgvChiTietSPTable;
        }

        private void LoadAutomaticBilling()
        {
            _totalAmount = _price * _quantityOrder;
            txtTotalAmount.Text = _totalAmount.ToString();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                int discount = Int32.Parse(txtDiscount.Text.ToString());
                if (_totalAmount > 0 && discount > 0)
                {
                    int total = _totalAmount - discount;
                    txtTotalAmount.Text = total.ToString();
                    return;
                }
            }

            if (txtDiscount.Text == "")
            {
                LoadAutomaticBilling();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtHoTenKH.Text = "";
            txtSoDienThoai.Text = "";
            txtDiscount.Text = "";
            txtTotalAmount.Text = "0";
            if (dgvChiTietSP.Rows.Count > 1)
            {
                dgvChiTietSP.Rows.RemoveAt(0);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var dataEmployees = _empService.GetAll().ToList();
            var employeeProfile = dataEmployees.Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            if (txtHoTenKH.Text == "" || txtSoDienThoai.Text == "" 
                || txtDiscount.Text == "" || _totalAmount == 0 || 
                _productDetailId == 0 || _quantityOrder == 0 || _price == 0
            )
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            try
            {
                int employeeId = Int32.Parse(employeeProfile.ID.ToString());
                string customer = txtHoTenKH.Text.ToString();
                string checkoutDate = datePickerNgayDatHang.Value.ToString();
                int phoneNumber = Int32.Parse(txtSoDienThoai.Text.ToString());
                int discount = Int32.Parse(txtDiscount.Text.ToString());
                int totalAmount = Int32.Parse(txtTotalAmount.Text.ToString());
                int productDetailId = _productDetailId;
                int quantityOrder = _quantityOrder;
                int currentUnitPrice = _price;
                string branch = WorkingContext.Instance.CurrentBranch;

                var themBill = _themBillService.ThemBill(
                        employeeId, 
                        customer,
                        checkoutDate,
                        phoneNumber,
                        discount,
                        totalAmount,
                        productDetailId,
                        quantityOrder,
                        currentUnitPrice
                    );
                if (themBill.Result == 0)
                {
                    MessageBox.Show("Them Bill that bai!");
                    return;
                }

                if (themBill.Result == 1)
                {
                    MessageBox.Show("Them Bill thanh cong! ^^");
                    InvoiceForm form = new InvoiceForm(_unitOfWork, customer, phoneNumber, branch, checkoutDate, quantityOrder, _productDetail, currentUnitPrice, discount, totalAmount);
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Loi", ex.Message.ToString());
            }
        }
    }
}
