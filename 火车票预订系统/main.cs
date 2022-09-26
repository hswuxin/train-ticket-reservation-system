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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        //节点递归调用
        string[] FindStr = { "添加用户", "添加车次", "删除车次" };
        private void FindNodes(TreeNode t)
        {
            if (t == null) return;
            foreach (string s1 in FindStr)
            {
                if (t.Text == s1)
                {
                    t.ForeColor = Color.Gray;
                    break;
                }
            }
            foreach (TreeNode child in t.Nodes)
            {
                FindNodes(child);//递归调用
            }
        }
        string username = login.user_name;//登录窗体传参已登录的账户名
        string userid = login.user_id;//登录窗体传参已登录的身份证号
        public int userRole = 1;
        DataSet ds = new DataSet();
        private void main_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();

            string s1 = string.Format(@"select * from userIM where UserName='{0}' or UserID='{1}'", username,userid);
            try
            {
                ds = DBAccess.EXE_ds(s1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            toolStripStatusLabel1.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["role"].ToString()) == 0)
            {
                toolStripStatusLabel2.Text = "管理员";
            }
            else
            {
                toolStripStatusLabel2.Text = "普通用户";
                //菜单禁止
                addTicket.Enabled = false;
                删除车次ToolStripMenuItem1.Enabled = false;
                添加用户ToolStripMenuItem.Enabled = false;
                //treeview失效
                FindNodes(treeView1.Nodes[0]);//根节点

            }
            toolStripStatusLabel3.Text = DateTime.Now.ToString();
            userRole =int.Parse(ds.Tables[0].Rows[0]["role"].ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepwd ch = new changepwd();
            ch.textBox1.Text = username;
            ch.textBox1.Enabled = false;
            ch.ShowDialog();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ForeColor == Color.Gray)
            {
                e.Cancel = true;
            }
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser frm = new addUser();
            frm.ShowDialog();
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addMoney am = new addMoney();
            am.username.Text = username;
            am.username.Enabled = false;
            am.ShowDialog();
        }

        private void 添加车次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCheck frm = new addCheck();
            frm.role = userRole;
            frm.ShowDialog();
        }

        private void 删除车次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTicket frm = new addTicket();
            frm.txtShiftID.Enabled = false;
            frm.ShowDialog();
        }

        private void 删除车次ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addTicket frm = new addTicket();
            frm.ShowDialog();
        }

        private void 退票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户订单查询ToolStripMenuItem_Click(sender, e);
        }
        
        private void 用户信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {                    
            userIinfo frm = new userIinfo();
            frm.label3.Text = username;
            frm.label4.Text = toolStripStatusLabel2.Text;
            string sql = string.Format("SELECT * FROM userIM where UserName='{0}'", username);
            DataSet cx = DBAccess.EXE_ds(sql);
            frm.txtloacl.Text = cx.Tables[0].Rows[0]["UserLocal"].ToString();
            frm.txtmoney.Text = cx.Tables[0].Rows[0]["UserMoney"].ToString();
            frm.ShowDialog();
        }

        private void 用户订单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userIM frm = new userIM();
            frm.username = username;
            frm.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "修改密码":
                    修改密码ToolStripMenuItem_Click(sender, e);
                    break;
                case "退出系统":
                    退出系统ToolStripMenuItem_Click(sender, e);
                    break;
                case "车票查询":
                    添加车次ToolStripMenuItem_Click(sender, e);
                    break;
                case "添加车次":
                    删除车次ToolStripMenuItem_Click(sender, e);
                    break;
                case "用户信息查询":
                    用户信息查询ToolStripMenuItem_Click(sender, e);
                    break;
                case "用户订单查询":
                    用户订单查询ToolStripMenuItem_Click(sender, e);
                    break;
                case "添加用户":
                    添加用户ToolStripMenuItem_Click(sender, e);
                    break;
                case "充值":
                    充值ToolStripMenuItem_Click(sender, e);
                    break;
                case "删除车次":
                    删除车次ToolStripMenuItem1_Click(sender, e);
                    break;
                case "购买车票":
                    购买车票ToolStripMenuItem_Click(sender, e);
                    break;
                case "退票":
                    退票ToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void 购买车票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            添加车次ToolStripMenuItem_Click(sender, e);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            修改密码ToolStripMenuItem_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            添加车次ToolStripMenuItem_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            用户订单查询ToolStripMenuItem_Click(sender, e);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            退出系统ToolStripMenuItem_Click(sender, e);
        }
    }
}
