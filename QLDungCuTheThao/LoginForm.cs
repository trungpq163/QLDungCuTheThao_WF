using QLDungCuTheThao.Services.Sercurity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDungCuTheThao
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string branch, loginName, password;

            if (txtLoginName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Vui long nhap thong tin dang nhap");
            }

            if (cbbBranch.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chon chi nhanh");
                return;
            }

            branch = cbbBranch.Text;
            int branchId = cbbBranch.SelectedIndex + 1;
            loginName = txtLoginName.Text;
            password = txtPassword.Text;

            WorkingContext.Instance.CurrentBranch = branch;
            WorkingContext.Instance.CurrentLoginName = loginName;

            var connectionName = string.Format("Branch{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            connectionString = string.Format(connectionString, loginName, password);
            WorkingContext.Instance.Initialize(connectionString);

            var unitOfWork = WorkingContext.Instance.GetUnitOfWork();
            var authService = new LoginService(unitOfWork);

            try
            {
                var loginInfo = authService.GetLoginInfo(loginName);
                WorkingContext.Instance.CurrentLoginInfo = loginInfo;

                MainForm mainForm = new MainForm(unitOfWork);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai thông tin đăng nhập \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
