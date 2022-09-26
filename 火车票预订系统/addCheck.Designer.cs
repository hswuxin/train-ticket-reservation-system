namespace 火车票预订系统
{
    partial class addCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addCheck));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.txtTrainID = new System.Windows.Forms.TextBox();
            this.txtShiftID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteTicket = new System.Windows.Forms.Button();
            this.addTicket = new System.Windows.Forms.Button();
            this.changeTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(644, 217);
            this.dataGridView1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtDestination);
            this.groupBox1.Controls.Add(this.txtOrigin);
            this.groupBox1.Controls.Add(this.txtTrainID);
            this.groupBox1.Controls.Add(this.txtShiftID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车次查询";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(251, 86);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(100, 21);
            this.txtDestination.TabIndex = 4;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(72, 86);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(100, 21);
            this.txtOrigin.TabIndex = 3;
            // 
            // txtTrainID
            // 
            this.txtTrainID.Location = new System.Drawing.Point(251, 30);
            this.txtTrainID.Name = "txtTrainID";
            this.txtTrainID.Size = new System.Drawing.Size(100, 21);
            this.txtTrainID.TabIndex = 2;
            // 
            // txtShiftID
            // 
            this.txtShiftID.Location = new System.Drawing.Point(72, 30);
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.Size = new System.Drawing.Size(100, 21);
            this.txtShiftID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "目的地";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "始发地";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "车次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "班次";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "购票";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteTicket
            // 
            this.deleteTicket.Location = new System.Drawing.Point(138, 395);
            this.deleteTicket.Name = "deleteTicket";
            this.deleteTicket.Size = new System.Drawing.Size(94, 28);
            this.deleteTicket.TabIndex = 7;
            this.deleteTicket.Text = "删除";
            this.deleteTicket.UseVisualStyleBackColor = true;
            this.deleteTicket.Click += new System.EventHandler(this.deleteTicket_Click);
            // 
            // addTicket
            // 
            this.addTicket.Location = new System.Drawing.Point(253, 395);
            this.addTicket.Name = "addTicket";
            this.addTicket.Size = new System.Drawing.Size(94, 28);
            this.addTicket.TabIndex = 8;
            this.addTicket.Text = "增加";
            this.addTicket.UseVisualStyleBackColor = true;
            this.addTicket.Click += new System.EventHandler(this.addTicket_Click);
            // 
            // changeTicket
            // 
            this.changeTicket.Location = new System.Drawing.Point(370, 395);
            this.changeTicket.Name = "changeTicket";
            this.changeTicket.Size = new System.Drawing.Size(81, 28);
            this.changeTicket.TabIndex = 9;
            this.changeTicket.Text = "修改";
            this.changeTicket.UseVisualStyleBackColor = true;
            this.changeTicket.Click += new System.EventHandler(this.changeTicket_Click);
            // 
            // addCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 452);
            this.Controls.Add(this.changeTicket);
            this.Controls.Add(this.addTicket);
            this.Controls.Add(this.deleteTicket);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addCheck";
            this.Text = "车票查询";
            this.Load += new System.EventHandler(this.addTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTrainID;
        private System.Windows.Forms.TextBox txtShiftID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteTicket;
        private System.Windows.Forms.Button addTicket;
        private System.Windows.Forms.Button changeTicket;
    }
}