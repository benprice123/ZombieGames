using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ZombieGame
{
    class Bullet
    {

        //declare fields to us in the class
        public int x, y, width, height;
        public double ySpeed;
        public Image bullet;
        public Rectangle bulletRec;


        //drawbullet

        public void drawBullet(Graphics g)
        {
            bulletRec = new Rectangle(x, y, width, height);
            g.DrawImage(bullet, bulletRec);
        }

        public void moveBullet(Graphics g)
        {
            y -= (int)ySpeed;
            bulletRec.Location = new Point(x, y);
        }

        public Bullet (Rectangle playerRec)
        {
            x = playerRec.X + playerRec.Width - 8;
            y = playerRec.Y + playerRec.Width / 2;
            width = 2;
            height = 5;
            bullet = Image.FromFile("Bullet.png");
            bulletRec = new Rectangle(x, y, width, height);
            ySpeed = 15;
        }
    }
}
