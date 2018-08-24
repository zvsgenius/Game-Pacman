using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class DotImg
    {
        Image img = Properties.Resources.dot;

        public Image Img
        {
            get
            {
                return img;
            }
        }
    }
}
