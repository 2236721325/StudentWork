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
    public partial class SearchControl : UserControl
    {
        private readonly RestClient userClient;
        public SearchControl()
        {
            InitializeComponent();
            userClient = new RestClient(RequestHelper.UserBaseUrl);
            radioButton_name.Checked = true;
        }

       

        private void btn_search_Click(object sender, EventArgs e)//这个。。。。都怪我不好写后端的时候灵活返回匿名类型（遭报应楼）
        {
            
            if (string.IsNullOrEmpty(textBox_input.Text)) 
            {
                MessageBox.Show("搜索内容不为空");
                return;
            }
            this.listView1.Clear();
            listView1.Columns.Add("Id", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("检测结果", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("检测时间", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("身份证", 150, HorizontalAlignment.Center);
            this.listView1.ShowGroups = true;
            this.listView1.View = View.Details;
            this.listView1.BeginUpdate();
            if (!radioButton_startFilter.Checked)
            {
                if(radioButton_name.Checked)
                {
                    var request = new RestRequest("CheckRecord/FindByName")
                        .AddQueryParameter("name", textBox_input.Text);
                    var reponse = userClient.Post(request);
                    if(!reponse.IsSuccessful)
                    {
                        MessageBox.Show(reponse.ErrorMessage+":"+reponse.Content);
                        this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                        return;
                    }
                    var results = JsonConvert.DeserializeObject(reponse.Content) as JArray;
                
                    foreach (var items in results)
                    {
                        var group = new ListViewGroup($"姓名：{items["name"].ToString()},Id:{items["id"]}"+"以下为检测结果记录");
                        this.listView1.Groups.Add(group);
                        foreach (var item in items["checkRecords"])
                        {
                            var row = new ListViewItem();
                            row.Text = item["id"].ToString();
                            row.SubItems.Add(item["name"].ToString());
                            row.SubItems.Add(item["createTime"].ToString());
                            row.SubItems.Add(item["idCard"].ToString());
                            group.Items.Add(row);
                            this.listView1.Items.Add(row);
                        }
                    }
                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                    return;
                }
                if (radioButton_phone.Checked)
                {
                    var request = new RestRequest("CheckRecord/FindByPhoneNumber")
                       .AddQueryParameter("phoneNumber", textBox_input.Text);
                    var reponse = userClient.Post(request);
                    if (!reponse.IsSuccessful)
                    {
                        MessageBox.Show(reponse.ErrorMessage + ":" + reponse.Content);
                        this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                        return;
                    }
                    var results = JsonConvert.DeserializeObject(reponse.Content) as JArray;
                
                    foreach (var items in results)
                    {
                        var group = new ListViewGroup($"电话号码：{items["phoneNumber"].ToString()},Id:{items["id"]}" + "以下为检测结果记录");
                        this.listView1.Groups.Add(group);
                        foreach (var item in items["checkRecords"])
                        {
                            var row = new ListViewItem();
                            row.Text = item["id"].ToString();
                            row.SubItems.Add(item["name"].ToString());
                            row.SubItems.Add(item["createTime"].ToString());
                            row.SubItems.Add(item["idCard"].ToString());
                            group.Items.Add(row);
                            this.listView1.Items.Add(row);
                        }
                    }
                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                    return;
                }
                if(radioButton_idcard.Checked)
                {
                    var request = new RestRequest("CheckRecord/FindByIDCard")
                       .AddQueryParameter("idCard", textBox_input.Text);
                    var reponse = userClient.Post(request);
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
                        row.Text = item["id"].ToString();
                        row.SubItems.Add(item["name"].ToString());
                        row.SubItems.Add(item["createTime"].ToString());
                        row.SubItems.Add(item["idCard"].ToString());
                        this.listView1.Items.Add(row);
                    }

                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                    return;
                }
                
            }
            if (radioButton_name.Checked)
            {
                var request = new RestRequest("CheckRecord/FindByName_startTimeFilter")
                        .AddQueryParameter("name", textBox_input.Text)
                        .AddBody(new
                        {
                            startTime = this.dateTimePicker_start.Value,
                            endTime = this.dateTimePicker_end.Value
                        });
                
                var reponse = userClient.Post(request);
                if (!reponse.IsSuccessful)
                {
                    MessageBox.Show(reponse.ErrorMessage + ":" + reponse.Content);
                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                    return;
                }
                var results = JsonConvert.DeserializeObject(reponse.Content) as JArray;

                foreach (var items in results)
                {
                    var group = new ListViewGroup($"姓名：{items["name"].ToString()},Id:{items["id"]}" + "以下为检测结果记录");
                    this.listView1.Groups.Add(group);
                    foreach (var item in items["checkRecords"])
                    {
                        var row = new ListViewItem();
                        row.Text = item["id"].ToString();
                        row.SubItems.Add(item["name"].ToString());
                        row.SubItems.Add(item["createTime"].ToString());
                        row.SubItems.Add(item["idCard"].ToString());
                        group.Items.Add(row);
                        this.listView1.Items.Add(row);
                    }
                }
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                return;
            }
            if(radioButton_phone.Checked)
            {
                var request = new RestRequest("CheckRecord/FindByPhoneNumber_startTimeFilter")
                      .AddQueryParameter("phoneNumber", textBox_input.Text)
                       .AddBody(new
                       {
                           startTime = this.dateTimePicker_start.Value,
                           endTime = this.dateTimePicker_end.Value
                       });
                var reponse = userClient.Post(request);
                if (!reponse.IsSuccessful)
                {
                    MessageBox.Show(reponse.ErrorMessage + ":" + reponse.Content);
                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                    return;
                }
                var results = JsonConvert.DeserializeObject(reponse.Content) as JArray;

                foreach (var items in results)
                {
                    var group = new ListViewGroup($"电话号码：{items["phoneNumber"].ToString()},Id:{items["id"]}" + "以下为检测结果记录");
                    this.listView1.Groups.Add(group);
                    foreach (var item in items["checkRecords"])
                    {
                        var row = new ListViewItem();
                        row.Text = item["id"].ToString();
                        row.SubItems.Add(item["name"].ToString());
                        row.SubItems.Add(item["createTime"].ToString());
                        row.SubItems.Add(item["idCard"].ToString());
                        group.Items.Add(row);
                        this.listView1.Items.Add(row);
                    }
                }
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                return;
            }
            if(radioButton_idcard.Checked)
            {
                var request = new RestRequest("CheckRecord/FindByIDCard_startTimeFilter")
                       .AddQueryParameter("idCard", textBox_input.Text)
                        .AddBody(new
                        {
                            startTime = this.dateTimePicker_start.Value,
                            endTime = this.dateTimePicker_end.Value
                        });
                var reponse = userClient.Post(request);
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
                    row.Text = item["id"].ToString();
                    row.SubItems.Add(item["name"].ToString());
                    row.SubItems.Add(item["createTime"].ToString());
                    row.SubItems.Add(item["idCard"].ToString());
                    this.listView1.Items.Add(row);
                }
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                return;
            
        }


        }
    }
}
