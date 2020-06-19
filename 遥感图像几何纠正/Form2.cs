using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 遥感图像几何纠正
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //在此窗口中的picturebox1中绘制纠正后的图像
        public void draw(string filename)
        {
            Image img12 = Image.FromFile(filename);
            this.pictureBox1.Size = img12.Size;
            this.pictureBox1.Image = img12;
        }

    }
}
