using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    class Pacman : IPicture, IRun
    {
        Image[] img;
        Image currentimg;

        int xCentre, yCentre, xPicture, yPicture;
        int direct_x, direct_y;
        int sizeObjects;
        int kx, ky;

        public Pacman(int xCentre, int yCentre, int sizeObjects)
        {
            this.xCentre = xCentre;
            this.yCentre = yCentre;

            direct_x = 0; direct_y = 0;

            kx = 0; ky = 0;

            this.sizeObjects = sizeObjects;
            
            NewPictureLocation();
        }


        void PutImg()
        {
            if (xCentre % (sizeObjects / 2) == 0)
                kx = 1;

            if (xCentre % sizeObjects == 0)
                kx = 0;

            if (yCentre % (sizeObjects / 2) == 0)
                ky = 1;

            if (yCentre % sizeObjects == 0)
                ky = 0;

            if (direct_x == -1 && direct_y == 0)
            {
                img = (new PacmanImg()).Left;
                currentimg = img[kx];
            }

            if (direct_x == 1 && direct_y == 0)
            {
                img = (new PacmanImg()).Right;
                currentimg = img[kx];
            }

            if (direct_x == 0 && direct_y == -1)
            {
                img = (new PacmanImg()).Up;
                currentimg = img[ky];
            }

            if (direct_x == 0 && direct_y == 1)
            {
                img = (new PacmanImg()).Down;
                currentimg = img[ky];
            }

            if (direct_x == 0 && direct_y == 0)
            {
                img = (new PacmanImg()).Repose;
                currentimg = img[0];
            }
        }

        void NewPictureLocation()
        {
            xPicture = xCentre - (sizeObjects / 2);
            yPicture = yCentre - (sizeObjects / 2);

            PutImg();
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
                return currentimg;
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
