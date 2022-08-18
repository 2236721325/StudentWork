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
using Views.Controls;
using Views.Helps;

namespace Views
{
    public partial class MainWindow : Form
    {
        private readonly RestClient _UserClient;
        public MainWindow()
        {
            InitializeComponent();
            panel_container.Controls.Add(new InnerMsgControl());
            _UserClient = new RestClient(RequestHelper.UserBaseUrl);
            //MyTimerHelp.CreateNewTimer(5000, (o, e) =>
            //{
            //    MessageBox.Show("警告72小时未进行核酸检测");
            //});
            InitCheckReminder();
        }
        public void InitCheckReminder()
        {
            var request = new RestRequest("CheckRecord/FindMyLastCheckRecord")
                .AddHeader("Authorization", $"Bearer {RequestHelper.JwtString}");

           
            var reponse = _UserClient.Post(request);
            if (!reponse.IsSuccessful)//说明 从未进行核酸检测返回 NotFound
            {
                MessageBox.Show("请进行核酸检测!");
                return;
            }
            var results = JsonConvert.DeserializeObject(reponse.Content) as JObject;
            var lastRecordTime = (DateTime)results["createTime"];
            var remind = lastRecordTime.AddDays(3) - DateTime.Now;
            if (remind.TotalMilliseconds<=0)
            {
                MessageBox.Show("您已经72小时未作核酸检测，请立即进行核酸检测!");
                return;
            }
            MyTimerHelp.CreateNewTimer(remind.TotalMilliseconds, (o, e) =>
            {
                MessageBox.Show("您已经72小时未作核酸检测，请立即进行核酸检测!");
            });
        }

       

        private void button_checkRecord_Click(object sender, EventArgs e)
        {
            panel_container.Controls.Clear();
            panel_container.Controls.Add(new CheckRecordControl());
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            panel_container.Controls.Clear();
            panel_container.Controls.Add(new SearchControl());
        }

        private void button_innerMsg_Click(object sender, EventArgs e)
        {
            panel_container.Controls.Clear();
            panel_container.Controls.Add(new InnerMsgControl());
        }
    }
}
