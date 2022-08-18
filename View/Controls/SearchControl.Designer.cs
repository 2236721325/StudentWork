namespace Views.Controls
{
    partial class SearchControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_search = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_phone = new System.Windows.Forms.RadioButton();
            this.radioButton_idcard = new System.Windows.Forms.RadioButton();
            this.radioButton_name = new System.Windows.Forms.RadioButton();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.radioButton_startFilter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(552, 21);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(94, 29);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "搜索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_phone);
            this.groupBox1.Controls.Add(this.radioButton_idcard);
            this.groupBox1.Controls.Add(this.radioButton_name);
            this.groupBox1.Location = new System.Drawing.Point(69, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按什么搜索？";
            // 
            // radioButton_phone
            // 
            this.radioButton_phone.AutoSize = true;
            this.radioButton_phone.Location = new System.Drawing.Point(289, 28);
            this.radioButton_phone.Name = "radioButton_phone";
            this.radioButton_phone.Size = new System.Drawing.Size(90, 24);
            this.radioButton_phone.TabIndex = 2;
            this.radioButton_phone.TabStop = true;
            this.radioButton_phone.Text = "电话号码";
            this.radioButton_phone.UseVisualStyleBackColor = true;
            // 
            // radioButton_idcard
            // 
            this.radioButton_idcard.AutoSize = true;
            this.radioButton_idcard.Location = new System.Drawing.Point(131, 28);
            this.radioButton_idcard.Name = "radioButton_idcard";
            this.radioButton_idcard.Size = new System.Drawing.Size(90, 24);
            this.radioButton_idcard.TabIndex = 1;
            this.radioButton_idcard.TabStop = true;
            this.radioButton_idcard.Text = "身份证号";
            this.radioButton_idcard.UseVisualStyleBackColor = true;
            // 
            // radioButton_name
            // 
            this.radioButton_name.AutoSize = true;
            this.radioButton_name.Location = new System.Drawing.Point(6, 26);
            this.radioButton_name.Name = "radioButton_name";
            this.radioButton_name.Size = new System.Drawing.Size(60, 24);
            this.radioButton_name.TabIndex = 0;
            this.radioButton_name.TabStop = true;
            this.radioButton_name.Text = "姓名";
            this.radioButton_name.UseVisualStyleBackColor = true;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(3, 22);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(530, 27);
            this.textBox_input.TabIndex = 2;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(118, 137);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker_start.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "起始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "结束时间";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(118, 166);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker_end.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 199);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(530, 336);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // radioButton_startFilter
            // 
            this.radioButton_startFilter.AutoSize = true;
            this.radioButton_startFilter.Location = new System.Drawing.Point(410, 155);
            this.radioButton_startFilter.Name = "radioButton_startFilter";
            this.radioButton_startFilter.Size = new System.Drawing.Size(166, 24);
            this.radioButton_startFilter.TabIndex = 7;
            this.radioButton_startFilter.Text = "是否开启时间段过滤";
            this.radioButton_startFilter.UseVisualStyleBackColor = true;
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton_startFilter);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_search);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(654, 554);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_search;
        private GroupBox groupBox1;
        private RadioButton radioButton_phone;
        private RadioButton radioButton_idcard;
        private RadioButton radioButton_name;
        private TextBox textBox_input;
        private DateTimePicker dateTimePicker_start;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker_end;
        private ListView listView1;
        private CheckBox radioButton_startFilter;
    }
}
