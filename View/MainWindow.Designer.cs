namespace Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_innerMsg = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_checkRecord = new System.Windows.Forms.Button();
            this.panel_container = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.button_innerMsg);
            this.panel1.Controls.Add(this.button_Search);
            this.panel1.Controls.Add(this.button_checkRecord);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 527);
            this.panel1.TabIndex = 0;
            // 
            // button_innerMsg
            // 
            this.button_innerMsg.Location = new System.Drawing.Point(0, 3);
            this.button_innerMsg.Name = "button_innerMsg";
            this.button_innerMsg.Size = new System.Drawing.Size(219, 53);
            this.button_innerMsg.TabIndex = 0;
            this.button_innerMsg.Text = "个人打卡记录";
            this.button_innerMsg.UseVisualStyleBackColor = true;
            this.button_innerMsg.Click += new System.EventHandler(this.button_innerMsg_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(0, 153);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(219, 53);
            this.button_Search.TabIndex = 0;
            this.button_Search.Text = "查找";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_checkRecord
            // 
            this.button_checkRecord.Location = new System.Drawing.Point(0, 79);
            this.button_checkRecord.Name = "button_checkRecord";
            this.button_checkRecord.Size = new System.Drawing.Size(219, 53);
            this.button_checkRecord.TabIndex = 0;
            this.button_checkRecord.Text = "核酸检测登记";
            this.button_checkRecord.UseVisualStyleBackColor = true;
            this.button_checkRecord.Click += new System.EventHandler(this.button_checkRecord_Click);
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.SystemColors.Info;
            this.panel_container.Location = new System.Drawing.Point(222, 1);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(649, 527);
            this.panel_container.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 533);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button_innerMsg;
        private Button button_Search;
        private Button button_checkRecord;
        private Panel panel_container;
    }
}