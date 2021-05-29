using QLDungCuTheThao.Controllers;
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
    public partial class InvoiceForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private string customer;
        private int phoneNumber;
        private string branch;
        private string checkoutDate;
        private int quantityOrder;
        private string _productDetail;
        private int currentUnitPrice;
        private int discount;
        private int totalAmount;

        public InvoiceForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
        }

        public InvoiceForm(IUnitOfWork unitOfWork, string customer, int phoneNumber, string branch, string checkoutDate, int quantityOrder, string productDetail, int currentUnitPrice, int discount, int totalAmount) : this(unitOfWork)
        {
            this.customer = customer;
            this.phoneNumber = phoneNumber;
            this.branch = branch;
            this.checkoutDate = checkoutDate;
            this.quantityOrder = quantityOrder;
            _productDetail = productDetail;
            this.currentUnitPrice = currentUnitPrice;
            this.discount = discount;
            this.totalAmount = totalAmount;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            LoadLineStyles();
            LoadData();
        }

        private void LoadData()
        {
            labelTenKH.Text = this.customer.ToString();
            lbSoDienThoaiKH.Text = "Số điện thoại: +" + this.phoneNumber.ToString();
            lbChiNhanh.Text = "Chi Nhánh: " + this.branch.ToString();
            lbNgayDatHang.Text = "Ngày: " + this.checkoutDate.ToString();
            lbSL.Text = this.quantityOrder.ToString();
            lbChiTietSP.Text = this._productDetail.ToString();
            lbGia.Text = this.currentUnitPrice.ToString();
            lbDiscount.Text = this.discount.ToString();
            lbTotal.Text = this.totalAmount.ToString();
        }

        private void LoadLineStyles()
        {
            line1.Height = 2;
            line1.BorderStyle = BorderStyle.Fixed3D;
            line2.Height = 2;
            line2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(_unitOfWork);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
