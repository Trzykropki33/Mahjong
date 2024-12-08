using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohjang
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Menager Menago;
        
        public Form1()
        {
            InitializeComponent();
            this.Height = 910;
            this.Width = 950;
            this.CenterToScreen();
            this.Name = "Mahjong";
            this.Text = "Mahjong";
            string assetsPath = Path.Combine(Application.StartupPath, "../../assets/pattern.png");

            if (File.Exists(assetsPath))
            {
                using (Image image = Image.FromFile(assetsPath))
                {
                    this.BackgroundImage = new Bitmap(image);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else
            { 
                MessageBox.Show("Background image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AssignClickHandlers(menuStrip1.Items);

            Menago = new Menager(this);
            

        }

        private void AssignClickHandlers(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Click += MenuItem_Click;
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        AssignClickHandlers(menuItem.DropDownItems);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Menago.init();
        }

        public void Label_change(string label,string newText)
        {
            switch (label)
            {
                case "CZAS":
                    label1.Text = newText;
                    break;
                case "STONES":
                    label2.Text = newText;
                    break;

            }
        }


        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                string optionName = clickedItem.Text;
                Menago.HandleMenuSelection(optionName.ToLower());
            }
        }

        public void end()
        {
            var res = MessageBox.Show("YOU WINN!!!!\nNEW GAME?","YOU WIN",MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Menago.HandleMenuSelection("nowa");
            }
            else {
                Application.Exit();
            }
        }
    }
}