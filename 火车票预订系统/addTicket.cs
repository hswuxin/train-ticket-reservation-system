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
    public partial class addTicket : Form
    {
        public addTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTrainID.Text == "")
            {
                MessageBox.Show("请输入班次号", "提示");
                txtTrainID.Focus();
                return;
            }
            if (txtOrigin.Text == "")
            {
                MessageBox.Show("请输入出发地", "提示");
                txtOrigin.Focus();
                return;
            }
            if (txtDestination.Text == "")
            {
                MessageBox.Show("请输入目的地", "提示");
                txtDestination.Focus();
                return;
            }
            if (txtSeatNumber.Text == "")
            {
                MessageBox.Show("请输入座位数", "提示");
                txtSeatNumber.Focus();
                return;
            }
            if (txtLastNumber.Text == "")
            {
                MessageBox.Show("请输入剩余座位数", "提示");
                txtLastNumber.Focus();
                return;
            }
            if (txtSeatMoney.Text == "")
            {
                MessageBox.Show("请输入票价", "提示");
                txtSeatMoney.Focus();
                return;
            }
            string str = string.Format("SELECT * FROM Ticket where TrainID ='{0}'", txtTrainID.Text);
            if (DBAccess.EXE_select(str))
            {
                MessageBox.Show("已经有此班次", "提示");
            }
            else
            {
                string sql = string.Format("insert into Ticket(TrainID,Origin,Destination,Ctime,Dtime,SeatNumber,LastNumber,SeatMoney) values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')", txtTrainID.Text, txtOrigin.Text, txtDestination.Text, txtCtime.Value.ToString("yyyy/MM/dd HH:mm:ss"), txtDtime.Value.ToString("yyyy/MM/dd HH:mm:ss"), txtSeatNumber.Text, txtLastNumber.Text, txtSeatMoney.Text);
                try
                {
                    DBAccess.EXE_update(sql);
                    MessageBox.Show("插入成功", "提示");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("UPDATE Ticket SET Origin='{0}',Destination ='{1}',Ctime='{2}',Dtime='{3}',SeatNumber ={4},LastNumber ={5},SeatMoney ={6} WHERE TrainID ='{7}'", txtOrigin.Text, txtDestination.Text, txtCtime.Value.ToString("yyyy/MM/dd HH:mm:ss"), txtDtime.Value.ToString("yyyy/MM/dd HH:mm:ss"),txtSeatNumber .Text,txtLastNumber.Text,txtSeatMoney.Text,txtTrainID.Text);
            string sql2 = string.Format("delete from IM where TrainID='{0}'",txtTrainID.Text);
                try
                {
                    DBAccess.EXE_update(sql);
                    DBAccess.EXE_update(sql2);
                    MessageBox.Show("修改成功", "提示");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void addTicket_Load(object sender, EventArgs e)
        {
            txtCtime.Format=DateTimePickerFormat.Custom;
            txtCtime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            txtCtime.ShowUpDown = true;
            txtDtime.Format = DateTimePickerFormat.Custom;
            txtDtime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            txtDtime.ShowUpDown = true;
        }
    }
}
