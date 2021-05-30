using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.TopMatHangBanChay;
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
    public partial class TopMatHangBanChayForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private ITopMatHangBanChayService _topMatHangBanChayService;

        public TopMatHangBanChayForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _topMatHangBanChayService = new TopMatHangBanChayService(_unitOfWork);

            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TopMatHangBanChayForm_Load(object sender, EventArgs e)
        {
            TopMatHangBanChayData_Load();
        }

        private void TopMatHangBanChayData_Load()
        {
            string start = datePickerStart.Value.ToString();
            string end = datePickerEnd.Value.ToString();
            try
            {
                var data = _topMatHangBanChayService.getAllMatHangBanChay(start, end);
                dgvTopMatHangBanChay.DataSource = data;
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

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            TopMatHangBanChayData_Load();
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            TopMatHangBanChayData_Load();
        }
    }
}
