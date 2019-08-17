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
        List<Zombie2> zombies2 = new List<Zombie2>();
        List<Bullet> bullet = new List<Bullet>();
        Random yspeed = new Random();
        Player player = new Player();
        bool left, right;
        public int score, missed, time;
        string playerName;

        public Form()
        {
            InitializeComponent();

            //stops flickering of the panel
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });

            //zombie spacing
            for (int i = 0; i < 3; i++)
            {
                int spacing = 20 + (i * 150);
                zombies.Add(new Zombie(spacing));
            }
            for (int i = 0; i < 5; i++)
            {
                int spacing = 40 + (i * 60);
                zombies2.Add(new Zombie2(spacing));
            }
        }


        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (Zombie z in zombies)
            {

                z.drawZombie(g);
            }

            //if tmrZombielv2 is going the draw zombies for level 2
            if (tmrZombie2.Enabled == true)
            {
                foreach (Zombie2 z2 in zombies2)
                {
                    z2.drawZombie2(g);

                }
            }

            foreach (Bullet b in bullet)
            {
                b.drawBullet(g);
                b.moveBullet(g);
            }

            player.drawPlayer(g);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //set score and missed to 0
            score = 0;
            missed = 0;
            time = 0;


            //disable timers so nothing moves until start is pressed
            tmrPlayer.Enabled = false;
            tmrZombie1.Enabled = false;
            tmrZombie2.Enabled = false;
            tmrTime.Enabled = false;
            tmrBullet.Enabled = false;

            //Show game instructions and focus on text box name after closed
            MessageBox.Show("Use the arrow keys to move player up,down,left and right and use the mouse to aim and shoot. /n Shoot as many zombies as you can before they catch you. /n Enter your name and press start to let the GAMES BEGIN!");
            txtName.Focus();
        }


        private void mnuStart_Click(object sender, EventArgs e)
        {

            lblScore.Text = score.ToString(); //Send the score to the label Score
            lblMissed.Text = missed.ToString();

            playerName = txtName.Text;

            if (Regex.IsMatch(playerName, @"^[a-zA-Z]+$"))//checks playerName for letters
            {
                //if playerName valid (only letters) 
                MessageBox.Show("Starting");
                tmrPlayer.Enabled = true;
                tmrZombie1.Enabled = true;
                tmrTime.Enabled = true;
                tmrZombie2.Enabled = false;
                tmrBullet.Enabled = true;
                txtName.Enabled = false;

            }
            else
            {
                //invalid playerName, clear txtName and focus on it to try again
                tmrPlayer.Enabled = false;
                tmrZombie1.Enabled = false;
                tmrZombie2.Enabled = false;
                tmrBullet.Enabled = false;
                tmrTime.Enabled = false;

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
            tmrTime.Enabled = false;
        }

        private void mnuRestart_Click(object sender, EventArgs e)
        {

        }

        private void tmrZombie1_Tick(object sender, EventArgs e)
        {
            foreach (Zombie z in zombies)
            {
                z.moveZombie1(g);
                if (z.zombieRec.Location.Y >= 400)
                {
                    missed += 1;
                    lblMissed.Text = missed.ToString();
                }
                pnlGame.Invalidate();
            }
        }

        private void mnuHighscores_Click(object sender, EventArgs e)
        {

        }




        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; } //left key pressed
            if (e.KeyData == Keys.Right) { right = true; } //right key pressed
            
        }

        private void pnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bullet.Add(new Bullet(player.playerRec));

            }
        }

        private void tmrBullet_Tick(object sender, EventArgs e)
        {
            //zombie 1 bullet intersect
            foreach (Zombie z in zombies)
            {
                foreach (Bullet b in bullet)
                {
                    if (z.zombieRec.IntersectsWith(b.bulletRec))
                    {
                        score += 1;
                        lblScore.Text = score.ToString();
                        checkScore();
                        bullet.Remove(b);
                        z.y = -40; //Relocate to top 

                        break;
                    }

                }
            }

            //zombie 2 bullet intersect
            if (tmrZombie2.Enabled == true)
            {
                foreach (Zombie2 z2 in zombies2)
                {
                    foreach (Bullet b in bullet)
                    {
                        if (z2.zombie2Rec.IntersectsWith(b.bulletRec))
                        {
                            score += 1;
                            lblScore.Text = score.ToString();
                            bullet.Remove(b);
                            z2.x = 420;//relocate to top

                            break;
                        }
                    }
                }
            }
        }

        private void tmrZombie2_Tick(object sender, EventArgs e)
        {
            foreach (Zombie2 z2 in zombies2)
            {
                z2.moveZombie2(g);
                if (z2.zombie2Rec.Location.X <= 0)
                {

                    missed += 1;
                    lblMissed.Text = missed.ToString();
                }

                pnlGame.Invalidate();

            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; } //left key released
            if (e.KeyData == Keys.Right) { right = false; } //right key released
           
        }





        private void tmrPlayer_Tick(object sender, EventArgs e)
        {

          if(left)
            {
                player.x -= 15;
            }

            if (right)
            {
                player.x += 15;
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
             time += 1;
            lblTime.Text = time.ToString();
            checkTime();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void checkTime()
        {
            if (time >= 60)
            {
                tmrBullet.Enabled = false;
                tmrPlayer.Enabled = false;
                tmrTime.Enabled = false;
                tmrZombie1.Enabled = false;
                tmrZombie2.Enabled = false;
                MessageBox.Show("GAME OVER. Check Highscores");
            }
        }

        private void checkScore()
        {
            if (score >= 2)
            {

                tmrZombie2.Enabled = true;
            }
        }


      }
    }

