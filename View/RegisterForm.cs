using RestSharp;
using Views.Helps;

namespace Views
{
    public partial class RegisterForm : Form
    {
        private readonly RestClient userClient;

        public RegisterForm()
        {
            InitializeComponent();
            userClient = new RestClient(RequestHelper.UserBaseUrl);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_registe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) ||
                string.IsNullOrEmpty(textBox_userpwd.Text) ||
                string.IsNullOrEmpty(textBox_address.Text) ||
                string.IsNullOrEmpty(textBox_name.Text) ||
                string.IsNullOrEmpty(textBox_unit.Text) ||
                string.IsNullOrEmpty(text_idcard.Text) ||
                string.IsNullOrEmpty(textBox_pwd1.Text) ||
                string.IsNullOrEmpty(textBox_phone.Text))
            {
                string str = "必填字段不能为空!";
                if (textBox_pwd1.Text != textBox_userpwd.Text) str = str + "\n两次密码不一致";
                if (!radioButton_man.Checked && radioButton_woman.Checked) str = str + "\n性别必选";

                MessageBox.Show(str);
                return;
            }


            var request = new RestRequest("User/Register")
                .AddBody(new
                {
                    name = textBox_name.Text,
                    userName = textBox_username.Text,
                    userPwd = textBox_userpwd.Text,
                    idCard = text_idcard.Text,
                    gender=radioButton_woman.Checked,  
                    phoneNumber = textBox_phone.Text,
                    addressDetail = textBox_address.Text,
                    currentUnit = textBox_unit.Text,
                    remarks = textBox_remarks.Text,
                });



            var response = userClient.Post(request);
            if (!response.IsSuccessful)
            {
                MessageBox.Show(response.ErrorMessage + ":" + response.Content);
                return;
            }
            MessageBox.Show("注册成功！");
            this.Close();
        }

    }
}
