using MouseAccuracyGame.CustomControls;
using MouseAccuracyGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseAccuracyGame
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void targetSizeUpButton_Click(object sender, EventArgs e)
        {
            if(StaticData.Settings.CurrentSize == "Tiny")
            {
                targetSizeValueLabel.Text = "Small";
                StaticData.Settings.CurrentSize = "Small";
                targetSizeBallPictureBox.Location = new Point(25, 110);
                targetSizeBallPictureBox.Size = new Size(25, 25);
            }
            else if (StaticData.Settings.CurrentSize == "Small")
            {
                targetSizeValueLabel.Text = "Medium";
                StaticData.Settings.CurrentSize = "Medium";
                targetSizeBallPictureBox.Location = new Point(23, 108);
                targetSizeBallPictureBox.Size = new Size(30, 30);
            }
            else if (StaticData.Settings.CurrentSize == "Medium")
            {
                targetSizeValueLabel.Text = "Large";
                StaticData.Settings.CurrentSize = "Large";
                targetSizeBallPictureBox.Location = new Point(21, 106);
                targetSizeBallPictureBox.Size = new Size(35, 35);
            }
            else if (StaticData.Settings.CurrentSize == "Large")
            {
                targetSizeValueLabel.Text = "Tiny";
                StaticData.Settings.CurrentSize = "Tiny";
                targetSizeBallPictureBox.Location = new Point(27, 112);
                targetSizeBallPictureBox.Size = new Size(20, 20);
            }
        }

        private void targetSizeDownButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentSize == "Tiny")
            {
                targetSizeValueLabel.Text = "Large";
                StaticData.Settings.CurrentSize = "Large";
                targetSizeBallPictureBox.Location = new Point(21, 106);
                targetSizeBallPictureBox.Size = new Size(35, 35);
            }
            else if (StaticData.Settings.CurrentSize == "Small")
            {
                targetSizeValueLabel.Text = "Tiny";
                StaticData.Settings.CurrentSize = "Tiny";
                targetSizeBallPictureBox.Location = new Point(27, 112);
                targetSizeBallPictureBox.Size = new Size(20, 20);
            }
            else if (StaticData.Settings.CurrentSize == "Medium")
            {
                targetSizeValueLabel.Text = "Small";
                StaticData.Settings.CurrentSize = "Small";
                targetSizeBallPictureBox.Location = new Point(25, 110);
                targetSizeBallPictureBox.Size = new Size(25, 25);
            }
            else if (StaticData.Settings.CurrentSize == "Large")
            {
                targetSizeValueLabel.Text = "Medium";
                StaticData.Settings.CurrentSize = "Medium";
                targetSizeBallPictureBox.Location = new Point(23, 108);
                targetSizeBallPictureBox.Size = new Size(30, 30);
            }
        }

        private void timeUpButton_Click(object sender, EventArgs e)
        {
            if(StaticData.Settings.CurrentTime == 90)
            {
                StaticData.Settings.CurrentTime = 15;
                TimeValueLabel.Text = "15";
                return;
            }
            StaticData.Settings.CurrentTime += 15;
            TimeValueLabel.Text = StaticData.Settings.CurrentTime.ToString();
        }

        private void timeDownButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentTime == 15)
            {
                StaticData.Settings.CurrentTime = 90;
                TimeValueLabel.Text = "90";
                return;
            }
            StaticData.Settings.CurrentTime -= 15;
            TimeValueLabel.Text = StaticData.Settings.CurrentTime.ToString();
        }

        private void plusCursorPictureBox_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentCursor == "Plus")
                return;

            StaticData.Settings.CurrentCursor = "Plus";
            defaultCursorPictureBox.BackgroundImage = Resources.defaultCursorIconDisabled;
            plusCursorPictureBox.BackgroundImage = Resources.plusCursorIcon;
        }

        private void defaultCursorPictureBox_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentCursor == "Default")
                return;

            StaticData.Settings.CurrentCursor = "Default";
            defaultCursorPictureBox.BackgroundImage = Resources.defaultCursorIcon;
            plusCursorPictureBox.BackgroundImage = Resources.plusCursorIconDisabled;
        }

        private void soundToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if(soundToggleButton.Checked)
            {
                soundToggleValueLabel.Text = "On";
                StaticData.Settings.IsSoundOn = true;
                return;
            }
            soundToggleValueLabel.Text = "Off";
            StaticData.Settings.IsSoundOn = false;
        }

        private void difficultyUpButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentDifficulty == "Easy")
            {
                difficultyValueLabel.Text = "Normal";
                StaticData.Settings.CurrentDifficulty = "Normal";
                difficultyPictureBox.BackgroundImage = Resources.mediumIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Normal")
            {
                difficultyValueLabel.Text = "Hard";
                StaticData.Settings.CurrentDifficulty = "Hard";
                difficultyPictureBox.BackgroundImage = Resources.hardIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Hard")
            {
                difficultyValueLabel.Text = "Extreme";
                StaticData.Settings.CurrentDifficulty = "Extreme";
                difficultyPictureBox.BackgroundImage = Resources.extremeIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Extreme")
            {
                difficultyValueLabel.Text = "Easy";
                StaticData.Settings.CurrentDifficulty = "Easy";
                difficultyPictureBox.BackgroundImage = Resources.easyIcon;
            }
        }

        private void difficultyDownButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentDifficulty == "Easy")
            {
                difficultyValueLabel.Text = "Extreme";
                StaticData.Settings.CurrentDifficulty = "Extreme";
                difficultyPictureBox.BackgroundImage = Resources.extremeIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Normal")
            {
                difficultyValueLabel.Text = "Easy";
                StaticData.Settings.CurrentDifficulty = "Easy";
                difficultyPictureBox.BackgroundImage = Resources.easyIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Hard")
            {
                difficultyValueLabel.Text = "Normal";
                StaticData.Settings.CurrentDifficulty = "Normal";
                difficultyPictureBox.BackgroundImage = Resources.mediumIcon;
            }
            else if (StaticData.Settings.CurrentDifficulty == "Extreme")
            {
                difficultyValueLabel.Text = "Hard";
                StaticData.Settings.CurrentDifficulty = "Hard";
                difficultyPictureBox.BackgroundImage = Resources.hardIcon;
            }
        }

        private void darkPinkColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "darkPink")
                return;
            darkPinkColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "darkPink";
            setEveryOtherBorderToZero("darkPinkColorButton");
        }

        private void purpleColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "purple")
                return;
            purpleColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "purple";
            setEveryOtherBorderToZero("purpleColorButton");
        }

        private void pinkColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "pink")
                return;
            pinkColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "pink";
            setEveryOtherBorderToZero("pinkColorButton");
        }

        private void lightBlueColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "lightBlue")
                return;
            lightBlueColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "lightBlue";
            setEveryOtherBorderToZero("lightBlueColorButton");
        }

        private void orangeColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "orange")
                return;
            orangeColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "orange";
            setEveryOtherBorderToZero("orangeColorButton");
        }

        private void greenColorButton_Click(object sender, EventArgs e)
        {
            if (StaticData.Settings.CurrentColor == "green")
                return;
            greenColorButton.BorderSize = 2;
            StaticData.Settings.CurrentColor = "green";
            setEveryOtherBorderToZero("greenColorButton");
        }

        private void setEveryOtherBorderToZero(string buttonName)
        {
            targetColorPanel.Controls.OfType<CustomButton>().ToList().ForEach(customButton =>
            {
                if (customButton.Name != buttonName)
                    customButton.BorderSize = 0;
            });
        }
    }
}
