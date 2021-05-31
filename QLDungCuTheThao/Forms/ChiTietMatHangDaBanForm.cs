using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.ChiTietMatHangDaBan;
using QLDungCuTheThao.Services.Employees;
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
    public partial class ChiTietMatHangDaBanForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private IChiTietMatHangDaBanService _chiTietMatHangDaBanService;

        public ChiTietMatHangDaBanForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _chiTietMatHangDaBanService = new ChiTietMatHangDaBanService(unitOfWork);

            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChiTietMatHangDaBanForm_Load(object sender, EventArgs e)
        {
            ChiTietMatHangDaBanData_Load();
        }

        private void ChiTietMatHangDaBanData_Load()
        {
            string start = datePickerStart.Value.ToString();
            string end = datePickerEnd.Value.ToString();

            try
            {
                var data = _chiTietMatHangDaBanService.chiTietMatHangDaBan(start, end);
                dgvDSMatHangDaBan.DataSource = data;

            } catch (Exception ex)
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
            ChiTietMatHangDaBanData_Load();
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ChiTietMatHangDaBanData_Load();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ChiTietMatHangDaBanData_Load();
        }
    }
}
