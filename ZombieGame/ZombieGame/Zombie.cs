using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ZombieGame
{
    class Zombie
    {
        //declare fields to use in the class
        public int x, y, width, height;
        public Rectangle zombieRec;
        public Image zombieImage;

        //zombie
        //set x to spacing y to -20, width 20 height 20
        //Get the zombie image from files
        //set rectangle to x,y,width and height
        public Zombie(int xspacing, int yspacing)
        {
            x = xspacing;
            y = yspacing;
            width = 20;
            height = 20;
            zombieImage = Image.FromFile("Zombie1.png");
            zombieRec = new Rectangle(x, y, width, height);
        }

        //methods for the zombie class
        //draw zombie
        //this draws the zombie and rectangle

        public void moveZombie1(Graphics g)
        {
            y += 5;

            zombieRec.Location = new Point(x, y);
            if (zombieRec.Location.Y > 400)
            {
                y = -20;
                zombieRec.Location = new Point(x, y);
            }
        }
    }
}
