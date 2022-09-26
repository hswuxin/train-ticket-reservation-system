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
    public partial class buyTicket : Form
    {
        public buyTicket()
        {
            InitializeComponent();
        }
        public int maxSeat = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            string selectstr = string.Format("select * from Ticket where LastNumber=0 and TrainID='{0}'",txtTrainID.Text);
            try
            {
                if(DBAccess.EXE_select(selectstr))
                {
                    MessageBox.Show("余票为0，请选择其他车次","提示");
                }
                if (int.Parse(txtSearchNumber.Text) < 1 ||int.Parse(txtSearchNumber.Text) > maxSeat)
                {
                    MessageBox.Show("请选择合法的座位，不可大于车位数或不存在的座位", "提示");
                }
                else
                {
                    string selcectstr2 = string.Format("select * from SearchSeat where ShiftID='{0}' and SearchNumber={1}", txtShiftID.Text, txtSearchNumber.Text);
                    if (DBAccess.EXE_select(selcectstr2))
                    {
                        MessageBox.Show("该座位已经被选，请选择其它座位");
                    }
                    else
                    {
                        string searchMoney = string.Format("select * from UserIM WHERE UserName='{0}'", login.user_name);
                        DataSet mm = DBAccess.EXE_ds(searchMoney);
                        if (int.Parse(mm.Tables[0].Rows[0]["UserMoney"].ToString()) < int.Parse(lableMoney.Text))
                        {
                            MessageBox.Show("余额不足", "提示");
                        }
                        else
                        {
                            string cutmoney = string.Format("UPDATE userIM SET UserMoney=UserMoney - {0} WHERE UserName='{1}'", int.Parse(lableMoney.Text), login.user_name);
                            string sql = string.Format("update Ticket set LastNumber=LastNumber-1 where ShiftID='{0}'", txtShiftID.Text);
                            string sql2 = string.Format("insert into SearchSeat(ShiftID,SearchNumber)values('{0}',{1})", txtShiftID.Text, txtSearchNumber.Text);
                            string sql3 = string.Format("insert into IM(UserName,ShiftID,TrainID,Origin,Destination,Ctime,Dtime,SearchNumber)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})", login.user_name, txtShiftID.Text, txtTrainID.Text, txtOrigin.Text, txtDestination.Text, txtCtime.Value.ToString("yyyy/MM/dd HH:mm"), txtDtime.Value.ToString("yyyy/MM/dd HH:mm"), txtSearchNumber.Text);
                            try
                            {
                                DBAccess.EXE_update(cutmoney);
                                DBAccess.EXE_update(sql);
                                DBAccess.EXE_update(sql2);
                                DBAccess.EXE_update(sql3);
                                MessageBox.Show("购买成功", "提示");
                                this.Close();
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void buyTicket_Load(object sender, EventArgs e)
        {
            txtCtime.Format = DateTimePickerFormat.Custom;
            txtCtime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            txtCtime.ShowUpDown = true;
            txtDtime.Format = DateTimePickerFormat.Custom;
            txtDtime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            txtDtime.ShowUpDown = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
