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
        public Zombie(int xspacing )
        {
            x = xspacing;
            y = -20;
            width = 20;
            height = 20;
            zombieImage = Image.FromFile("Zombie1.png");
            zombieRec = new Rectangle(x, y, width, height);
        }

        //methods for the zombie class
        //draw zombie
        //this draws the zombie and rectangle
        public void drawZombie (Graphics g)
        {
            zombieRec = new Rectangle(x, y, width, height);
            g.DrawImage(zombieImage, zombieRec);
        }

        //Move Zombie1
        //This will move the zombie down the game panel
        //and if it is greater than 400 on the y axis of the 
        //game panel go back to y -20 and change zombie rectangle
        //to location of zombie
        // GOING TO CHANGE SO THAT THE ZOMBIE CHASES PLAYER
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
