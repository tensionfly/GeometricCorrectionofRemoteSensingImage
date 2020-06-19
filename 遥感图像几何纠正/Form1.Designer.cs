namespace 遥感图像几何纠正
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.遥感图像读入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纠正变换系数求解求ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同名点选取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相对配准数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绝对配准数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精度评定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算结果输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纠正变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_zoomin = new System.Windows.Forms.Button();
            this.button_zoomout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_x1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_y1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_x2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_y2 = new System.Windows.Forms.TextBox();
            this.button_write = new System.Windows.Forms.Button();
            this.button_output = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.检核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检核数据导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检核精度输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Aqua;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.遥感图像读入ToolStripMenuItem,
            this.纠正变换系数求解求ToolStripMenuItem,
            this.纠正变换ToolStripMenuItem,
            this.检核ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 遥感图像读入ToolStripMenuItem
            // 
            this.遥感图像读入ToolStripMenuItem.Name = "遥感图像读入ToolStripMenuItem";
            this.遥感图像读入ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.遥感图像读入ToolStripMenuItem.Text = "遥感图像读入";
            this.遥感图像读入ToolStripMenuItem.Click += new System.EventHandler(this.遥感图像读入ToolStripMenuItem_Click);
            // 
            // 纠正变换系数求解求ToolStripMenuItem
            // 
            this.纠正变换系数求解求ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同名点选取ToolStripMenuItem,
            this.参数计算ToolStripMenuItem,
            this.精度评定ToolStripMenuItem,
            this.计算结果输出ToolStripMenuItem});
            this.纠正变换系数求解求ToolStripMenuItem.Name = "纠正变换系数求解求ToolStripMenuItem";
            this.纠正变换系数求解求ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.纠正变换系数求解求ToolStripMenuItem.Text = "纠正系数求解";
            // 
            // 同名点选取ToolStripMenuItem
            // 
            this.同名点选取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相对配准数据ToolStripMenuItem,
            this.绝对配准数据ToolStripMenuItem});
            this.同名点选取ToolStripMenuItem.Name = "同名点选取ToolStripMenuItem";
            this.同名点选取ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.同名点选取ToolStripMenuItem.Text = "数据导入";
            // 
            // 相对配准数据ToolStripMenuItem
            // 
            this.相对配准数据ToolStripMenuItem.Name = "相对配准数据ToolStripMenuItem";
            this.相对配准数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.相对配准数据ToolStripMenuItem.Text = "相对配准数据";
            this.相对配准数据ToolStripMenuItem.Click += new System.EventHandler(this.相对配准数据ToolStripMenuItem_Click);
            // 
            // 绝对配准数据ToolStripMenuItem
            // 
            this.绝对配准数据ToolStripMenuItem.Name = "绝对配准数据ToolStripMenuItem";
            this.绝对配准数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.绝对配准数据ToolStripMenuItem.Text = "绝对配准数据";
            this.绝对配准数据ToolStripMenuItem.Click += new System.EventHandler(this.绝对配准数据ToolStripMenuItem_Click);
            // 
            // 参数计算ToolStripMenuItem
            // 
            this.参数计算ToolStripMenuItem.Name = "参数计算ToolStripMenuItem";
            this.参数计算ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.参数计算ToolStripMenuItem.Text = "参数计算";
            this.参数计算ToolStripMenuItem.Click += new System.EventHandler(this.参数计算ToolStripMenuItem_Click);
            // 
            // 精度评定ToolStripMenuItem
            // 
            this.精度评定ToolStripMenuItem.Name = "精度评定ToolStripMenuItem";
            this.精度评定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.精度评定ToolStripMenuItem.Text = "精度评定";
            this.精度评定ToolStripMenuItem.Click += new System.EventHandler(this.精度评定ToolStripMenuItem_Click);
            // 
            // 计算结果输出ToolStripMenuItem
            // 
            this.计算结果输出ToolStripMenuItem.Name = "计算结果输出ToolStripMenuItem";
            this.计算结果输出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.计算结果输出ToolStripMenuItem.Text = "计算结果输出";
            this.计算结果输出ToolStripMenuItem.Click += new System.EventHandler(this.计算结果输出ToolStripMenuItem_Click);
            // 
            // 纠正变换ToolStripMenuItem
            // 
            this.纠正变换ToolStripMenuItem.Name = "纠正变换ToolStripMenuItem";
            this.纠正变换ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.纠正变换ToolStripMenuItem.Text = "纠正变换";
            this.纠正变换ToolStripMenuItem.Click += new System.EventHandler(this.纠正变换ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(407, 436);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "参考图";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "原图";
            // 
            // button_zoomin
            // 
            this.button_zoomin.Location = new System.Drawing.Point(371, 35);
            this.button_zoomin.Name = "button_zoomin";
            this.button_zoomin.Size = new System.Drawing.Size(37, 23);
            this.button_zoomin.TabIndex = 5;
            this.button_zoomin.Text = "放大";
            this.button_zoomin.UseVisualStyleBackColor = true;
            this.button_zoomin.Click += new System.EventHandler(this.button_zoomin_Click);
            // 
            // button_zoomout
            // 
            this.button_zoomout.Location = new System.Drawing.Point(438, 34);
            this.button_zoomout.Name = "button_zoomout";
            this.button_zoomout.Size = new System.Drawing.Size(39, 23);
            this.button_zoomout.TabIndex = 6;
            this.button_zoomout.Text = "缩小";
            this.button_zoomout.UseVisualStyleBackColor = true;
            this.button_zoomout.Click += new System.EventHandler(this.button_zoomout_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 439);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(435, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 442);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "X:";
            // 
            // textBox_x1
            // 
            this.textBox_x1.Location = new System.Drawing.Point(54, 512);
            this.textBox_x1.Name = "textBox_x1";
            this.textBox_x1.Size = new System.Drawing.Size(52, 21);
            this.textBox_x1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 516);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Y:";
            // 
            // textBox_y1
            // 
            this.textBox_y1.Location = new System.Drawing.Point(170, 514);
            this.textBox_y1.Name = "textBox_y1";
            this.textBox_y1.Size = new System.Drawing.Size(57, 21);
            this.textBox_y1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(593, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "X:";
            // 
            // textBox_x2
            // 
            this.textBox_x2.Location = new System.Drawing.Point(619, 515);
            this.textBox_x2.Name = "textBox_x2";
            this.textBox_x2.Size = new System.Drawing.Size(52, 21);
            this.textBox_x2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(719, 521);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y:";
            // 
            // textBox_y2
            // 
            this.textBox_y2.Location = new System.Drawing.Point(751, 516);
            this.textBox_y2.Name = "textBox_y2";
            this.textBox_y2.Size = new System.Drawing.Size(54, 21);
            this.textBox_y2.TabIndex = 16;
            // 
            // button_write
            // 
            this.button_write.Location = new System.Drawing.Point(347, 515);
            this.button_write.Name = "button_write";
            this.button_write.Size = new System.Drawing.Size(62, 23);
            this.button_write.TabIndex = 17;
            this.button_write.Text = "录入";
            this.button_write.UseVisualStyleBackColor = true;
            this.button_write.Click += new System.EventHandler(this.button_write_Click);
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(437, 516);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(67, 23);
            this.button_output.TabIndex = 19;
            this.button_output.Text = "输出录入";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // 检核ToolStripMenuItem
            // 
            this.检核ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检核数据导入ToolStripMenuItem,
            this.检核精度输出ToolStripMenuItem});
            this.检核ToolStripMenuItem.Name = "检核ToolStripMenuItem";
            this.检核ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.检核ToolStripMenuItem.Text = "检核";
            // 
            // 检核数据导入ToolStripMenuItem
            // 
            this.检核数据导入ToolStripMenuItem.Name = "检核数据导入ToolStripMenuItem";
            this.检核数据导入ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.检核数据导入ToolStripMenuItem.Text = "检核数据导入";
            this.检核数据导入ToolStripMenuItem.Click += new System.EventHandler(this.检核数据导入ToolStripMenuItem_Click);
            // 
            // 检核精度输出ToolStripMenuItem
            // 
            this.检核精度输出ToolStripMenuItem.Name = "检核精度输出ToolStripMenuItem";
            this.检核精度输出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.检核精度输出ToolStripMenuItem.Text = "检核精度输出";
            this.检核精度输出ToolStripMenuItem.Click += new System.EventHandler(this.检核精度输出ToolStripMenuItem_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 570);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.button_write);
            this.Controls.Add(this.textBox_y2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_x2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_y1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_x1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_zoomout);
            this.Controls.Add(this.button_zoomin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "遥感图像几何纠正";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 遥感图像读入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纠正变换系数求解求ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同名点选取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 精度评定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纠正变换ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_zoomin;
        private System.Windows.Forms.Button button_zoomout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_x1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_y1;
        private System.Windows.Forms.ToolStripMenuItem 相对配准数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绝对配准数据ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_x2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_y2;
        private System.Windows.Forms.Button button_write;
        private System.Windows.Forms.Button button_output;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 计算结果输出ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 检核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检核数据导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检核精度输出ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
    }
}

