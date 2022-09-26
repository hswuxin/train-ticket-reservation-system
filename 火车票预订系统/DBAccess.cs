using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using ThoughtWorks.QRCode.Codec;

namespace 火车票预订系统
{
    class DBAccess
    {
        //二维码
        public static string QrCode(string str1,string str2,string str3,string str4,string str5)
        {

            System.Drawing.Bitmap bt;
            string enCodeString = str1 + "\r\n" + str2 + "\r\n" + str3 + "\r\n" + str4 + "\r\n"+str5;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            qrCodeEncoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeBackgroundColor = Color.White;//背景色
            qrCodeEncoder.QRCodeForegroundColor = Color.Black;//前景色

            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

            string filename = login.user_name;
            string file_path =System.Environment.CurrentDirectory + @"\img\QRCode\";
            string codeUrl = file_path + filename + ".jpg";

            //根据文件名称，自动建立对应目录
            if (!System.IO.Directory.Exists(file_path))
                System.IO.Directory.CreateDirectory(file_path);

            bt.Save(codeUrl);//保存图片
            return codeUrl;
        }
        //MD5
        public static string md5(string str)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytValue, bytHash;
                bytValue = System.Text.Encoding.UTF8.GetBytes(str);
                bytHash = md5.ComputeHash(bytValue);
                md5.Clear();
                string sTemp = "";
                for (int i = 0; i < bytHash.Length; i++)
                {
                    sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
                }
                str = sTemp.ToLower();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return str;
        }
        //创建connection对象
        public static SqlConnection EXE_cn()
        {
            SqlConnection cn =
                new SqlConnection(@"server=.;database=demo;Integrated Security=SSPI");
            return cn;
        } 
        //断开式读数据
        public static DataSet EXE_ds(string strcmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(strcmd, EXE_cn());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static DataSet EXE_ds(string strcmd,string connstr)
        {
            SqlConnection cn = new SqlConnection(connstr);
            SqlDataAdapter da = new SqlDataAdapter(strcmd,cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //连接式访问读操作
        public static bool EXE_select(string strcmd)
        {
            SqlConnection cn=EXE_cn();
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();
                if (cmd.ExecuteReader().HasRows == true)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open  ) cn.Close();
            }
        }
        //连接式访问写操作
        public static bool EXE_update(string strcmd)
        {
            SqlConnection cn = EXE_cn();
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();
                cmd.ExecuteNonQuery();
                return true;                
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }
        public static bool EXE_update(string strcmd,string connstr)
        {
            SqlConnection cn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(strcmd, cn);
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }
        //执行select语句方法——ExecuteReader
        public static SqlDataReader ExeDataReader(string sqlText)
        {
            SqlConnection cn = EXE_cn();
            cn.Open();
            SqlCommand comm = new SqlCommand(sqlText, cn);
            return comm.ExecuteReader();
        }
    }
}
