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

namespace Views.Controls
{
    public partial class CheckRecordControl : UserControl
    {
        private readonly RestClient userClient;
        public CheckRecordControl()
        {
            InitializeComponent();
            userClient = new RestClient(RequestHelper.UserBaseUrl);
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if(!radioButton_danger.Checked&&!radioButton_ok.Checked)
            {
                MessageBox.Show("未知核酸检测结果！");
                return;
            }           
            var request = new RestRequest("CheckRecord/Add")
                .AddHeader("Authorization",$"Bearer {RequestHelper.JwtString}")
                .AddQueryParameter("isDanger", radioButton_danger.Checked);
            var reponse=userClient.Post(request);
            if(!reponse.IsSuccessful)
            {
                MessageBox.Show(reponse.ErrorMessage + ":" + reponse.Content);
            }
            MyTimerHelp.CreateNewTimer(TimeSpan.FromDays(3).TotalMilliseconds, (o, e) =>
            {
                MessageBox.Show("您已经72小时未作核酸检测，请立即进行核酸检测!");
            });
            MessageBox.Show("打卡成功！");
        }
    }
}
