using MouseAccuracyGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseAccuracyGame
{
    public partial class GameResultsForm : Form
    {
        public GameResultsForm(GameResults gameResults)
        {
            InitializeComponent();
            totalScoreValueLabel.Text = gameResults.TotalScore.ToString();
            pointsValueLabel.Text = $"{gameResults.TargetsHit} points";
            pointsValueLabel.Location = gameResults.TargetsHit > 9 ? new Point(85, 145) : new Point(90, 145);
            bonusValueLabel.Text = $"{gameResults.Bonus} bonus";
            bonusValueLabel.Location = gameResults.Bonus > 9 ? new Point(85, 167) : new Point(90, 167);
            
            totalTargetEfficiencyValueLabel.Text = $"{gameResults.TargetAccuracy}%";
            totalTargetEfficiencyValueLabel.Location = gameResults.TargetAccuracy != 100 ? new Point(360, 103) : new Point(351, 103);
            hitTargetsTotalValueLabel.Text = $"{gameResults.TargetsHit} / {gameResults.TargetsCount} Total";
            
            totalClickAccuracyPercentageValueLabel.Text = $"{gameResults.ClickAccuracy}%";
            totalClickAccuracyPercentageValueLabel.Location = gameResults.ClickAccuracy != 100 ? new Point(614, 103) : new Point(605, 103); 
            hitClicksTotalValueLabel.Text = $"{gameResults.TargetsHit} / {gameResults.ClickCount} Total";
            
            totalSpawnedTargetsValueLabel.Text = gameResults.TargetsCount.ToString();
            targetsHitValueLabel.Text = $"{gameResults.TargetsHit} Hits";
            targetsMissedValueLabel.Text = $"{gameResults.TargetsCount - gameResults.TargetsHit} Missed";
            double result = (double)gameResults.TargetsCount / StaticData.Settings.CurrentTime;
            targetsPerSecondValueLabel.Text = string.Format("{0:F2} Per Second", result);
            
            difficultyValueLabel.Text = StaticData.Settings.CurrentDifficulty;
            circleSizeValueLabel.Text = StaticData.Settings.CurrentSize;
            timeValueLabel.Text = StaticData.Settings.CurrentTime.ToString();
            ChooseDifficultyImage();
            ChooseBallSize();

            totalClicksValueLabel.Text = gameResults.ClickCount.ToString();
            clicksThatHitTheTargetValueLabel.Text = $"{gameResults.TargetsHit} Hits";
            clicksThatMissedTheTargetValueLabel.Text = $"{gameResults.ClickCount - gameResults.TargetsHit} Misses";
            result = (double)gameResults.ClickCount / StaticData.Settings.CurrentTime;
            clicksPerSecondValueLabel.Text = string.Format("{0:F2} Per Second", result);
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            StaticData.closedByX = false;
            this.Close();
            Application.OpenForms[1].Close();
            StaticData.closedByX = true;
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void gameSettingsButton_Click(object sender, EventArgs e)
        {
            StaticData.closedByX = false;
            this.Close();
            Application.OpenForms[1].Close();
            StaticData.closedByX = true;
            Application.OpenForms[0].Show();
        }

        private void leaderBoardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeaderBoardForm leaderBoardForm = new LeaderBoardForm();
            leaderBoardForm.Show();
        }

        private void GameResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticData.closedByX)
                Application.Exit();
        }

        private void ChooseDifficultyImage()
        {
            switch (StaticData.Settings.CurrentDifficulty)
            {
                case "Easy":
                    difficultyPictureBox.BackgroundImage = Resources.easyIconTransparent;
                    break;
                case "Normal":
                    difficultyPictureBox.BackgroundImage = Resources.mediumIconTransparent;
                    break;
                case "Hard":
                    difficultyPictureBox.BackgroundImage = Resources.hardIconTransparent;
                    break;
                case "Extreme":
                    difficultyPictureBox.BackgroundImage = Resources.extremeIconTransparent;
                    break;
            }
        }

        private void ChooseBallSize()
        {
            if (StaticData.Settings.CurrentSize == "Tiny")
            {
                /*333; 148*/
                circleSizePictureBox.Location = new Point(333, 148);
                circleSizePictureBox.Size = new Size(20, 20);
            }
            else if (StaticData.Settings.CurrentSize == "Small")
            {
                circleSizePictureBox.Location = new Point(331, 146);
                circleSizePictureBox.Size = new Size(25, 25);
            }
            else if (StaticData.Settings.CurrentSize == "Medium")
            {
                circleSizePictureBox.Location = new Point(329, 143);
                circleSizePictureBox.Size = new Size(30, 30);
            }
            else if (StaticData.Settings.CurrentSize == "Large")
            {
                circleSizePictureBox.Location = new Point(327, 141);
                circleSizePictureBox.Size = new Size(35, 35);
            }
        }
    }
}
