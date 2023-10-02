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
    public partial class LeaderBoardForm : Form
    {
        public LeaderBoardForm()
        {
            InitializeComponent();
        }

        private void gameSettingsButton_Click(object sender, EventArgs e)
        {
            StaticData.closedByX = false;
            this.Close();
            Application.OpenForms[2].Close();
            Application.OpenForms[1].Close();
            StaticData.closedByX = true;
            Application.OpenForms[0].Show();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            StaticData.closedByX = false;
            this.Close();
            Application.OpenForms[2].Close();
            Application.OpenForms[1].Close();
            StaticData.closedByX = true;
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void LeaderBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticData.closedByX)
                Application.Exit();
        }
    }
}
