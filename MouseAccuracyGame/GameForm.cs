using MouseAccuracyGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace MouseAccuracyGame
{
    public partial class GameForm : Form
    {
        private int timeLeft;
        private int upperYBound = 60;
        private int lowerYBound = 600;
        private int leftXBound = 30;
        private int rightXBound = 790;
        private List<Panel> circles = new List<Panel>();
        private SolidBrush brush;

        private bool shouldGetBonus = false;
        private int bonus = 0;
        
        private Color circleColor;
        private int maxCircleSize;

        private Random random = new Random();
        private int circleCount = 0;
        private int hitCount = 0;
        private int totalClicks = 0;
        private SoundPlayer SoundPlayer;

        private struct CircleDetails
        {
            public int circleId;
            public bool shouldGoDown;
        }

        //start from 3 on size
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SoundPlayer = new SoundPlayer();
            if (StaticData.Settings.IsSoundOn)
                setSound();

            this.Cursor = StaticData.Settings.CurrentCursor == "Default" ? Cursors.Default : Cursors.Cross;
            circleColor = pickColor();
            maxCircleSize = pickMaxSize();

            brush = new SolidBrush(circleColor);

            timeLeft = StaticData.Settings.CurrentTime;
            timeLeftLabel.Text = $"Time: {timeLeft}";

            circleCreationTimer.Interval = setTimeInterval();
        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            timeLeft -= 1;
            timeLeftLabel.Text = $"Time: {timeLeft}";
            if (timeLeft != 0)
                return;

            countDownTimer.Enabled = false;
            this.Hide();
            //
            GameResults gameResults = new GameResults();
            gameResults.TargetsCount = circleCount;
            gameResults.TargetsHit = hitCount;
            gameResults.Bonus = bonus;
            gameResults.TotalScore = hitCount + bonus;
            gameResults.TargetAccuracy = (hitCount * 100) / circleCount;
            gameResults.ClickAccuracy = totalClicks != 0 ? (hitCount * 100) / totalClicks : 0;
            gameResults.ClickCount = totalClicks;
            GameResultsForm gameResultsForm = new GameResultsForm(gameResults);
            gameResultsForm.Show();
        }

        private void circleCreationTimer_Tick(object sender, EventArgs e)
        {
            int xCirclePosition = random.Next(leftXBound, rightXBound);
            int yCirclePosition = random.Next(upperYBound, lowerYBound);
            Panel circle = new Panel();

            circle.BackColor = Color.Transparent;
            circle.Location = new Point(xCirclePosition, yCirclePosition);
            circle.Size = new Size(maxCircleSize, maxCircleSize);
            circle.Paint += circle_Paint;
            circle.Click += destroy_Circle;
            CircleDetails circleDetails = new CircleDetails();
            circleDetails.circleId = circleCount;
            circleDetails.shouldGoDown = false;
            circle.Tag = circleDetails;
            circleCount++;
            circles.Add(circle);
            this.Controls.Add(circle);

            if (timeLeft == 3)
                circleCreationTimer.Enabled = false;
        }

        private void manageCircles_Tick(object sender, EventArgs e)
        {
            List<int> removeFromList = new List<int>();
            foreach (Panel circle in circles)
            {
                CircleDetails circleDetails = (CircleDetails)circle.Tag;
                if (!circleDetails.shouldGoDown && circle.Width == maxCircleSize)
                {
                    circle.Size = new Size(circle.Width - 1, circle.Height - 1);
                    circleDetails.shouldGoDown = true;
                    circle.Tag = circleDetails;
                }
                else if (circleDetails.shouldGoDown && circle.Width == 3)
                {
                    removeFromList.Add(circleDetails.circleId);
                    circle.Dispose();
                    this.Controls.Remove(circle);
                    continue;
                }
                else if(!circleDetails.shouldGoDown)
                    circle.Size = new Size(circle.Width + 1, circle.Height + 1);
                else if (circleDetails.shouldGoDown)
                    circle.Size = new Size(circle.Width - 1, circle.Height - 1);
                circle.Invalidate();
            }
        }

        private void circle_Paint(object sender, PaintEventArgs e)
        {
            Panel circle = (Panel)sender;
            Graphics g = circle.CreateGraphics();

            int diameter = circle.Size.Width - 2; // Diameter of the circle

            // Draw the circle
            g.FillEllipse(brush, 0, 0, diameter, diameter);
        }

        private void destroy_Circle(object sender, EventArgs e)
        {
            if(StaticData.Settings.IsSoundOn)
                SoundPlayer.Play();

            if (!shouldGetBonus)
                shouldGetBonus = true;
            else
                bonus++;

            Panel circle = (Panel)sender;
            circle.Dispose();
            this.Controls.Remove(circle);
            circle = null;
            hitCount++;
            totalClicks++;
            hitsLabel.Text = hitCount < 10 ? $"Hits: {hitCount} |" : $"Hits: {hitCount} |";
            accuracyLabel.Text = $"Accuracy: {hitCount * 100 / totalClicks}% |";
        }

        private void GameForm_Click(object sender, EventArgs e)
        {
            shouldGetBonus = false;
            totalClicks += 1;
            accuracyLabel.Text = $"Accuracy: {hitCount*100 / totalClicks}% |";
        }

        private Color pickColor()
        {
            if (StaticData.Settings.CurrentColor == "darkPink")
                return Color.FromArgb(244, 54, 104);
            if (StaticData.Settings.CurrentColor == "purple")
                return Color.BlueViolet;
            if (StaticData.Settings.CurrentColor == "pink")
                return Color.HotPink;
            if (StaticData.Settings.CurrentColor == "lightBlue")
                return Color.LightBlue;
            if (StaticData.Settings.CurrentColor == "orange")
                return Color.DarkOrange;
            return Color.Green;
        }

        private int pickMaxSize()
        {
            if (StaticData.Settings.CurrentSize == "Tiny")
                return 22;
            if (StaticData.Settings.CurrentSize == "Small")
                return 27;
            if (StaticData.Settings.CurrentSize == "Medium")
                return 32;
            return 37;
        }

        private int setTimeInterval()
        {
            if (StaticData.Settings.CurrentDifficulty == "Easy")
                return 1000;
            if (StaticData.Settings.CurrentSize == "Normal")
                return 800;
            if (StaticData.Settings.CurrentSize == "Hard")
                return 600;
            return 500;
        }

        private void setSound()
        {
            int soundChoice = random.Next(1, 6);
            switch(soundChoice)
            {
                case 1:
                    SoundPlayer.Stream = Resources.clickSound1;
                    break;
                case 2:
                    SoundPlayer.Stream = Resources.clickSound2;
                    break;
                case 3:
                    SoundPlayer.Stream = Resources.clickSound3;
                    break;
                case 4:
                    SoundPlayer.Stream = Resources.clickSound4;
                    break;
                case 5:
                    SoundPlayer.Stream = Resources.clickSound5;
                    break;
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticData.closedByX)
                Application.Exit();
        }
    }
}
