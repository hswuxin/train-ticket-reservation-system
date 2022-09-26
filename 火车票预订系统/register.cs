using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 火车票预订系统
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        public static string user_id_notMD5;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("请输入用户名", "提示");
                username.Focus();
                return;
            }
            if (userpwd.Text == "")
            {
                MessageBox.Show("请输入密码", "提示");
                userpwd.Focus();
                return;
            }
            if (userid.Text == "")
            {
                MessageBox.Show("请输入身份证号码", "提示");
                userid.Focus();
                return;
            }
            user u1 = new user();
            u1.UserPWD = DBAccess.md5(userpwd.Text);//密码
            u1.UserID = DBAccess.md5(userid.Text);//身份证号码
            u1.UserName=username.Text;
            string s1 = string.Format(@"insert into userIM values('{0}','{1}','{2}','{3}',1,'{4}')", username.Text, u1.UserPWD, local.Text, u1.UserID, "0");
            string s2=string.Format(@"select * from userIM where UserName='{0}' or UserID='{1}'",u1.UserName,u1.UserID);
            try
            {
                if (DBAccess.EXE_select(s2))
                {
                    MessageBox.Show("该账号已被注册或身份证已被使用", "提示");
                    username.Focus();
                    return;
                }
                if (DBAccess.EXE_update(s1))
                {
                    MessageBox.Show("注册成功,用户名：" + username.Text,"提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void local_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void userpwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
