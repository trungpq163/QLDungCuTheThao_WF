using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.SLTonKho;
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
    public partial class SoLuongTonKhoForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;
        private ISLTonKhoService _slTonKhoService;

        public SoLuongTonKhoForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            _slTonKhoService = new SLTonKhoService(_unitOfWork);
            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SoLuongTonKhoForm_Load(object sender, EventArgs e)
        {
            SLTonKhoData_Load();
        }

        private void SLTonKhoData_Load()
        {
            decimal myDec;
            var data = _slTonKhoService.GetSLTonKho();

            if (decimal.TryParse(txtSearch.Text, out myDec))
            {
                dgvSLTonKho.DataSource = data.Where(x => x.ID.ToString() == txtSearch.Text).ToList();
                return;
            }

            if (txtSearch.Text == "")
            {
                dgvSLTonKho.DataSource = data;
                return;
            }
            dgvSLTonKho.DataSource = data.Where(x => Utils.RemoveDiacritics(x.Name.ToLower()).Contains(Utils.RemoveDiacritics(txtSearch.Text))).ToList();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            var employeeProfile = _empService.GetAll().ToList().Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

            AdminForm adminForm = new AdminForm(_unitOfWork, employeeProfile);
            this.Hide();
            adminForm.ShowDialog();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SLTonKhoData_Load();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            SLTonKhoData_Load();
        }

        private void dgvSLTonKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSLTonKho.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvSLTonKho.CurrentRow.Selected = true;
                lbSLTonKho.Text = dgvSLTonKho.Rows[e.RowIndex].Cells["Quantity"].FormattedValue.ToString();
            }
        }
    }
}
