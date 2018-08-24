using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class Dot : IPicture
    {
        Image img;

        int xCentre, yCentre, xPicture, yPicture;
        int sizeDots;

        public Dot(int xCentre, int yCentre, int sizeDots)
        {
            img = (new DotImg()).Img;

            this.xCentre = xCentre;
            this.yCentre = yCentre;

            this.sizeDots = sizeDots;
            
            NewPictureLocation();
        }

        void NewPictureLocation()
        {
            xPicture = xCentre - (sizeDots / 2);
            yPicture = yCentre - (sizeDots / 2);
        }

        public void Death()
        {
            xCentre = yCentre = -5;

            NewPictureLocation();
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
