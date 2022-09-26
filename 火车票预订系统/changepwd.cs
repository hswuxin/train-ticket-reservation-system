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
    public partial class changepwd : Form
    {
        public changepwd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名", "提示");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码", "提示");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("请确认密码", "提示");
                textBox3.Focus();
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次输入的密码不一致", "提示");
                textBox3.Focus();
                return;
            }
            string temp=textBox3.Text;//临时变量，给用户展示新的密码
            user u1 = new user();
            u1.UserID=DBAccess.md5(textBox1.Text);//身份证号
            u1.UserPWD=DBAccess.md5(textBox3.Text);//密码
            string s1 = string.Format(@"update userIM set UserPWD='{0}' where UserID='{1}' or UserName='{2}'", u1.UserPWD, u1.UserID,textBox1.Text);
            try
            {
                if (DBAccess.EXE_update(s1))
                {
                    MessageBox.Show("密码修改成功,密码为：" + temp, "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败,请查看你输入的身份证号码是否正确", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
