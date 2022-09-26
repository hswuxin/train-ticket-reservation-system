namespace 火车票预订系统
{
    partial class login
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.userlogin = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.changepwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(70, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "用户名/身份证号码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(70, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密  码：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(139, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(135, 21);
            this.textBox2.TabIndex = 2;
            // 
            // userlogin
            // 
            this.userlogin.Location = new System.Drawing.Point(321, 37);
            this.userlogin.Name = "userlogin";
            this.userlogin.Size = new System.Drawing.Size(82, 25);
            this.userlogin.TabIndex = 3;
            this.userlogin.Text = "登录";
            this.userlogin.UseVisualStyleBackColor = true;
            this.userlogin.Click += new System.EventHandler(this.userlogin_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(74, 144);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(82, 29);
            this.register.TabIndex = 4;
            this.register.Text = "注册";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // changepwd
            // 
            this.changepwd.Location = new System.Drawing.Point(192, 144);
            this.changepwd.Name = "changepwd";
            this.changepwd.Size = new System.Drawing.Size(82, 29);
            this.changepwd.TabIndex = 4;
            this.changepwd.Text = "忘记密码";
            this.changepwd.UseVisualStyleBackColor = true;
            this.changepwd.Click += new System.EventHandler(this.changepwd_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(473, 207);
            this.Controls.Add(this.changepwd);
            this.Controls.Add(this.register);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.userlogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(489, 246);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button userlogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button changepwd;
    }
}

