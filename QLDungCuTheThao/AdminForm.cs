using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
using QLDungCuTheThao.Services.Employees;
using QLDungCuTheThao.Services.GetAllNhanVien;
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

        public AdminForm(IUnitOfWork unitOfWork, Employee employeeProfile)
        {
            _unitOfWork = unitOfWork;
            _employeeProfile = employeeProfile;
            _allEmployeeService = new GetAllNhanVienService(_unitOfWork);
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
                Cbb_Employee_Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi load data tu database \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void Employee_Data_Load()
        {
            var allEmployeeData = _allEmployeeService.getAllNhanVien().ToList();
            dgvEmployees.DataSource = allEmployeeData;
            cbbBranch.Text = WorkingContext.Instance.CurrentBranch;
        }

        private void Cbb_Employee_Load()
        {

        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(_unitOfWork);
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
