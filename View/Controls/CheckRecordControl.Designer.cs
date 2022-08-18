namespace Views.Controls
{
    partial class CheckRecordControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_ok = new System.Windows.Forms.RadioButton();
            this.radioButton_danger = new System.Windows.Forms.RadioButton();
            this.button_submit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "核酸检测结果";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_ok);
            this.groupBox1.Controls.Add(this.radioButton_danger);
            this.groupBox1.Location = new System.Drawing.Point(104, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_ok
            // 
            this.radioButton_ok.AutoSize = true;
            this.radioButton_ok.Location = new System.Drawing.Point(80, 24);
            this.radioButton_ok.Name = "radioButton_ok";
            this.radioButton_ok.Size = new System.Drawing.Size(60, 24);
            this.radioButton_ok.TabIndex = 0;
            this.radioButton_ok.TabStop = true;
            this.radioButton_ok.Text = "阴性";
            this.radioButton_ok.UseVisualStyleBackColor = true;
            // 
            // radioButton_danger
            // 
            this.radioButton_danger.AutoSize = true;
            this.radioButton_danger.Location = new System.Drawing.Point(80, 54);
            this.radioButton_danger.Name = "radioButton_danger";
            this.radioButton_danger.Size = new System.Drawing.Size(60, 24);
            this.radioButton_danger.TabIndex = 0;
            this.radioButton_danger.TabStop = true;
            this.radioButton_danger.Text = "阳性";
            this.radioButton_danger.UseVisualStyleBackColor = true;
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(171, 262);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(94, 29);
            this.button_submit.TabIndex = 2;
            this.button_submit.Text = "提交";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // CheckRecordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "CheckRecordControl";
            this.Size = new System.Drawing.Size(481, 453);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButton_ok;
        private RadioButton radioButton_danger;
        private Button button_submit;
    }
}
