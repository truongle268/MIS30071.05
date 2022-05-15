using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GSMS.DAO;
using GSMS.DTO;

namespace GSMS.VIEWS
{
    public partial class FrmLogin : Form
    {
        FrmMain frmMain;
        public FrmLogin()
        {
            InitializeComponent();
        }
        bool Login(string userName, string password)
        {
            return AccountDDAO.Instance.CheckLogin(userName, password);
        }
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            if (userName=="admin" && password  =="123456")
            {
                frmMain = new FrmMain(userName);
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btbnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
