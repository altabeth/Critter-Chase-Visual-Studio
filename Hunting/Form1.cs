using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Hunting
{
    public partial class Form1 : Form
    {
        int catSpeed = 15;
        int preySpeedTop = 20;//speed from top edge of board
        int preyST = 20;
        int preySpeedLeft = 10;//speed from left edge of board
        int preySL = 10;
        int catX = 300;
        int catY = 260;
        int catXold = 0;
        int catYold = 0;
        int preyX = 200;
        int preyY = 300;
        int size = 32;
        int score = 0;
        int escapes = 0;
        int randCD = 20;//frequency of simi-random prey direction changes
        int timerCount = 0;
        int viewCount = 0;
        int viewCountlev = 0;
        int viewCountlas = 0;
        int levelBound = 30;

        bool lsr = false;
        int lsrS = 3;

        const int MAXSCORES = 100;
        int high1 = 3, high2 = 2, high3 = 1;
        string name1="No-One", name2="No-One", name3="No-One";

        string[,] scores=new string[MAXSCORES,2];
        string[,] highscores = new string[MAXSCORES, 2];
        string player;
        bool newPlayer = true;


        double slope;
        double ratio;
        double a, b;
        double catSpeedTry;

        string catD = "Right";
        string preyID = "mouse";
        int catChoice = 1;

        int level = 1;

        Random rnd = new Random();
        int rand;

        Point mPos;

        //functions

        private void highScoresL()
        {
            try
            {
                StreamReader loadScores;
                string line;

                char[] delim = { ',' };

                loadScores = File.OpenText("scores.csv");
                int sl = 0;
                while (!loadScores.EndOfStream)
                {
                    line = loadScores.ReadLine();
                    string[] cells = line.Split(delim);

                    int si = 0;
                    foreach (string str in cells)
                    {
                        scores[sl, si] = str;
                        si++;
                    }
                    sl++;
                }
                loadScores.Close();
            }
            catch
            {
                MessageBox.Show("Sorry-I couldn't find the Scores file!\nPlease check to make sure there is a file called \"scores\" in the same folder as the .exe file.");
            }
                for (int i = 0; i < MAXSCORES; i++)
                {
                    if (scores[i,0]==player)
                    {
                        newPlayer = false;
                    }
                }

                if (newPlayer == true)
                {
                    for (int i = 0; i < MAXSCORES; i++)
                    {
                        if (scores[i, 0] == null)
                        {
                            scores[i, 0] = player;
                            scores[i, 1] = "0";
                            break;
                        }
                    }
                }
                highScoresU();
            /*StreamReader highScoresL;
string line2;

char[] delim2 = { ',' };

highScoresL = File.OpenText("highscores.csv");
int sl2 = 0;
while (!highScoresL.EndOfStream)
{
    line2 = highScoresL.ReadLine();
    string[] cells2 = line2.Split(delim);

    int si2 = 0;
    foreach (string str2 in cells2)
    {
        scores[sl2, si2] = str2;
        si2++;
    }
    sl2++;
}
highScoresL.Close();
 */
        }

       void highScoresS()
        {
            for (int i = 0; i < MAXSCORES; i++)
            {
                if (scores[i, 0] == player)
                {
                    if (int.Parse(scores[i, 1])<score)
                    {
                        scores[i, 1] = score.ToString();
                    }
                }
            }
                      StreamWriter saveScores=new StreamWriter("scores.csv");
                      //saveScores.WriteLine("stuff");
           
            for (int i = 0; i < MAXSCORES; i++)
            {
                string ln = "";
                ln += (scores[i, 0] + ","+scores[i,1]);

                if (ln != ",") { saveScores.WriteLine(ln); }
            }
           
            saveScores.Close();


        }

        void highScoresU()
        {
            for (int i = 0; i < MAXSCORES; i++)
            {
                if (scores[i, 0] != null && scores[i, 1] != null && int.Parse(scores[i, 1]) > high1)
                {
                    high1 = int.Parse(scores[i, 1]);
                    name1 = scores[i, 0];
                }
            }
            for (int i = 0; i < MAXSCORES; i++)
            {
                if (scores[i, 0] != null && scores[i, 1] != null && int.Parse(scores[i, 1]) < high1 && int.Parse(scores[i, 1]) > high2)
                {
                    high2 = int.Parse(scores[i, 1]);
                    name2 = scores[i, 0];
                }
            }
            for (int i = 0; i < MAXSCORES; i++)
            {
                if (scores[i, 0] != null && scores[i, 1] != null && int.Parse(scores[i, 1]) < high1 && int.Parse(scores[i, 1]) < high2 && int.Parse(scores[i, 1]) > high3)
                {
                    high3 = int.Parse(scores[i, 1]);
                    name3 = scores[i, 0];
                }
            }
        }


        private void boardEdge()
        {
            rand = rnd.Next(1, randCD + 1);

            if ((preyX + prey.Width) >= board.Width)
            {
                preySpeedLeft = -(Math.Abs(preySpeedLeft));
            }
            else if (preyX <= 0)
            {
                preySpeedLeft = (Math.Abs(preySpeedLeft));
            }
            else if ((preyY + prey.Height) >= board.Height)
            {
                preySpeedTop = -(Math.Abs(preySpeedTop));
            }
            else if (preyY <= 0)
            {
                preySpeedTop = (Math.Abs(preySpeedTop));
            }
            else if ((preyX + prey.Width < (board.Right - 30)) && (prey.Left > 30) && (prey.Top > 30) && (preyY + prey.Height < (board.Bottom - 30)))
            {
                if ((rand % randCD == 0))
                {
                    preySpeedLeft = -preySpeedLeft;
                }
                else if (rand % (randCD - 1) == 0)
                {
                    preySpeedTop = -preySpeedTop;
                }
                else if (rand % (randCD - 2) == 0)
                {
                    preySpeedLeft = -preySpeedLeft;
                    preySpeedTop = -preySpeedTop;
                }
            }
        }


        //change orientation of cat picture
        private void picD()
        {
            if (catX < catXold)
            {
                if (catChoice == 1)
                {
                    cat.Image = Image.FromFile("Cat2Left.png");
                    catD = "Left";
                }
                else if(catChoice==2){
                    cat.Image = Image.FromFile("kittenR.png");
                    catD = "Left";
                }
                else
                {
                    MessageBox.Show("Oh no!  Something has gone wrong with the cat picture!");
                }
            }
            else
            {
                if (catChoice == 1)
                {
                    cat.Image = Image.FromFile("Cat2Right.png");
                    catD = "Right";
                }
                else if (catChoice == 2)
                {
                    cat.Image = Image.FromFile("kitten.png");
                    catD = "Right";
                }
                else
                {
                    MessageBox.Show("Oh no!  Something has gone wrong with the cat picture!");
                }
            }
            /*
            if (catD == "Left")
            {
                cat.Image = Image.FromFile("Cat2Left.png");
            }
            else if (catD == "Right")
            {
                cat.Image = Image.FromFile("Cat2Right.png");
            }
            else if (catD == "Up")
            {
                cat.Image = Image.FromFile("Cat2Up.png");
            }
            else if (catD == "Down")
            {
                cat.Image = Image.FromFile("Cat2Down.png");
            }
             */
        }

        private void distanceC()
        {
            if (cat.Top < (board.Height / 8))
            {
                cat.Width = (int)((size * 2) / (2.1));
                cat.Height = (int)((size * 2) / (2.1));
            }
            else if (cat.Top < (board.Height / 8) * 2)
            {
                cat.Width = (int)((size * 2) / (1.9));
                cat.Height = (int)((size * 2) / (1.9));
            }
            else if (cat.Top < (board.Height / 8) * 3)
            {
                cat.Width = (int)((size * 2) / (1.6));
                cat.Height = (int)((size * 2) / (1.6));
            }
            else if (cat.Top < (board.Height / 8) * 4)
            {
                cat.Width = (int)((size * 2) / (1.3));
                cat.Height = (int)((size * 2) / (1.3));
            }
            else
            {
                cat.Width = (size * 2);
                cat.Height = (size * 2);
            }
        }

        private void distanceP()
        {
            if (prey.Top < (board.Height / 8))
            {
                if (preyID == "mouse")
                {
                    prey.Height = (int)(size / 2.1);
                    prey.Width = (int)(size / 2.1);
                }
                else if (preyID == "butterfly")
                {
                    prey.Height = (int)(size / 2.1);
                    prey.Width = (int)((size * (5 / 4)) / 2.1);
                }
                else if (preyID == "snake")
                {
                    prey.Height = (int)((size * 1.5) / 2.1);
                    prey.Width = (int)(((size * (5 / 4)) * 1.5) / 2.1);
                }
                else if (preyID == "laser")
                {
                    prey.Height = (int)((size / 2) / 1.9);
                    prey.Width = (int)((size / 2) / 1.9);
                }
            }
            else if (prey.Top < (board.Height / 8) * 2)
            {
                if (preyID == "mouse")
                {
                    prey.Height = (int)(size / 1.9);
                    prey.Width = (int)(size / 1.9);
                }
                else if (preyID == "butterfly")
                {
                    prey.Height = (int)(size / 1.9);
                    prey.Width = (int)((size * (5 / 4)) / 1.9);
                }
                else if (preyID == "snake")
                {
                    prey.Height = (int)((size * 1.5) / 1.9);
                    prey.Width = (int)(((size * (5 / 4)) * 1.5) / 1.9);
                }
                else if (preyID == "laser")
                {
                    prey.Height = (int)((size / 2) / 1.9);
                    prey.Width = (int)((size / 2) / 1.9);
                }
            }
            else if (prey.Top < (board.Height / 8) * 3)
            {
                if (preyID == "mouse")
                {
                    prey.Height = (int)(size / 1.6);
                    prey.Width = (int)(size / 1.6);
                }
                else if (preyID == "butterfly")
                {
                    prey.Height = (int)(size / 1.6);
                    prey.Width = (int)((size * (5 / 4)) / 1.6);
                }
                else if (preyID == "snake")
                {
                    prey.Height = (int)((size * 1.5) / 1.6);
                    prey.Width = (int)(((size * (5 / 4)) * 1.5) / 1.6);
                }
                else if (preyID == "laser")
                {
                    prey.Height = (int)((size / 2) / 1.6);
                    prey.Width = (int)((size / 2) / 1.6);
                }
            }
            else if (prey.Top < (board.Height / 8) * 4)
            {
                if (preyID == "mouse")
                {
                    prey.Height = (int)(size / 1.3);
                    prey.Width = (int)(size / 1.3);
                }
                else if (preyID == "butterfly")
                {
                    prey.Height = (int)(size / 1.3);
                    prey.Width = (int)((size * (5 / 4)) / 1.3);
                }
                else if (preyID == "snake")
                {
                    prey.Height = (int)((size * 1.5) / 1.3);
                    prey.Width = (int)(((size * (5 / 4)) * 1.5) / 1.3);
                }
                else if (preyID == "laser")
                {
                    prey.Height = (int)((size / 2) / 1.3);
                    prey.Width = (int)((size / 2) / 1.3);
                }
            }
            else
            {
                if (preyID == "mouse")
                {
                    prey.Height = size;
                    prey.Width = size;
                }
                else if (preyID == "butterfly")
                {
                    prey.Height = size;
                    prey.Width = (size * (5 / 4));
                }
                else if (preyID == "snake")
                {
                    prey.Height = (int)(size * (3 / 2));
                    prey.Width = (int)((size * (5 / 4)) * 1.5);
                }
                else if (preyID == "laser")
                {
                    prey.Height = (size / 2);
                    prey.Width = (size / 2);
                }
            }
        }
        private void newPrey()
        {
            prey.Visible = false;

            rand = rnd.Next(1, 5);
            if (catX <= (board.Width / 2))
            {
                rand = rnd.Next(1, 5);
                preyX = ((board.Width / 2) + (rand * (board.Width /10)));
            }
            else
            {
                rand = rnd.Next(1, 5);
                preyX = ((board.Width / 2) - (rand * (board.Width /10)));
            }

            //if (catY <= (board.Height / 2))
            //{
            //preyY = ((board.Height / 2) + (rand * (board.Height / 9)));
            rand = rnd.Next(1, 5);
            preyY = (board.Height / 9)+(rand * (board.Height / 7));
            //}
            // else
            //{
            // preyY = ((board.Height / 2) - (rand * (board.Height / 8)));
            //}

            rand = rnd.Next(1, 5);
            if (rand == 1)
            {
                preyID = "butterfly";
                if (level == 2)
                {
                    prey.Image = Image.FromFile("NightButterfly.gif");
                }
                else
                {
                    prey.Image = Image.FromFile("butterfly.gif");
                }
            }
            else if (rand == 2)
            {
                preyID = "mouse";
                if (level == 2)
                {
                    prey.Image = Image.FromFile("bat.gif");
                }
                else
                {
                    prey.Image = Image.FromFile("mouse.gif");
                }
            }
            else if (rand == 3)
            {
                preyID = "snake";
                if (level == 2)
                {
                    prey.Image = Image.FromFile("bug.png");
                }
                else
                {
                    prey.Image = Image.FromFile("snake1.gif");
                }
            }
            else if (rand == 4)
            {
                preyID = "laser";
                if (level == 2)
                {
                    prey.Image = Image.FromFile("laserB.png");
                }
                else
                {
                    prey.Image = Image.FromFile("laser2.png");
                }
            }
            else
            {
                preyID = "mouse";
                prey.Image = Image.FromFile("mouse.gif");
            }


            prey.Visible = true;
        }

        private void gameDone()
        {
            for (int i = 0; i < MAXSCORES; i++)
            {
                if (scores[i, 0] == player)
                {
                    if (int.Parse(scores[i, 1]) < score)
                    {
                        scores[i, 1] = score.ToString();
                    }
                }
            }
        
            //highScoresU();
            gotIt.Font = new Font("Arial", 16, FontStyle.Bold);
            showescapes.Text = ("Escaped Prey: " + escapes);
            //MessageBox.Show(name1 + high1 + name2 + high2 + name3 + high3);
            if (score > high1)
            {
                highScoresU();
                gotIt.Text = ("New High Score!!!  Your total score is " + score + "\nHigh scores are: " + name1 + ", " + high1 + "; " + name2 + ", " + high2 + "; " + name3 + ", " + high3 + "; " + "\nPress Enter for a new game, \nor Escape to exit.");
               // MessageBox.Show(name1 + high1 + name2 + high2 + name3 + high3);
            }
            else
            {
                highScoresU();
                gotIt.Text = ("Game Over.  Your total score is " + score + "\nHigh scores are: " + name1 + ", " + high1 + "; " + name2 + ", " + high2 + "; " + name3 + ", " + high3 + "\nPress Enter for a new game, \nor Escape to exit.");
               // MessageBox.Show(name1 + high1 + name2 + high2 + name3 + high3);
            }
            prey.Visible = false;
            timer1.Enabled = false;
            gotIt.Visible = true;
            gotIt.BringToFront();
            highScoresS();
        }
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Sscreen));
            t.Start();
            Thread.Sleep(4300);
            InitializeComponent();
            t.Abort();

            //InitializeComponent();
            Cursor.Hide();

            timer1.Enabled = false;


            Form3 titleScreen = new Form3();
            titleScreen.ShowDialog();
            titleScreen.TopMost = true;

            player = titleScreen.nameBox.Text;
            catChoice = int.Parse(titleScreen.catC.Text);
            highScoresL();
            timer1.Enabled = true;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer("VariationIv.wav");
            sp.PlayLooping();

        }

        public void Sscreen()
        {
            Application.Run(new Form4());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //counts up then resets- used to space out things that shouldn't happen every tick
            timerCount++;
            if (timerCount >= 1000)
            {
                timerCount = 0;
            }

            //checks on the second (view) timer
            if (viewCount > 20)
            {
                timer2.Enabled = false;
                note.Visible = false;
                viewCount = 0;
            }
            //and the third
            if (viewCountlev > 15)
            {
                timer3.Enabled = false;
                levlabel.Visible = false;
                levlabel.SendToBack();
                viewCountlev = 0;
            }
            //and the fourth (laser)
            if (viewCountlas > 2)
            {
                timer4.Enabled = false;
                laser.Visible = false;
                viewCountlas = 0;
            }



            //refresh scores
            showescapes.Text = ("Escaped Prey: " + escapes);
            showScore.Text = ("Score: " + score);



            //change orientation of cat picture
            picD();

            //check for edge of board and change prey direction
            boardEdge();

            //set size of cat and prey based on distance
            distanceC();
            distanceP();

            //change prey image coords
            if (preyID == "mouse")
            {
                preyX += (preySpeedLeft + (preySpeedLeft / 3));
                preyY += (preySpeedTop + (preySpeedTop / 3));
            }
            else if (preyID == "snake")
            {
                preyX += (preySpeedLeft + (preySpeedLeft / 2));
                preyY += (preySpeedTop + (preySpeedTop / 2));
            }
            else if (preyID == "snake")
            {
                preyX += (preySpeedLeft + (preySpeedLeft));
                preyY += (preySpeedTop + (preySpeedTop));
            }
            else
            {
                preyX += (preySpeedLeft);
                preyY += (preySpeedTop);
            }

            //change cat image coords
            /*
            if (catD == "Right" && cat.Right < board.Width)
            {
                catX += catSpeed;
            }
            else if (catD == "Left" && cat.Left > 0)
            {
                catX -= catSpeed;
            }
            else if (catD == "Up" && cat.Top > 0)
            {
                catY -= catSpeed;
            }
            else if (catD == "Down" && cat.Bottom < board.Height)
            {
                catY += catSpeed;
            }
            */

            mPos=board.PointToClient(Cursor.Position);

            catXold = catX;
            catYold = catY;

            a = Math.Abs(mPos.X-catX);
            b = Math.Abs(mPos.Y - catY);
            catSpeedTry=(Math.Sqrt((a*a)+(b*b)));
            slope=(b/a);
            ratio = ((double)catSpeed / catSpeedTry);

            catXold = catX;
            catYold = catY;
            //if (catSpeedTry<=catSpeed)
           //{

                catX = (mPos.X - cat.Width / 2);
                catY = (mPos.Y - cat.Height / 2);

            //}
           /* else
            {
                if (catX < mPos.X)
                {
                    catX = (catX+((int)(mPos.X * ratio) - cat.Width / 2));
                }
                else
                {
                    catX = (catX - ((int)(mPos.X * ratio) - cat.Width / 2));
                }
                if (catY < mPos.Y)
                {
                    catY = (catY+((int)(mPos.Y * ratio) - cat.Height / 2));
                }
                else
                {
                    catY = (catY - ((int)(mPos.Y * ratio) - cat.Height / 2));
                }
            }

            */
            //set new location cat and prey
            cat.Location = new Point(catX, catY);
            prey.Location = new Point(preyX, preyY);

            //check for cat-prey collision
            if ((prey.Top <= cat.Bottom && prey.Top >= cat.Top && prey.Left <= cat.Right && prey.Left >= cat.Left) || (laser.Visible == true && laser.Top <= prey.Bottom && laser.Top >= prey.Top && prey.Left <= laser.Right && prey.Right >= laser.Left))
            {
                axWindowsMediaPlayer2.URL = "ding.mp3";
                axWindowsMediaPlayer2.Ctlcontrols.play();

                if (preyID == "butterfly")
                {
                    score += 1;
                }
                else if (preyID == "mouse")
                {
                    score += 2;
                }
                else if (preyID == "snake")
                {
                    score += 3;
                }
                else if (preyID == "laser")
                {
                    score += 5;
                    lsr = true;
                    lsrS = 3;
                    laslab.Visible = true;
                    laslab.Text = (lsrS).ToString();
                }
                else
                {
                    MessageBox.Show("Oh no!  Something has gone wrong with the preyID.");
                }

                showScore.Text = ("Score: " + score);
                if ((score >= levelBound)&&(level!=2))
                {
                    level = 2;
                    levlabel.Visible = true;
                    timer3.Enabled = true;
                    this.BackgroundImage = Image.FromFile("back2.bmp");
                    preySpeedLeft += 7;
                    preySpeedTop += 7;

                    //MessageBox.Show("Level 2!");

                    System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer("night.wav");
                    sp2.PlayLooping();

                }

                newPrey();

                note.Text = ("Got It!");
                note.Visible = true;
                timer2.Enabled = true;


            }

            //check for prey down hole
            if ((prey.Bottom <= hole1.Bottom && prey.Top >= hole1.Top && prey.Left <= hole1.Right && prey.Left >= (hole1.Left)) ||
                (prey.Bottom <= hole2.Bottom && prey.Top >= hole2.Top && prey.Right >= hole2.Left && prey.Right <= (hole2.Right)))
            {
                axWindowsMediaPlayer1.URL = "zip.wav";
                axWindowsMediaPlayer1.Ctlcontrols.play();
                

                escapes++;
                showScore.Text = "Score: " + score;
                if (escapes >= 5)
                {
                    gameDone();
                    

                }
                else
                {
                    showescapes.Text = ("Escaped Prey: " + escapes);
                    note.Text = ("Escaped!");
                    note.Visible = true;
                    timer2.Enabled = true;

                    newPrey();

                }
            }

            Invalidate();
        }

        private void gotIt_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            viewCountlev++;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W)
            {
                preyX = (board.Right - (board.Width / 2));
                preyY = (board.Bottom - (board.Height / 2));
            }
            else if (e.KeyCode == Keys.R)
            {
                preyX = (board.Right - prey.Width);
                preyY = (board.Bottom - (board.Height / 2));
            }
            else if (e.KeyCode == Keys.B)
            {
                preyY = (board.Bottom - prey.Height);
                preyX = (board.Right - (board.Width / 2));
            }
            else if (e.KeyCode == Keys.L)
            {
                preyX = board.Left;
                preyY = (board.Bottom - (board.Height / 2));
            }
            else if (e.KeyCode == Keys.T)
            {
                preyY = board.Top;
                preyX = (board.Right - (board.Width / 2));
            }

            if (e.KeyCode == Keys.Left)
            {
                catD = "Left";
            }
            else if (e.KeyCode == Keys.Right)
            {
                catD = "Right";
            }
            else if (e.KeyCode == Keys.Down)
            {
                catD = "Down";
            }
            else if (e.KeyCode == Keys.Up)
            {
                catD = "Up";
            }
            else if(e.KeyCode == Keys.Space)
            {
                if (lsr == true&&lsrS>0)
                {
                    timer4.Enabled = true;
                    laser.Visible = true;
                    if (catD == "Left")
                    {
                        if (catChoice == 2)
                        {
                            laser.Location = new Point(((mPos.X - cat.Width / 2) - laser.Width), (cat.Bottom-3*cat.Height/4));
                        }
                        else { laser.Location = new Point(((mPos.X - cat.Width / 2) - laser.Width), (cat.Bottom - cat.Height / 2)); }
                        
                    }
                    else
                    {
                        if (catChoice == 2)
                        {
                            laser.Location = new Point(((mPos.X - cat.Width / 2) + cat.Width), (cat.Bottom - 3 * cat.Height / 4));
                        }
                        else
                        {
                            laser.Location = new Point(((mPos.X - cat.Width / 2) + cat.Width), (cat.Bottom - cat.Height / 2));
                        }
                    }
                    lsrS--;
                    laslab.Text = (lsrS).ToString();
                    if (lsrS <= 0)
                    {
                        laslab.Visible = false;
                    }
                    else
                    {
                        
                    }
                    
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                timer1.Enabled = true;

                for (int i = 0; i < MAXSCORES; i++)
                {
                    if (scores[i, 0] == player)
                    {
                        if (int.Parse(scores[i, 1]) < score)
                        {
                            scores[i, 1] = score.ToString();
                        }
                    }
                }
                level = 1;
                BackgroundImage = Image.FromFile("back1.bmp");
                escapes = 0;
                score = 0;

                System.Media.SoundPlayer sp = new System.Media.SoundPlayer("VariationIv.wav");
                sp.PlayLooping();
                preySpeedLeft = preySL;
                preySpeedTop = preyST;
                showScore.Text = ("Score: " + score);
                showescapes.Text = ("Escaped Prey: " + escapes);

                newPrey();

                gotIt.Visible = false;
                gotIt.SendToBack();
                levlabel.Visible = false;
                levlabel.SendToBack();


            }
            if (e.KeyCode == Keys.Q)
            {
                gameDone();
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            viewCount++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            viewCountlev++;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //catD = "Stopped";
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            viewCountlas++;
        }
    }
}
