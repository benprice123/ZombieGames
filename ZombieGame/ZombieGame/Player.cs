using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ZombieGame
{
    class Player
    {
        //declare fields to use in the player class
        public int rotationAngle;
        Point centre;
        public Matrix matrix;
        public int x, y, height, width;
        public Image player;
        public Rectangle playerRec;

        //hunter contstructor
        //set x to 200, y to 175, width and height to 30
        //hunter to 0, get the image player.png from files
        //to x,y,height,width

        public Player()
        {
            x = 200;
            y = 175;
            width = 30;
            height = 30;
            player = Image.FromFile("Player.png");
            playerRec = new Rectangle(x, y, width, height);
        }
        
        //methods
        //DrawPlayer
        //set the current draw location
        // draw the hunter

        public void drawPlayer (Graphics g)
        {
            centre = new Point(playerRec.X + width / 2, playerRec.Y + width / 2);

            matrix = new Matrix();

            matrix.RotateAt(rotationAngle, centre);

            g.Transform = matrix;

            playerRec = new Rectangle(x, y, width, height);
            g.DrawImage(player, playerRec);
        }
    }
}
