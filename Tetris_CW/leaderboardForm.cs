using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_CW
{
    public partial class leaderboardForm : Form
    {
        public Form1 mainF;
        public static List<Player> players = new List<Player>();

        public leaderboardForm(Form1 mform)
        {
            InitializeComponent();
            mainF = mform;
            playerBindingSource.DataSource = null;
            playerBindingSource.DataSource = players;
            // foreach (Player pl in players)
            // {
            //     dataLeader.Rows.Add(pl.ToString().Split(':'));
            // }
        }

        private void liderboardForm_Load(object sender, EventArgs e)
        {
            //playerBindingSource.DataSource = players;
        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            addPlayer addF = new addPlayer(this, mainF, playerBindingSource);
            addF.Owner = this;
            addF.Show();
        }

        private void selectPlayerButton_Click(object sender, EventArgs e)
        {
            Player selectedPlayer = (Player)(playerBindingSource.Current);
            Form1.playerName = selectedPlayer.Name;
            Engine.updatePlayerName(mainF);
            this.Close();
        }

        private void deletePlayerButton_Click(object sender, EventArgs e)
        {
            playerBindingSource.RemoveCurrent();
        }

        private void playerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
