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
    public partial class addMoney : Form
    {
        public addMoney()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMoney.Text!="")
            {
                string sql = string.Format("UPDATE userIM SET UserMoney =UserMoney +{0} WHERE UserName ='{1}'", int.Parse(txtMoney.Text), username.Text);
                DBAccess.EXE_update(sql);
                MessageBox.Show("充值成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入金额");
            }
        }
    }
}
