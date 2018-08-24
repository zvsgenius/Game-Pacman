using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class WallImg
    {
        Image img = Properties.Resources.Wall;

        public Image Img
        {
            get
            {
                return img;
            }
        }
    }
}
