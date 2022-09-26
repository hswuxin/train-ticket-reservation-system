using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace 火车票预订系统
{
    public partial class userIM : Form
    {
        public userIM()
        {
            InitializeComponent();
        }
        DataSet dr = new DataSet();
        public string username = "";
        void displaydb()
        {
            string sql = string.Format("select OrderNumber 订单号,UserName 用户名,ShiftID 班次号,TrainID 车次号,Origin 始发地,Destination 目的地,Ctime 发车时间,Dtime 到达时间,SearchNumber 座位号 from IM where UserName='{0}'", login.user_name);
            try
            {
                dr = DBAccess.EXE_ds(sql);
                dataGridView1.DataSource = dr.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void userIM_Load(object sender, EventArgs e)
        {
            displaydb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ordernumber =int.Parse(dr.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["订单号"].ToString());
            string shitid = dr.Tables[0].Rows[dataGridView1.CurrentCell.RowIndex]["班次号"].ToString();
            string sql = string.Format("delete from IM where OrderNumber='{0}'", ordernumber);
            string sql2 = string.Format("delete from SearchSeat where ShiftID='{0}'", shitid);
            string sql3 = string.Format("update Ticket set LastNumber=LastNumber+1 where ShiftID='{0}'", shitid);
            string addmoney = string.Format("SELECT * FROM Ticket WHERE ShiftID ={0}", shitid);
            try
            {
                DataSet am = DBAccess.EXE_ds(addmoney);
                string addmoney2 = string.Format("UPDATE userIM SET UserMoney=UserMoney +{0} WHERE UserName='{1}'", int.Parse(am.Tables[0].Rows[0]["SeatMoney"].ToString()), login.user_name);
                DBAccess.EXE_update(addmoney2);
                DBAccess.EXE_update(sql);
                DBAccess.EXE_update(sql2);
                DBAccess.EXE_update(sql3);
                MessageBox.Show("退票成功");
                displaydb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog()== DialogResult.OK)
            {
                this.printPreviewDialog1.Document = this.printDocument1;
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 800, 400);
                this.printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
                this.printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Pen p1 = new Pen(brush);
            Font f1 = new Font("黑体", 16);
            Font f2 = new Font("楷体", 10);
            Font f3 = new Font("楷体", 20);
            Font f4 = new Font("黑体", 12);
            //g.DrawString(login.user_name, f1, brush, new PointF(100, 50));
            int rowindex=dataGridView1.CurrentRow.Index;
            string orgin = dataGridView1.Rows[rowindex].Cells["始发地"].Value.ToString();
            string des=dataGridView1.Rows[rowindex].Cells["目的地"].Value.ToString();
            string trainid=dataGridView1.Rows[rowindex].Cells["车次号"].Value.ToString();
            //
            g.DrawString(dataGridView1.Rows[rowindex].Cells["订单号"].Value.ToString(), f2, redBrush, 100, 50);
            g.DrawString(orgin, f3, brush, 250, 105);
            g.DrawString(des, f3, brush, 500, 105);
            g.DrawString(trainid, f4, brush, 390, 110);
            Image img=Image.FromFile(System.Environment.CurrentDirectory+@"\img\箭头.png");
            g.DrawImage(img,380,128,60,5);
            string str = dataGridView1.Rows[rowindex].Cells["发车时间"].Value.ToString();
            string year = str.Substring(0, 4);
            string month = str.Substring(5, 2);
            string date = str.Substring(8, 2);
            string hour = str.Substring(11);
            g.DrawString(year+"年"+month+"月"+date+"日"+hour+"开", f4, brush, 250, 160);
            g.DrawString(dataGridView1.Rows[rowindex].Cells["座位号"].Value.ToString()+" 座", f4, brush, 500, 160);
            DataSet mm = DBAccess.EXE_ds(string.Format("SELECT * FROM Ticket WHERE ShiftID ={0}", dataGridView1.Rows[rowindex].Cells["班次号"].Value.ToString()));
            string money = mm.Tables[0].Rows[0]["SeatMoney"].ToString().Trim();
            g.DrawString("￥"+money+"元", f4, brush, 250, 200);
            g.DrawString("限乘当日车次", f4, brush, 250, 240);
            g.DrawString(login.user_name+"\t"+"在线购买", f4, brush, 250, 280);
            Image img2 = Image.FromFile(System.Environment.CurrentDirectory + @"\img\火车.png");
            g.DrawImage(img2, 720, 20,50,50);
            try
            {
                Image img3 = Image.FromFile(DBAccess.QrCode(login.user_name,trainid,orgin,des,str));
                g.DrawImage(img3, 700, 300, 80, 80);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
