using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _1131418_杜語喬_poker
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }
        private Image GetImage(int num)
        {
            return GetImage($"pic{num}");
        }
   
        private void btnTest_Click(object sender, EventArgs e)
        {
            //產生1~53的亂數，對應撲克牌的52張圖
            Random random = new Random();
            //從資源檔中取出對應的圖，並顯示在picTest上
            int picNum = random.Next(1, 53);
            this.picTest.Image = GetImage(picNum);
            lblNum.Text = picNum.ToString();
        }

        private void picTest_Click(object sender, EventArgs e)
        {
            this.picTest.Image = GetImage("back");
        }

 
    }
}
