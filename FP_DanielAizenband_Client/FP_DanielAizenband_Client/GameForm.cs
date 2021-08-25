using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_DanielAizenband_Client
{
    public partial class GameForm : Form
    {
        TicTacToe ttt_game;
        RecordingForm recFrm;
        Player player;
        Form1 frm1 = new Form1();
        public GameForm(Player rp)
        {
            InitializeComponent();
            player = rp;
            ttt_game = new TicTacToe(player.Username,player.Id);
            recFrm = new RecordingForm(player.Id);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            string name =  player.Username.Trim();
            PlayerLabel.Text = "Hello " + name;
        }

        private void StartGame_button_Click(object sender, EventArgs e)
        {
            ttt_game.ShowDialog();
        }

        private void Recordings_button_Click(object sender, EventArgs e)
        {
            
            recFrm.ShowDialog();
        }

        private void LogOut_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
