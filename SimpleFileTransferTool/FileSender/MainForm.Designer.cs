namespace FileSender
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_IPStart = new System.Windows.Forms.TextBox();
            this.Label_IPRange = new System.Windows.Forms.Label();
            this.textBox_IPEnd = new System.Windows.Forms.TextBox();
            this._ = new System.Windows.Forms.Label();
            this.Button_searchIP = new System.Windows.Forms.Button();
            this.listBox_connectedIP = new System.Windows.Forms.ListBox();
            this.listBox_addedFile = new System.Windows.Forms.ListBox();
            this.button_addFile = new System.Windows.Forms.Button();
            this.label_localIP = new System.Windows.Forms.Label();
            this.label_searchWaiting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_IPStart
            // 
            this.textBox_IPStart.Location = new System.Drawing.Point(59, 27);
            this.textBox_IPStart.Name = "textBox_IPStart";
            this.textBox_IPStart.Size = new System.Drawing.Size(135, 21);
            this.textBox_IPStart.TabIndex = 0;
            // 
            // Label_IPRange
            // 
            this.Label_IPRange.AutoSize = true;
            this.Label_IPRange.Location = new System.Drawing.Point(12, 30);
            this.Label_IPRange.Name = "Label_IPRange";
            this.Label_IPRange.Size = new System.Drawing.Size(41, 12);
            this.Label_IPRange.TabIndex = 1;
            this.Label_IPRange.Text = "IP范围";
            // 
            // textBox_IPEnd
            // 
            this.textBox_IPEnd.Location = new System.Drawing.Point(235, 27);
            this.textBox_IPEnd.Name = "textBox_IPEnd";
            this.textBox_IPEnd.Size = new System.Drawing.Size(135, 21);
            this.textBox_IPEnd.TabIndex = 2;
            // 
            // _
            // 
            this._.AutoSize = true;
            this._.Location = new System.Drawing.Point(200, 30);
            this._.Name = "_";
            this._.Size = new System.Drawing.Size(29, 12);
            this._.TabIndex = 3;
            this._.Text = "——";
            // 
            // Button_searchIP
            // 
            this.Button_searchIP.Location = new System.Drawing.Point(395, 25);
            this.Button_searchIP.Name = "Button_searchIP";
            this.Button_searchIP.Size = new System.Drawing.Size(75, 23);
            this.Button_searchIP.TabIndex = 4;
            this.Button_searchIP.Text = "搜索";
            this.Button_searchIP.UseVisualStyleBackColor = true;
            this.Button_searchIP.Click += new System.EventHandler(this.Button_searchIP_Click);
            // 
            // listBox_connectedIP
            // 
            this.listBox_connectedIP.FormattingEnabled = true;
            this.listBox_connectedIP.ItemHeight = 12;
            this.listBox_connectedIP.Location = new System.Drawing.Point(14, 54);
            this.listBox_connectedIP.Name = "listBox_connectedIP";
            this.listBox_connectedIP.Size = new System.Drawing.Size(180, 196);
            this.listBox_connectedIP.TabIndex = 5;
            // 
            // listBox_addedFile
            // 
            this.listBox_addedFile.FormattingEnabled = true;
            this.listBox_addedFile.ItemHeight = 12;
            this.listBox_addedFile.Location = new System.Drawing.Point(235, 161);
            this.listBox_addedFile.Name = "listBox_addedFile";
            this.listBox_addedFile.Size = new System.Drawing.Size(235, 88);
            this.listBox_addedFile.TabIndex = 6;
            // 
            // button_addFile
            // 
            this.button_addFile.Location = new System.Drawing.Point(395, 132);
            this.button_addFile.Name = "button_addFile";
            this.button_addFile.Size = new System.Drawing.Size(75, 23);
            this.button_addFile.TabIndex = 7;
            this.button_addFile.Text = "添加文件";
            this.button_addFile.UseVisualStyleBackColor = true;
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Location = new System.Drawing.Point(233, 99);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(41, 12);
            this.label_localIP.TabIndex = 8;
            this.label_localIP.Text = "label1";
            // 
            // label_searchWaiting
            // 
            this.label_searchWaiting.AutoSize = true;
            this.label_searchWaiting.Location = new System.Drawing.Point(233, 54);
            this.label_searchWaiting.Name = "label_searchWaiting";
            this.label_searchWaiting.Size = new System.Drawing.Size(59, 12);
            this.label_searchWaiting.TabIndex = 9;
            this.label_searchWaiting.Text = "检索中...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 261);
            this.Controls.Add(this.label_searchWaiting);
            this.Controls.Add(this.label_localIP);
            this.Controls.Add(this.button_addFile);
            this.Controls.Add(this.listBox_addedFile);
            this.Controls.Add(this.listBox_connectedIP);
            this.Controls.Add(this.Button_searchIP);
            this.Controls.Add(this._);
            this.Controls.Add(this.textBox_IPEnd);
            this.Controls.Add(this.Label_IPRange);
            this.Controls.Add(this.textBox_IPStart);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "发送端";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IPStart;
        private System.Windows.Forms.Label Label_IPRange;
        private System.Windows.Forms.TextBox textBox_IPEnd;
        private System.Windows.Forms.Label _;
        private System.Windows.Forms.Button Button_searchIP;
        private System.Windows.Forms.ListBox listBox_connectedIP;
        private System.Windows.Forms.ListBox listBox_addedFile;
        private System.Windows.Forms.Button button_addFile;
        private System.Windows.Forms.Label label_localIP;
        private System.Windows.Forms.Label label_searchWaiting;
    }
}

