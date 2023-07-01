using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Click_Square
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<PictureBox> items = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }
        private void MakePictureBox()
        {
            PictureBox picBox = new PictureBox();
            picBox.BackColor = Color.Purple;
            picBox.Height = 50;
            picBox.Width = 50;

            int x = random.Next(10, this.ClientSize.Width - picBox.Width);
            int y = random.Next(10, this.ClientSize.Height - picBox.Height);
            picBox.Location = new Point(x, y);
            picBox.Click += PicBox_Click;
            items.Add(picBox);
            this.Controls.Add(picBox);
        }
        private void PicBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            items.Remove(pictureBox);
            this.Controls.Remove(pictureBox);
            Label_Item.Text = "Items:" + items.Count();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MakePictureBox();
            Label_Item.Text = "Items:" + items.Count();
        }
    }
}
