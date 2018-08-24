using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class PacmanImg
    {
        Image[] left = { Properties.Resources.Pacman_10I, Properties.Resources.Pacman_10II };

        Image[] right = { Properties.Resources.Pacman10I, Properties.Resources.Pacman10II };

        Image[] up = { Properties.Resources.Pacman0_1I, Properties.Resources.Pacman0_1II };

        Image[] down = { Properties.Resources.Pacman01I, Properties.Resources.Pacman01II };

        Image[] repose = { Properties.Resources.Pacman10I };


        public Image[] Left
        {
            get
            {
                return left;
            }
        }

        public Image[] Right
        {
            get
            {
                return right;
            }
        }

        public Image[] Up
        {
            get
            {
                return up;
            }
        }

        public Image[] Down
        {
            get
            {
                return down;
            }
        }

        public Image[] Repose
        {
            get
            {
                return repose;
            }
        }
    }
}
