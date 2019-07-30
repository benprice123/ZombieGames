using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ZombieGame
{
    public partial class Form : System.Windows.Forms.Form
    {
        //declare all of stuff for the form
        Graphics g;
        List<Zombie> zombies = new List<Zombie>();
        //List<Zombie2> zombies2 = new List<Zombie2>();
        List<Bullet> bullet = new List<Bullet>();
        Random yspeed = new Random();
        Player player = new Player();
        bool left, right, up, down;
        public int score;
        string playerName;

        public Form()
        {
            InitializeComponent();

            //stops flickering of the panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (Zombie z in zombies)
            {
                z.drawZombie(g);
            }

                //zombie spacing
                for (int i = 0; i < 3; i++)
                {
                    int xspacing = 75 + (i * 150);
                    zombies.Add(new Zombie(xspacing));
                }
                //zombie2 spacing
                // for (int i = 0; i < 3; i++)
                //   {
                //       int spacing = 75 + (i * 150);
                //       zombies2.Add(new Zombie2(spacing));
                //   }

                foreach (Bullet b in bullet)
                {
                    b.drawBullet(g);
                    b.moveBullet(g);
                }

                player.drawPlayer(g);
            }
        }
    }

