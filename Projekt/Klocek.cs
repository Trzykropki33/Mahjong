using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mohjang
{
    [Serializable]
    internal class Klocek : PictureBox
    {
        public int id { get; set; }
        public bool select { get; private set; }
        public bool ReadyToClick { get; set; }

        public int Level { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public bool WasVisible { get; set; }
        public int Flaga { get; set; }

        public event EventHandler<Klocek> mouseClicked;
        public event EventHandler<Klocek> btnEnter;
        public event EventHandler<Klocek> btnLeave;

        
        public Klocek()
        {
            Location = new Point(0, 0);
            Height = 90;
            Width = 75;
            BackColor = Color.Maroon;
            BorderStyle = BorderStyle.Fixed3D;
            Text = "";
            PictureBox center = new PictureBox();
            center.Width = Width;
            center.Height = Height;
            center.Location = new Point(5, 5);
            center.BackColor = Color.FromArgb(0,0,0,0);
            center.MouseClick += mouse_Clicked;
            center.MouseEnter += btn_enter;
            center.MouseLeave += btn_leave;
            center.Paint += pictureBox1_Paint;
            this.Controls.Add(center);
            MouseEnter += btn_enter;
            MouseLeave += btn_leave;
            MouseClick += mouse_Clicked;
            ReadyToClick = false;
        }

       public void text_klocek()
        {
            this.Text = id.ToString() ;
        }

        public void btn_enter(object sender, EventArgs e)
        {
            btnEnter?.Invoke(this, this);
        }

        public void btn_leave(object sender, EventArgs e)
        {
            btnLeave?.Invoke(this, this);
        }

        public void mouse_Clicked(object sender, EventArgs e)
        {
            mouseClicked?.Invoke(this, this);
        }

        public void SelectKlocek(bool select)
        {
            this.select = select;
            this.BorderStyle = select ? BorderStyle.None : BorderStyle.Fixed3D;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            string assetsPath = Path.Combine(Application.StartupPath, "../../assets");
            string imagePath = Path.Combine(assetsPath, $"{id}.png");

            if (File.Exists(imagePath))
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    e.Graphics.DrawImage(image, new Rectangle(0, 0, Width-10, Height-10));
                }
            }
            else
            {
                using (Font myFont = new Font("Arial", 24))
                {
                    e.Graphics.DrawString("Image not found", myFont, Brushes.Red, new Point(15, 20));
                }
            }
        }

    }
}
