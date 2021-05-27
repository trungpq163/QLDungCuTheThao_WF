using QLDungCuTheThao.Controllers;
using QLDungCuTheThao.EntityDataModel;
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
    public partial class AccountForm : Form
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeService _empService;

        public AccountForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empService = new EmployeeService(_unitOfWork);
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dataEmployees = _empService.GetAll().ToList();
                var employeeProfile = dataEmployees.Find(x => Utils.FullNameToUserName(Utils.RemoveDiacritics(x.FullName)) == WorkingContext.Instance.CurrentLoginName);

                renderEmployeeProfile(employeeProfile);
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

        private void pbBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(_unitOfWork);
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void renderEmployeeProfile(Employee employee)
        {
            lbUsername.Text = Utils.FullNameToUserName(Utils.RemoveDiacritics(employee.FullName));
            lbName.Text = "Họ tên: " + Utils.RemoveDiacritics(employee.FullName);
            lbDateOfBirth.Text = "Ngày sinh: " + employee.DateOfBirth;
            lbPosition.Text = "Vị trí: " + Utils.RemoveDiacritics(employee.Position);
            //if (employee.Branch1.)
            lbBranch.Text = "Chi nhánh: " + Utils.RemoveDiacritics(employee.Branch1.Name.ToString());
            lbSalary.Text = "Lương: " + employee.Salary;
            lbPhone.Text = "Số điện thoại: " + employee.PhoneNumber;
        }
    }
}
