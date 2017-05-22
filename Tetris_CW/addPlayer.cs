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
    public partial class addPlayer : Form
    {
        
        public Form leaderF;
        public BindingSource bs;
        public Form1 mainf;
        public addPlayer(Form leaderForm,Form1 mainForm, BindingSource bd)
        {
            InitializeComponent();
            leaderF = leaderForm;
            mainf = mainForm;
            bs = bd;
        }

        private void addPlayer_Load(object sender, EventArgs e)
        {

        }

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (nameBox.Text == "")
                {
                    this.Close();
                }
                else
                {
                    if (true)
                    {

                    }
                    Form1.playerName = nameBox.Text;
                    Engine.updatePlayerName(mainf);
                    bs.Add(new Player { Name = Form1.playerName, Score = 0 });
                    this.Close();
                }
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
