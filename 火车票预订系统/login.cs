using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace 火车票预订系统
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        //共有属性
        public static string user_name;
        public static string user_id;
        private void userlogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "用户名/身份证号码")
            {
                MessageBox.Show("请输入用户名", "提示");
                textBox1.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入用户名", "提示");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码", "提示");
                textBox1.Focus();
                return;
            }
            user u1 = new user();
            u1.UserName = textBox1.Text;//用户名
            u1.UserID= DBAccess.md5(textBox1.Text);//身份证号登录
            u1.UserPWD= DBAccess.md5(textBox2.Text);//密码
            string s1 = string.Format(@"select * from userIM where (UserName='{0}' or UserID='{1}') and UserPWD='{2}'", textBox1.Text, u1.UserID, u1.UserPWD);
            try
            {
                if (DBAccess.EXE_select(s1))
                {
                    MessageBox.Show("登录成功", "提示");
                    user_name = u1.UserName;
                    user_id = u1.UserID;
                    this.Hide();
                    main frm = new main();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "提示");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void changepwd_Click(object sender, EventArgs e)
        {
            changepwd frm = new changepwd();
            frm.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            register frm = new register();
            frm.ShowDialog();
        }
    }
}
