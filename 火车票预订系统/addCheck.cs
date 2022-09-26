using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 火车票预订系统
{
    public partial class addCheck : Form
    {
        public addCheck()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        void displaydb()
        {
            string sql = "select ShiftID 班次号,TrainID 车次号,Origin 始发地,Destination 目的地,Ctime 发车时间,Dtime 到达时间,SeatNumber 座位数,LastNumber 剩余座位,SeatMoney 票价 from Ticket";
            try
            {
                ds = DBAccess.EXE_ds(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int role = 1;
        private void addTicket_Load(object sender, EventArgs e)
        {
            if (role == 1)
            {
                deleteTicket.Enabled = false;
                addTicket.Enabled = false;
                changeTicket.Enabled = false;
            }
            else
            {
                deleteTicket.Enabled = true;
                addTicket.Enabled = true;
                changeTicket.Enabled = true;
            }
            displaydb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select ShiftID 班次号,TrainID 车次号,Origin 始发地,Destination 目的地,Ctime 发车时间,Dtime 到达时间,SeatNumber 座位数,LastNumber 剩余座位,SeatMoney 票价 from Ticket where 0=0 ";
            if (txtShiftID.Text != "")
            {
                str += " and ShiftID=" + txtShiftID.Text;
            }
            if (txtTrainID.Text != "")
            {
                str += " and TrainID='" + txtTrainID.Text + "'";
            }
            if (txtOrigin.Text != "")
            {
                str += " and Origin='" + txtOrigin.Text + "'";
            }
            if (txtDestination.Text != "")
            {
                str += " and Destination='" + txtDestination.Text + "'";
            }
            try
            {
                ds.Clear();
                ds = DBAccess.EXE_ds(str);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buyTicket frm = new buyTicket();
            if (dataGridView1.DataSource != null && dataGridView1.CurrentCell.RowIndex >= 0 && dataGridView1.CurrentCell != null)
            {
                frm.txtShiftID.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["班次号"].ToString();
                frm.txtTrainID.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["车次号"].ToString();
                frm.txtOrigin.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["始发地"].ToString();
                frm.txtDestination.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["目的地"].ToString();
                frm.txtCtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["发车时间"].ToString();
                frm.txtDtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["到达时间"].ToString();
                frm.lableMoney.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["票价"].ToString();
                frm.maxSeat = int.Parse(ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["座位数"].ToString());
                frm.ShowDialog();
                displaydb();
            }
        }

        private void deleteTicket_Click(object sender, EventArgs e)
        {
            string shiftid = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["班次号"].ToString();
            if (MessageBox.Show("真的删除吗?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = string.Format("delete from IM where ShiftID='{0}'", shiftid);
                string sql2 = string.Format("delete from SearchSeat where ShiftID='{0}'", shiftid);
                string sql3 = string.Format("delete from Ticket where ShiftID='{0}'", shiftid);
                try
                {
                    DBAccess.EXE_update(sql);
                    DBAccess.EXE_update(sql2);
                    DBAccess.EXE_update(sql3);
                    MessageBox.Show("删除成功", "提示");
                    displaydb();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addTicket_Click(object sender, EventArgs e)
        {
            addTicket frm = new addTicket();
            frm.txtShiftID.Enabled = false;
            frm.button2.Enabled = false;
            frm.txtTrainID.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["车次号"].ToString();
            frm.txtOrigin.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["始发地"].ToString();
            frm.txtDestination.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["目的地"].ToString();
            frm.txtCtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["发车时间"].ToString();
            frm.txtDtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["到达时间"].ToString();
            frm.ShowDialog();
        }

        private void changeTicket_Click(object sender, EventArgs e)
        {
            addTicket frm = new addTicket();
            frm.txtShiftID.Enabled = false;
            txtTrainID.Enabled = false;
            frm.button1.Enabled = false;
            frm.txtTrainID.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["车次号"].ToString();
            frm.txtOrigin.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["始发地"].ToString();
            frm.txtDestination.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["目的地"].ToString();
            frm.txtCtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["发车时间"].ToString();
            frm.txtDtime.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["到达时间"].ToString();
            frm.txtSeatNumber.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["座位数"].ToString();
            frm.txtLastNumber.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["剩余座位"].ToString();
            frm.txtSeatMoney.Text = ds.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["票价"].ToString();
            frm.ShowDialog();
        }
    }
}
