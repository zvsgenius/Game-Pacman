using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class GhostImg
    {
        Image left = Properties.Resources.Ghost_10;

        Image right = Properties.Resources.Ghost10;

        Image up = Properties.Resources.Ghost0_1;

        Image down = Properties.Resources.Ghost01;


        public Image Left
        {
            get
            {
                return left;
            }
        }

        public Image Right
        {
            get
            {
                return right;
            }
        }

        public Image Up
        {
            get
            {
                return up;
            }
        }

        public Image Down
        {
            get
            {
                return down;
            }
        }
    }
}
