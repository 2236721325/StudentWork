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

namespace Views.Controls
{
    public partial class InnerMsgControl : UserControl
    {
        private readonly RestClient _UserClient;
        public InnerMsgControl()
        {
            InitializeComponent();
            _UserClient = new RestClient(RequestHelper.UserBaseUrl);
            InitData();
        }
        public void InitData()
        {
            this.listView1.Clear();
            listView1.Columns.Add("检测结果", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("检测时间", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("身份证", 150, HorizontalAlignment.Center);
            this.listView1.ShowGroups = true;
            this.listView1.View = View.Details;
            this.listView1.BeginUpdate();
            var request = new RestRequest("CheckRecord/FindMyCheckRecord")
                .AddHeader("Authorization", $"Bearer {RequestHelper.JwtString}");
            var reponse = _UserClient.Post(request);
            if (!reponse.IsSuccessful)
            {
                MessageBox.Show(reponse.ErrorMessage + ":" + reponse.Content);
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                return;
            }
            var results = JsonConvert.DeserializeObject(reponse.Content) as JArray;
            foreach (var item in results)
            {
                var row = new ListViewItem();
                row.Text = item["name"].ToString();
                row.SubItems.Add(item["createTime"].ToString());
                row.SubItems.Add(item["idCard"].ToString());
                this.listView1.Items.Add(row);
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
            return;
        }
    }
}
