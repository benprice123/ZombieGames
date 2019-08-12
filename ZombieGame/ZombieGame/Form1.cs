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

        private void mnuStart_Click(object sender, EventArgs e)
        {

            lblScore.Text = score.ToString(); //Send the score to the label Score
            playerName = txtName.Text;

            if (Regex.IsMatch(playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
            {
                //if playerName valid (only letters) 
                MessageBox.Show("Starting");
                tmrPlayer.Enabled = true;
                tmrZombie1.Enabled = true;
                tmrZombie2.Enabled = false;
                tmrBullet.Enabled = true;

            }
            else
            {
                //invalid playerName, clear txtName and focus on it to try again
                tmrPlayer.Enabled = false;
                tmrZombie1.Enabled = false;
                tmrZombie2.Enabled = false;
                tmrBullet.Enabled = false;

                MessageBox.Show("please enter a name using letters only!");
                txtName.Clear();
                txtName.Focus();

            }
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
          
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrPlayer.Enabled = false;
            tmrZombie1.Enabled = false;
            tmrZombie2.Enabled = false;
            tmrBullet.Enabled = false;
        }

        private void mnuRestart_Click(object sender, EventArgs e)
        {

        }

        private void mnuHighscores_Click(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {
            //set score and missed to 0
            score = 0;

            //disable timers so nothing moves until start is pressed
            tmrPlayer.Enabled = false;
            tmrZombie1.Enabled = false;
           // tmrZombie2.Enabled = false;

            //Show game instructions and focus on text box name after closed
            MessageBox.Show("Use the arrow keys to move player up,down,left and right and use the mouse to aim and shoot. /n Shoot as many zombies as you can before they catch you. /n Enter your name and press start to let the GAMES BEGIN!");
            txtName.Focus();
        }


        public Form()
        {
            InitializeComponent();

            //stops flickering of the panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });

            //zombie spacing
            for (int i = 0; i < 3; i++)
            {
                int spacing = 75 + (i * 150);
                zombies.Add(new Zombie(spacing));
            }
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (Zombie z in zombies)
            {
                z.drawZombie(g);
            }

                foreach (Bullet b in bullet)
                {
                    b.drawBullet(g);
                    b.moveBullet(g);
                }

                player.drawPlayer(g);
            }
        }
    }

