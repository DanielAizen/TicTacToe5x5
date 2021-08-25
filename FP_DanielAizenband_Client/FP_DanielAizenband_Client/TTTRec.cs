using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_DanielAizenband_Client
{
    public partial class TTTRec : Form
    {
        Recording r = new Recording();
        int i;
        public TTTRec(TblRecord tblRecord)
        {
            InitializeComponent();
            r.NumOfTurns = tblRecord.NumOfTurns;
            r.PlayerId = tblRecord.PlayerId;
            r.playerMoves = tblRecord.PlayerMoves.Trim().Split(',');
            r.Winner = tblRecord.Winner.Trim();
            Rec_show_button.Text = "Show Rec";

        }

        private void TTTRec_Load(object sender, EventArgs e)
        {
            this.resetBoard();
            Rec_show_button.Text = "Show Rec";
        }

        private void Rec_click(object sender, EventArgs e)
        {
            Button move = (Button)sender;
           
            if (i % 2 == 0)
                move.Text = "X";
            else
                move.Text = "O";
            ButtonAnimation(move, i);
            move.Enabled = false;

        }
        private void ButtonAnimation(Button move, int i)
        {
            if (i % 2 == 0)
                move.BackColor = Color.Azure;
            else
                move.BackColor = Color.LightSalmon;
            move.Font = new Font("Showcard Gothic", 28);

        }

        private void Rec_show_button_Click(object sender, EventArgs e)
        {
            Button btn = null;
            for (i = 0; i < r.NumOfTurns; i++)
            {
                btn = Controls.OfType<Button>().FirstOrDefault(b => b.Name == r.playerMoves[i]);
                Thread.Sleep(250);
                btn.PerformClick();
            }
            MessageBox.Show($"the result was {r.Winner.ToUpper()}", "end of rec");
        }
        private void resetBoard()
        {
            Button b = null;
            try
            {
                
                foreach (Control c in this.Controls)
                {
                    b = c as Button;
                    if (b != null)
                    {
                        b.Enabled = true;
                        b.Text = "";
                        b.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch { }
        }
    }
}
