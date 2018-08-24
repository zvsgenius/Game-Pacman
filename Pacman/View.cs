using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Pacman
{
    partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }

        private void Draw(PaintEventArgs e)
        {         
            DrawWalls(e);
            DrawDots(e);
            DrawGhosts(e);
            DrawPacman(e);

            if (model.gameStatus != GameStatus.playing)
                return;

            Thread.Sleep(model.SpeedGame);
            Invalidate();
        }

        void DrawGhosts(PaintEventArgs e)
        {
            foreach (Ghost a in model.Ghosts)
            {
                e.Graphics.DrawImage(a.Img, new Point(a.XPicture, a.YPicture));
            }
        }

        void DrawPacman(PaintEventArgs e)
        {
           e.Graphics.DrawImage(model.Pacman.Img, new Point(model.Pacman.XPicture, model.Pacman.YPicture));
        }

        void DrawDots(PaintEventArgs e)
        {
            foreach (Dot a in model.Dots)
            {
                e.Graphics.DrawImage(a.Img, new Point(a.XPicture, a.YPicture));
            }
        }

        void DrawWalls(PaintEventArgs e)
        {
            foreach(Wall a in model.Walls)
            {
                e.Graphics.DrawImage(a.Img, new Point(a.XPicture, a.YPicture));
            }
        }
    }
}
