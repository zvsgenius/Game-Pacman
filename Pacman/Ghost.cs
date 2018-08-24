using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class Ghost : IPicture, IRun
    {
        Image img;

        int xCentre, yCentre, xPicture, yPicture;
        int direct_x, direct_y;
        int sizeObjects;

        public Ghost(int xCentre, int yCentre, int sizeObjects)
        {            
            this.xCentre = xCentre;
            this.yCentre = yCentre;

            direct_x = 0;
            direct_y = -1;

            this.sizeObjects = sizeObjects;

            NewPictureLocation();
        }

        private void PutImg()
        {
            if(direct_x == -1 && direct_y == 0)
                img = (new GhostImg()).Left;

            if (direct_x == 1 && direct_y == 0)
                img = (new GhostImg()).Right;

            if (direct_x == 0 && direct_y == -1)
                img = (new GhostImg()).Up;

            if (direct_x == 0 && direct_y == 1)
                img = (new GhostImg()).Down;
        }

        private void NewPictureLocation()
        {
            PutImg();

            xPicture = xCentre - (sizeObjects / 2);
            yPicture = yCentre - (sizeObjects / 2);
        }

        public void Run()
        {
            xCentre += direct_x;
            yCentre += direct_y;

            NewPictureLocation();
        }
        public void Run(int direct_x, int direct_y)
        {
            this.direct_x = direct_x;
            this.direct_y = direct_y;

            Run();
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

        public int Direct_x
        {
            get
            {
                return direct_x;
            }
        }

        public int Direct_y
        {
            get
            {
                return direct_y;
            }
        }
    }
}
