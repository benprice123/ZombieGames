using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ZombieGame
{
    class Zombie2
    {
        //declare fields to use in the class
        public int x, y, width, height;
        public Rectangle zombie2Rec;
        public Image zombie2Image;

        //zombie
        //set x to spacing y to -20, width 20 height 20
        //Get the zombie image from files
        //set rectangle to x,y,width and height
        public Zombie2(int yspacing)
        {
            x = 420;
            y = yspacing;
            width = 20;
            height = 20;
            zombie2Image = Image.FromFile("Zombie1.png");
            zombie2Rec = new Rectangle(x, y, width, height);
        }

        //methods for the zombie class
        //draw zombie
        //this draws the zombie and rectangle
        public void drawZombie2(Graphics g)
        {
            zombie2Rec = new Rectangle(x, y, width, height);
            g.DrawImage(zombie2Image, zombie2Rec);
        }

        //Move Zombie1
        //This will move the zombie down the game panel
        //and if it is greater than 400 on the y axis of the 
        //game panel go back to y -20 and change zombie rectangle
        //to location of zombie
        public void moveZombie2(Graphics g)
        {
            x -= 5;

            zombie2Rec.Location = new Point(x, y);
            if (zombie2Rec.Location.X < 0)
            {
                x = 420;
                zombie2Rec.Location = new Point(x, y);
            }
        }
    
}
}
