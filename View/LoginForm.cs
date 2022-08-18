using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views.Helps;

namespace Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            loginClient = new RestClient(RequestHelper.LoginBaseUrl);
        }
        private readonly RestClient loginClient;



        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_account.Text) || string.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("账号密码不为空");
                return;
            }
            var request = new RestRequest("JWTLogin/Login")
                .AddQueryParameter("userName", textBox_account.Text)
                .AddQueryParameter("userPwd", textBox_password.Text);
            var response = loginClient.Post(request);
            if (!response.IsSuccessful)
            {
                MessageBox.Show(response.ErrorMessage + ":" + response.Content);
                return;
            }
            RequestHelper.JwtString =JsonConvert.DeserializeObject<string>(response.Content);
            this.Hide();
            new MainWindow().ShowDialog();
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btn_registe_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }
    }
}


