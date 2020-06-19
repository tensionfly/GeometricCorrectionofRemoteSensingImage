using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 遥感图像几何纠正
{
    public partial class Form1 : Form
    {
        Image img1;//定义参考图像变量
        Image img2;//定义原图变量
        private double[,] xy1 = new double[50, 2];//存储在picturebox1中图像上所选点的坐标
        private double[,] xy2 = new double[50, 2];//存储在picturebox2中图像上所选点的坐标
        private int count = 0;
        private int width1;//参考图的宽
        private int height1;//参考图的高
        private int width2;//原图的宽
        private int height2;//原图的高
        private int pointnum;//同名点个数
        private int checkpointnum = -1;//检核点个数
        private double[,] pointxy;//同名点坐标
        private double[,] checkpointxy;//检核点坐标

        private double[,] A;//矩阵A
        private double[,] Lx;//矩阵Lx
        private double[,] Ly;//矩阵Ly
        private double[,] delt_a=new double[6,1];//存储（x,y)=F(X,Y)的a系列参数
        private double[,] delt_b = new double[6, 1];//存储（x,y)=F(X,Y)的b系列参数
        private double[,] delt_a_ = new double[6, 1];//存储(X,Y)=F(x,y)的a系列参数
        private double[,] delt_b_ = new double[6, 1];//存储(X,Y)=F(x,y)的b系列参数
        private double delt_x;//（x,y)=F(X,Y)的x坐标精度
        private double delt_y;//（x,y)=F(X,Y)的y坐标精度

        private Bitmap Correction_map;//纠正后的图像

        public Form1()
        {
            InitializeComponent();
        }

        //矩阵求转置
        private static double[,] T(double[,] mat)
        {
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            double[,] mat_T = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mat_T[i, j] = mat[j, i];
                }
            }

            return mat_T;
        }

        //矩阵相乘
        public static double[,] Muti(double[,] mat1, double[,] mat2)
        {
            int m1 = mat1.GetLength(0);
            int n1 = mat1.GetLength(1);
            int m2 = mat2.GetLength(0);
            int n2 = mat2.GetLength(1);

            if (n1 != m2)
                MessageBox.Show("两矩阵不满足相乘条件！");
            
            double[,] mat_Muti = new double[m1, n2];
            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    double l = 0;
                    for (int k = 0; k < n1; k++)
                    {
                        l += mat1[i, k] * mat2[k, j];
                    }
                    mat_Muti[i, j] = l;
                }
            }

            return mat_Muti;
        }

        //矩阵相减
        private static double[,] Substr(double[,] mat1, double[,] mat2)
        {
            int m1 = mat1.GetLength(0);
            int n1 = mat1.GetLength(1);
            int m2 = mat2.GetLength(0);
            int n2 = mat2.GetLength(1);

            double[,] mat_Substr = new double[m1, n1];
            if(m1==m2&&n1==n2)
            {
                for(int i=0;i<m1;i++)
                {
                    for(int j=0;j<n1;j++)
                    {
                        mat_Substr[i, j] = mat1[i, j] - mat2[i, j];
                    }
                }
            }
            else MessageBox.Show("两矩阵不满足相减条件！");

            return mat_Substr;

        }

        //Givens变换求解待求参数
        private static double[,] Givens(double[,] B, double[,] L)
        {
            int m1 = B.GetLength(0);
            int n1 = B.GetLength(1);
            int m2 = L.GetLength(0);
            int n2 = L.GetLength(1);
            if (m1 != m2 || m1 < n1 || n2 != 1)
                MessageBox.Show("矩阵不满足Givens变换条件！");

            double[,] returnGivens = new double[n1, 1];
            double[,] Btwo = new double[2, n1];
            double[,] Ltwo = new double[2, 1];
            double[,] tran = new double[2, 2];
            double c, s;

            for (int i = 0; i < n1; i++)
            {
                for (int j = i + 1; j < m1; j++)
                {
                    if (B[j, i] != 0)
                    {
                        c = B[i, i] / Math.Sqrt(B[i, i] * B[i, i] + B[j, i] * B[j, i]);
                        s = B[j, i] / Math.Sqrt(B[i, i] * B[i, i] + B[j, i] * B[j, i]);

                        tran[0, 0] = c;
                        tran[0, 1] = s;
                        tran[1, 0] = -s;
                        tran[1, 1] = c;

                        for (int a = 0; a < n1; a++)
                        {
                            Btwo[0, a] = B[i, a];
                            Btwo[1, a] = B[j, a];
                        }

                        Ltwo[0, 0] = L[i, 0];
                        Ltwo[1, 0] = L[j, 0];

                        Btwo = Muti(tran, Btwo);
                        Ltwo = Muti(tran, Ltwo);

                        for (int a = 0; a < n1; a++)
                        {
                            B[i, a] = Btwo[0, a];
                            B[j, a] = Btwo[1, a];
                        }

                        L[i, 0] = Ltwo[0, 0];
                        L[j, 0] = Ltwo[1, 0];
                    }
                }
            }

            for (int i = n1 - 1; i >= 0; i--)
            {
                double g = 0;
                for (int j = n1 - 1; j > i; j--)
                {
                    g += B[i, j] * returnGivens[j, 0];
                }
                returnGivens[i, 0] = (L[i, 0] - g) / B[i, i];
            }
            return returnGivens;

        }

        //图像双线性插值缩放处理
        public Image pictrueprocess(Image img,double v)
        {
            int NW=(int)(img.Width*v);
            int NH=(int)(img.Height*v);

            Bitmap newbitmap = new Bitmap(NW,NH);
            Bitmap oldbitmap = (Bitmap)img;
            int r, g, b;

            for (int x = 0; x < NW;x++ )
            {
                for(int y=0;y<NH;y++)
                {
                    double xv, yv;
                    xv = x*1.0 / v;
                    yv = y * 1.0 / v;
                    int intxv = (int)xv;
                    int intyv = (int)yv;
                   
                    if(intxv>=0&&intyv>=0&&intxv<img.Width-1&&intyv<img.Height-1)
                    {
                        Color pixel1 = oldbitmap.GetPixel(intxv, intyv);
                        Color pixel2 = oldbitmap.GetPixel(intxv + 1, intyv);
                        Color pixel3 = oldbitmap.GetPixel(intxv, intyv + 1);
                        Color pixel4 = oldbitmap.GetPixel(intxv + 1, intyv + 1);

                        r = (int)((pixel1.R * (intxv + 1 - xv) + pixel2.R * (xv - intxv)) * (intyv + 1 - yv) +
                            (pixel3.R * (intxv + 1 - xv) + pixel4.R * (xv - intxv)) * (yv - intyv));
                        g = (int)((pixel1.G * (intxv + 1 - xv) + pixel2.G * (xv - intxv)) * (intyv + 1 - yv) +
                            (pixel3.G * (intxv + 1 - xv) + pixel4.G * (xv - intxv)) * (yv - intyv));
                        b = (int)((pixel1.B * (intxv + 1 - xv) + pixel2.B * (xv - intxv)) * (intyv + 1 - yv) +
                            (pixel3.B * (intxv + 1 - xv) + pixel4.B * (xv - intxv)) * (yv - intyv));

                        newbitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                    else
                    {
                        newbitmap.SetPixel(x, y, Color.FromArgb(0,0,0));
                    }

                }
            }

            img = newbitmap;
            return img;
        }

        //由X,Y求x,y
        private double[] FXY(int X,int Y)
        {
            double[] xy = new double[2];

            xy[0] = delt_a[0, 0] + delt_a[1, 0] * X + delt_a[2, 0] * Y 
                   + delt_a[3, 0] * X * X + delt_a[4, 0] * X * Y + delt_a[5, 0] * Y * Y;
            xy[1] = delt_b[0, 0] + delt_b[1, 0] * X + delt_b[2, 0] * Y
                   + delt_b[3, 0] * X * X + delt_b[4, 0] * X * Y + delt_b[5, 0] * Y * Y;
            
            return xy;
        }

        //利用求得的x,y双线性插值的X,Y的RGB值
        private int[] RGB(double[] xy,Image img_ori)
        {
            int wd_ori=img_ori.Width;
            int hg_ori=img_ori.Height;

            Bitmap map_ori = (Bitmap)(img_ori);
            int[] rgb = new int[3];

            double x = xy[0];
            double y = xy[1];

            int intx=(int)x;
            int inty = (int)y;

            if(x<0||x>wd_ori-1||y<0||y>hg_ori-1)
            {
                rgb[0] = rgb[1] = rgb[2] = 255;
            }
            else if (x != wd_ori - 1 && y != hg_ori - 1)
            {
                Color pixel1 = map_ori.GetPixel(intx, inty);
                Color pixel2 = map_ori.GetPixel(intx + 1, inty);
                Color pixel3 = map_ori.GetPixel(intx, inty + 1);
                Color pixel4 = map_ori.GetPixel(intx + 1, inty + 1);

                rgb[0] = (int)((pixel1.R * (intx + 1 - x) + pixel2.R * (x - intx)) * (inty + 1 - y) +
                           (pixel3.R * (intx + 1 - x) + pixel4.R * (x - intx)) * (y - inty));
                rgb[1] = (int)((pixel1.G * (intx + 1 - x) + pixel2.G * (x - intx)) * (inty + 1 - y) +
                           (pixel3.G * (intx + 1 - x) + pixel4.G * (x - intx)) * (y - inty));
                rgb[2] = (int)((pixel1.B * (intx + 1 - x) + pixel2.B * (x - intx)) * (inty + 1 - y) +
                           (pixel3.B * (intx + 1 - x) + pixel4.B * (x - intx)) * (y - inty));

            }
            else if (x == wd_ori - 1 && y != hg_ori - 1)
            {
                Color pixel1 = map_ori.GetPixel(intx, inty);
                Color pixel2 = map_ori.GetPixel(intx, inty+1);

                rgb[0] = (int)(pixel1.R * (inty + 1 - y) + pixel2.R * (y - inty));
                rgb[1] = (int)(pixel1.G * (inty + 1 - y) + pixel2.G * (y - inty));
                rgb[2] = (int)(pixel1.B * (inty + 1 - y) + pixel2.B * (y - inty));
            }
            else if (x != wd_ori - 1 && y == hg_ori - 1)
            {
                Color pixel1 = map_ori.GetPixel(intx, inty);
                Color pixel2 = map_ori.GetPixel(intx+1, inty);

                rgb[0] = (int)(pixel1.R * (intx + 1 - x) + pixel2.R * (x - intx));
                rgb[1] = (int)(pixel1.G * (intx + 1 - x) + pixel2.G * (x - intx));
                rgb[2] = (int)(pixel1.B * (intx + 1 - x) + pixel2.B * (x - intx));
            }
            else if (x == wd_ori - 1 && y == hg_ori - 1)
            {
                Color pixel= map_ori.GetPixel(intx,inty);

                rgb[0] = pixel.R;
                rgb[1] = pixel.G;
                rgb[2] = pixel.B;

            }

            return rgb;
        }




        //遥感图像读入
        private void 遥感图像读入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img1 = Image.FromFile(@"wuce.tif");
            this.pictureBox1.Size = img1.Size;
            this.pictureBox1.Image = img1;
            width1 = img1.Width;
            height1 = img1.Height;

            Image img2 = Image.FromFile(@"wucesource.tif");
            this.pictureBox2.Size = img2.Size;
            this.pictureBox2.Image = img2;
            width2 = img2.Width;
            height2 = img2.Height;

        }

        //遥感图像放大处理
        private void button_zoomin_Click(object sender, EventArgs e)
        {
            Image img11 = pictrueprocess(this.pictureBox1.Image, 2);
            this.pictureBox1.Image = img11;
            Image img21 = pictrueprocess(this.pictureBox2.Image, 2);
            this.pictureBox2.Image = img21;

        }

        //遥感图像缩小处理
        private void button_zoomout_Click(object sender, EventArgs e)
        {
            Image img12 = pictrueprocess(this.pictureBox1.Image, 0.5);
            this.pictureBox1.Image = img12;
            Image img22 = pictrueprocess(this.pictureBox2.Image, 0.5);
            this.pictureBox2.Image = img22;
        }

        //鼠标单击选点
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_x1.Text = e.X.ToString();
            textBox_y1.Text = e.Y.ToString();

            Graphics g1 = pictureBox1.CreateGraphics();
            PointF pt = new PointF(e.X, e.Y);
            PointF[] Pts = new PointF[3]{
            new PointF(pt.X,pt.Y),
            new PointF(pt.X-8,pt.Y+8),
            new PointF(pt.X+8,pt.Y+8)
            };
            g1.DrawPolygon(Pens.Black, Pts);
            g1.FillPolygon(new SolidBrush(Color.Red), Pts);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_x2.Text = e.X.ToString();
            textBox_y2.Text = e.Y.ToString();

            Graphics g2 = pictureBox2.CreateGraphics();
            PointF pt = new PointF(e.X, e.Y);
            PointF[] Pts = new PointF[3]{
            new PointF(pt.X,pt.Y),
            new PointF(pt.X-8,pt.Y+8),
            new PointF(pt.X+8,pt.Y+8)
            };
            g2.DrawPolygon(Pens.Black, Pts);
            g2.FillPolygon(new SolidBrush(Color.Red), Pts);
        }

        //同名点坐标录入
        private void button_write_Click(object sender, EventArgs e)
        {
            int wd1, hg1,wd2,hg2;
            wd1 = this.pictureBox1.Image.Width;
            hg1 = this.pictureBox1.Image.Height;
            wd2 = this.pictureBox2.Image.Width;
            hg2 = this.pictureBox2.Image.Height;

            xy1[count, 0] = Convert.ToInt32(textBox_x1.Text)*width1*1.0/wd1;
            xy1[count, 1] = Convert.ToInt32(textBox_y1.Text) * height1 * 1.0 / hg1;

            xy2[count, 0] = Convert.ToInt32(textBox_x2.Text) * width2 * 1.0 / wd2;
            xy2[count, 1] = Convert.ToInt32(textBox_y2.Text) * height2 * 1.0 / hg2;

            count++;
            MessageBox.Show("第"+count.ToString()+"对同名点坐标数据录入成功！");
        }

        //录入的同名点对坐标的输出
        private void button_output_Click(object sender, EventArgs e)
        {
             saveFileDialog1.Filter = "文本文件（*.txt)|*.txt";
             if (saveFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                 sw.Write("X1:" + "    " + "Y1:" + "    " + "X2:" + "    " + "Y2:" + "    " + "\r\n");
                 for (int i = 0; i < count;i++)
                 {
                     sw.Write(xy1[i, 0].ToString() + "  " + xy1[i, 1].ToString() + "  "
                              + xy2[i, 0].ToString() + "  " + xy2[i, 1].ToString() + "\r\n");
                 }
                 sw.Close();
                 MessageBox.Show("数据保存成功！");
             }
        }

        //导入相对配准数据
        private void 相对配准数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointnum = -1;
            openFileDialog1.Filter = "文本文件（*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader src = new StreamReader(openFileDialog1.FileName);//计算有多少行
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string str;
                while ((str = src.ReadLine()) != null)
                {
                    pointnum++;
                }
                pointxy = new double[pointnum, 4];

                int k=0;
                str = sr.ReadLine();
                while ((str = sr.ReadLine()) != null)
                {
                    str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
                    string[] str1 = str.Split(new char[] { ' ' });
                    for (int i = 0; i < str1.Length; i++)
                    {
                        pointxy[k, i] = Convert.ToDouble(str1[i]);
                    }
                    k++;
                }

            }
            MessageBox.Show("数据导入完成！");
        }

        //导入绝对配准数据
        private void 绝对配准数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointnum = -1;
            openFileDialog2.Filter = "文本文件（*.txt)|*.txt";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamReader src = new StreamReader(openFileDialog2.FileName);//计算有多少行
                StreamReader sr = new StreamReader(openFileDialog2.FileName);
                string str;
                while ((str = src.ReadLine()) != null)
                {
                    pointnum++;
                }
                pointxy = new double[pointnum, 4];

                int k = 0;
                str = sr.ReadLine();
                while ((str = sr.ReadLine()) != null)
                {
                    str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
                    string[] str1 = str.Split(new char[] { ' ' });
                    for (int i = 0; i < str1.Length; i++)
                    {
                        pointxy[k, i] = Convert.ToDouble(str1[i]);
                    }
                    k++;
                }

            }
            MessageBox.Show("数据导入完成！");
        }

        //参数计算
        private void 参数计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A = new double[pointnum, 6];
            double[,] A_ = new double[pointnum, 6];
            for(int i=0;i<pointnum;i++)
            {
                A[i, 0] = 1;
                A[i, 1] = pointxy[i, 0];
                A[i, 2] = pointxy[i, 1];
                A[i, 3] = pointxy[i, 0] * pointxy[i, 0];
                A[i, 4] = pointxy[i, 0] * pointxy[i, 1];
                A[i, 5] = pointxy[i, 1] * pointxy[i, 1];


                A_[i, 0] = 1;
                A_[i, 1] = pointxy[i, 2];
                A_[i, 2] = pointxy[i, 3];
                A_[i, 3] = pointxy[i, 2] * pointxy[i, 2];
                A_[i, 4] = pointxy[i, 2] * pointxy[i, 3];
                A_[i, 5] = pointxy[i, 3] * pointxy[i, 3];


            }

            double[,] AT = T(A);
            double[,] A_T = T(A_);

            Lx = new double[pointnum, 1];
            Ly = new double[pointnum, 1];
            double[,] Lx_ = new double[pointnum, 1];
            double[,] Ly_ = new double[pointnum, 1];

            for(int i=0;i<pointnum;i++)
            {
                Lx[i, 0] = pointxy[i, 2];
                Ly[i, 0] = pointxy[i, 3];

                Lx_[i, 0] = pointxy[i, 0];
                Ly_[i, 0] = pointxy[i, 1];
            }

            double[,] ATLx = Muti(AT, Lx);
            double[,] ATLy = Muti(AT, Ly);
            double[,] A_TLx_ = Muti(A_T, Lx_);
            double[,] A_TLy_ = Muti(A_T, Ly_);

            double[,] ATAa = Muti(AT, A);
            double[,] ATAb = Muti(AT, A);
            double[,] ATAa_ = Muti(A_T, A_);
            double[,] ATAb_ = Muti(A_T, A_);

            delt_a = Givens(ATAa, ATLx);
            delt_b = Givens(ATAb, ATLy);
            delt_a_ = Givens(ATAa_, A_TLx_);
            delt_b_ = Givens(ATAb_, A_TLy_);

            MessageBox.Show("参数计算完成！");

        }

        //精度评定
        private void 精度评定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[,] Vx = new double[pointnum, 1];
            double[,] Vy = new double[pointnum, 1];

            double[,] Aa = Muti(A, delt_a);
            double[,] Ab = Muti(A, delt_b);

            Vx = Substr(Aa, Lx);
            Vy = Substr(Ab, Ly);

            double[,] VxT = T(Vx);
            double[,] VyT = T(Vy);

            double[,] VxTVx = Muti(VxT, Vx);
            double[,] VyTVy = Muti(VyT, Vy);

            delt_x = Math.Sqrt(VxTVx[0, 0] / (pointnum - 6));
            delt_y = Math.Sqrt(VyTVy[0, 0] / (pointnum - 6));
            MessageBox.Show("精度评定完成！");
        }

        //参数及精度评定结果的输出
        private void 计算结果输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog2.Filter = "文本文件（*.txt)|*.txt";
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog2.FileName);
                sw.Write("a0:" + delt_a[0, 0].ToString() + "\r\n");
                sw.Write("a1:" + delt_a[1, 0].ToString() + "\r\n");
                sw.Write("a2:" + delt_a[2, 0].ToString() + "\r\n");
                sw.Write("a3:" + delt_a[3, 0].ToString() + "\r\n");
                sw.Write("a4:" + delt_a[4, 0].ToString() + "\r\n");
                sw.Write("a5:" + delt_a[5, 0].ToString() + "\r\n");

                sw.Write("\r\n");

                sw.Write("b0:" + delt_b[0, 0].ToString() + "\r\n");
                sw.Write("b1:" + delt_b[1, 0].ToString() + "\r\n");
                sw.Write("b2:" + delt_b[2, 0].ToString() + "\r\n");
                sw.Write("b3:" + delt_b[3, 0].ToString() + "\r\n");
                sw.Write("b4:" + delt_b[4, 0].ToString() + "\r\n");
                sw.Write("b5:" + delt_b[5, 0].ToString() + "\r\n");

                sw.Write("\r\n");

                sw.Write("delt_x: " + "+-" + delt_x.ToString()+"\r\n");
                sw.Write("delt_y: " + "+-" + delt_y.ToString() + "\r\n");
                sw.Close();
            }
            MessageBox.Show("计算结果输出完成！");
        }

        //图像纠正处理、纠正图像的存储以及纠正图像的显示
        private void 纠正变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(@"wucesource.tif");
            int ori_width = img.Width;
            int ori_height = img.Height;

            int[,] orixy = new int[4, 2];
            orixy[0, 0] = 0;
            orixy[0, 1] = 0;
            orixy[1, 0] = ori_width-1;
            orixy[1, 1] = 0;
            orixy[2, 0] = ori_width-1;
            orixy[2, 1] = ori_height-1;
            orixy[3, 0] = 0;
            orixy[3, 1] = ori_height-1;

            int[,] correctxy = new int[4, 2];
            for(int i=0;i<4;i++)
            {
                correctxy[i, 0] =(int)( delt_a_[0, 0] + delt_a_[1, 0] * orixy[i, 0] + delt_a_[2, 0] * orixy[i, 1] + delt_a_[3, 0] * orixy[i, 0] * orixy[i, 0] 
                                  + delt_a_[4, 0] * orixy[i, 0] * orixy[i, 1] + delt_a_[5, 0] * orixy[i, 1] * orixy[i, 1]);
                correctxy[i, 1] = (int)(delt_b_[0, 0] + delt_b_[1, 0] * orixy[i, 0] + delt_b_[2, 0] * orixy[i, 1] + delt_b_[3, 0] * orixy[i, 0] * orixy[i, 0]
                                  + delt_b_[4, 0] * orixy[i, 0] * orixy[i, 1] + delt_b_[5, 0] * orixy[i, 1] * orixy[i, 1]);
            }
            //纠正后范围确定
            int max_X, max_Y, min_X, min_Y;
            max_X = Math.Max(Math.Max(correctxy[0, 0], correctxy[1, 0]), Math.Max(correctxy[2, 0], correctxy[3, 0]));
            max_Y = Math.Max(Math.Max(correctxy[0, 1], correctxy[1, 1]), Math.Max(correctxy[2, 1], correctxy[3, 1]));
            min_X = Math.Min(Math.Min(correctxy[0, 0], correctxy[1, 0]), Math.Min(correctxy[2, 0], correctxy[3, 0]));
            min_Y = Math.Min(Math.Min(correctxy[0, 1], correctxy[1, 1]), Math.Min(correctxy[2, 1], correctxy[3, 1]));

            int correction_width = max_X - min_X;
            int correction_height = max_Y - min_Y;

            Correction_map = new Bitmap(correction_width, correction_height);
            //逐点纠正
            for(int i=0;i<correction_width;i++)
            {
                for(int j=0;j<correction_height;j++)
                {
                    double[] xy = FXY(i+min_X, j+min_Y);
                    int[] rgb = RGB(xy,img);
                    Correction_map.SetPixel(i, j, Color.FromArgb(rgb[0], rgb[1], rgb[2]));

                }
            }

            Correction_map.Save("Correction_map.bmp");//存储纠正后的图像
            Form2 form2 = new Form2();//实例化Form2窗体
            form2.Show();//显示实例化后的窗体
            form2.draw("Correction_map.bmp");//纠正后图像的绘制

        }

        private void 检核数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog3.Filter = "文本文件（*.txt)|*.txt";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                StreamReader src = new StreamReader(openFileDialog3.FileName);//计算有多少行
                StreamReader sr = new StreamReader(openFileDialog3.FileName);
                string str;
                while ((str = src.ReadLine()) != null)
                {
                    checkpointnum++;
                }
                checkpointxy = new double[checkpointnum, 4];

                int k = 0;
                str = sr.ReadLine();
                while ((str = sr.ReadLine()) != null)
                {
                    str = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(str, " ");
                    string[] str1 = str.Split(new char[] { ' ' });
                    for (int i = 0; i < str1.Length; i++)
                    {
                        checkpointxy[k, i] = Convert.ToDouble(str1[i]);
                    }
                    k++;
                }

            }
            MessageBox.Show("检核数据导入完成！");
        }

        private void 检核精度输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double checkdelt_x, checkdelt_y;

            checkdelt_x = checkdelt_y = 0;

            double x,y;
            for(int i=0;i<checkpointnum;i++)
            {
                x=checkpointxy[i,2]-(delt_a[0,0]+delt_a[1,0]*checkpointxy[i,0]+delt_a[2,0]*checkpointxy[i,1]
                    +delt_a[3,0]*checkpointxy[i,0]*checkpointxy[i,0]+delt_a[4,0]*checkpointxy[i,0]*checkpointxy[i,1]
                    +delt_a[5,0]*checkpointxy[i,1]*checkpointxy[i,1]);
                checkdelt_x += x * x;

                y = checkpointxy[i, 3] - (delt_b[0, 0] + delt_b[1, 0] * checkpointxy[i, 0] + delt_b[2, 0] * checkpointxy[i, 1]
                    + delt_b[3, 0] * checkpointxy[i, 0] * checkpointxy[i, 0] + delt_b[4, 0] * checkpointxy[i, 0] * checkpointxy[i, 1]
                    + delt_b[5, 0] * checkpointxy[i, 1] * checkpointxy[i, 1]);
                checkdelt_y += y * y;
            }

            checkdelt_x = Math.Sqrt(checkdelt_x / checkpointnum);
            checkdelt_y = Math.Sqrt(checkdelt_y / checkpointnum);

            saveFileDialog3.Filter = "文本文件（*.txt)|*.txt";
            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog3.FileName);

                sw.Write("checkdelt_x: " + "+-" + checkdelt_x.ToString() + "\r\n");
                sw.Write("checkdelt_y: " + "+-" + checkdelt_y.ToString() + "\r\n");
                sw.Close();
            }

            MessageBox.Show("检核精度输出完成！");
        }

    }
}
