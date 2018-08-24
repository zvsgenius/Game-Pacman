using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class Wall : IPicture
    {
        Image img;

        int xCentre, yCentre, xPicture, yPicture;
        int sizeObjects;

        public Wall(int xCentre, int yCentre, int sizeObjects)
        {
            img = (new WallImg()).Img;
            
            this.xCentre = xCentre;
            this.yCentre = yCentre;

            this.sizeObjects = sizeObjects;

            xPicture = this.xCentre - (sizeObjects / 2);
            yPicture = this.yCentre - (sizeObjects / 2);
        }

        public Image Img
        {
            get
            {
                return img;
            }
        }

        public int XCentre
        {
            get
            {
                return xCentre;
            }
        }

        public int XPicture
        {
            get
            {
                return xPicture;
            }
        }

        public int YCentre
        {
            get
            {
                return yCentre;
            }
        }

        public int YPicture
        {
            get
            {
                return yPicture;
            }
        }
    }
}
