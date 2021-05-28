using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Forms;
using QLDungCuTheThao.Models;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.Products;
using QLDungCuTheThao.Services.ProductsDetail;
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

        public MainForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _productsDetailService = new ProductsDetailService(_unitOfWork);
            _productsService = new ProductsService(_unitOfWork);

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

                loadStatusStrip(employeeProfile);

                loadDataCbbProducts(dataProducts);
                loadDataCbbProductDetails(dataProductsDetail);
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
    }
}
