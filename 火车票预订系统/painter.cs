using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace 火车票预订系统
{
    class painter
    {
        public static void print_page(Graphics g, SolidBrush b, Font f, DataGridView dg, int x, int y, int w, int h, int k)
        {
            Pen p1 = new Pen(b);
            int y1 = y;
            for (int i = -1; i < dg.Rows.Count; i++)
            {
                int x1 = x;
                for (int j = 0; j < dg.Columns.Count; j++)
                {
                    if (i == -1)
                    {//表头
                        g.DrawString(dg.Columns[j].HeaderText,
                            f, b, new PointF(x1, y1));
                        g.DrawRectangle(p1, x1 - 5, y1 - 5, w, h);
                    }
                    else
                    {//数据项
                        if (j == k)
                        {
                            g.DrawString((DateTime.Parse(dg.Rows[i].Cells[j].Value.ToString()).ToShortDateString()),
                                f, b, new PointF(x1, y1));
                        }
                        else
                        {
                            g.DrawString(dg.Rows[i].Cells[j].Value.ToString(),
                                f, b, new PointF(x1, y1));
                        }
                        g.DrawRectangle(p1, x1 - 5, y1 - 5, w, h);
                    }
                    x1 += w;
                }
                y1 += h;
            }
            g.DrawString("打印时间:" + DateTime.Now.ToString(), f, b, new PointF(400, y1 + 20));
        }
    }
}
