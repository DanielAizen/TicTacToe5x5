using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_DanielAizenband_Client
{
    public partial class TicTacToe : Form
    {
        private static HttpClient client = new HttpClient();
        Recording rec = new Recording { NumOfTurns = 0 };
        private readonly RecordingDataContext recDb = new RecordingDataContext();
        Button[] btn_arr; 
        bool turn = true;
        bool game_over = false;
        string username;

        public TicTacToe(string _username,int _pId)
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44365/");
            username = _username;
            rec.PlayerId = _pId;
            PlayerTurnLabel.Text = username.Trim() + " Always Starts";
            btn_arr = this.Controls.OfType<Button>().ToArray();
        }

        private void move_click(object sender, EventArgs e)
        {

            Button move = (Button)sender;
            if (turn)
                move.Text = "X";
            else
                move.Text = "O";
            ButtonAnimation(move);
            move.Enabled = false;
            btn_arr = btn_arr.Where(btn => btn != move).ToArray();
            PlayerTurnLabel.Focus();
            CheckForWinner();
            rec.playerMoves[rec.NumOfTurns] = move.Name;
            rec.NumOfTurns++;
            turn = !turn;

            if (!turn && !game_over)
                ComputerMove();
        }

        private void ButtonAnimation(Button move)
        {
            if (turn)
                move.BackColor = Color.Azure;
            else
                move.BackColor = Color.LightSalmon;
            move.Font = new Font("Showcard Gothic", 28);

        }

        private void CheckForWinner()
        {
            //checking each possible combonation of 4 tiles in a row for a win
            bool winnerH = false, winnerV = false, winnerDL = false, winnerDR = false;

            //Horizonal checks
            winnerH = CheckWinnerHorizontal();

            //Vertical checks
            winnerV = CheckWinnerVertical();

            //Diagonal checks
            winnerDL = CheckWinnerLeftDiagonal();
            winnerDR = CheckWinnerRightDiagonal();

            if (winnerH || winnerV || winnerDL || winnerDR)
            {
                this.DisableRemainingButtons();
                game_over = true;
                string is_winner;
                if (turn)
                {
                    rec.Winner = "WIN";
                    is_winner = username.Trim();
                }
                else
                {
                    rec.Winner = "LOSE";
                    is_winner = "computer";
                }
                MessageBox.Show("THE WINNER IS " + is_winner.ToUpper() + "!", "Winner Of The Round");
            }
            else
            {
                if (rec.NumOfTurns == 25)
                {
                    rec.Winner = "Draw";
                    MessageBox.Show("THERE IS NO WINNER - DRAW", "DRAW!");
                }
            }

        }

        private void DisableRemainingButtons()
        {
            Button b = null;
            try
            {
                foreach (Control c in this.Controls)
                {
                    b = c as Button;
                    if (b != null)
                        b.Enabled = false;
                }
            }
            catch { }
        }

        private bool CheckWinnerRightDiagonal()
        {
            //checks the main diagonal 
            if (((A1.Text == B2.Text) && (B2.Text == C3.Text) && (C3.Text == D4.Text) && ((!A1.Enabled) && (!D4.Enabled)))
              || ((B2.Text == C3.Text) && (C3.Text == D4.Text) && (D4.Text == E5.Text) && ((!B2.Enabled) && (!E5.Enabled))))
                return true;

            //checks the secondary diagonals
            if (((A2.Text == B3.Text) && (B3.Text == C4.Text) && (C4.Text == D5.Text) && ((!A2.Enabled) && (!D5.Enabled)))
              || ((B1.Text == C2.Text) && (C2.Text == D3.Text) && (D3.Text == E4.Text) && ((!B1.Enabled) && (!E4.Enabled))))
                return true;
            //if there is no 4 tiles in row continue
            return false;
        }

        private bool CheckWinnerLeftDiagonal()
        {
            //checks the main diagonal 
            if (((A5.Text == B4.Text) && (B4.Text == C3.Text) && (C3.Text == D2.Text) && ((!A5.Enabled) && (!D2.Enabled)))
              || ((B4.Text == C3.Text) && (C3.Text == D2.Text) && (D2.Text == E1.Text) && ((!B4.Enabled) && (!E1.Enabled))))
                return true;

            //checks the secondary diagonals 
            if (((A4.Text == B3.Text) && (B3.Text == C2.Text) && (C2.Text == D1.Text) && ((!A4.Enabled) && (!D1.Enabled)))
              || ((B5.Text == C4.Text) && (C4.Text == D3.Text) && (D3.Text == E2.Text) && ((!B5.Enabled) && (!E2.Enabled))))
                return true;

            //if there is no 4 tiles in row continue
            return false;
        }

        private bool CheckWinnerVertical()
        {
            if (((A1.Text == B1.Text) && (B1.Text == C1.Text) && (C1.Text == D1.Text) && ((!A1.Enabled) && (!D1.Enabled)))
               || ((B1.Text == C1.Text) && (C1.Text == D1.Text) && (D1.Text == E1.Text) && ((!B1.Enabled) && (!E1.Enabled))))
                return true;

            if (((A2.Text == B2.Text) && (B2.Text == C2.Text) && (C2.Text == D2.Text) && ((!A2.Enabled) && (!D2.Enabled)))
               || ((B2.Text == C2.Text) && (C2.Text == D2.Text) && (D2.Text == E2.Text) && ((!B2.Enabled) && (!E2.Enabled))))
                return true;

            if (((A3.Text == B3.Text) && (B3.Text == C3.Text) && (C3.Text == D3.Text) && ((!A3.Enabled) && (!D3.Enabled)))
               || ((B3.Text == C3.Text) && (C3.Text == D3.Text) && (D3.Text == E3.Text) && ((!B3.Enabled) && (!E3.Enabled))))
                return true;

            if (((A4.Text == B4.Text) && (B4.Text == C4.Text) && (C4.Text == D4.Text) && ((!A4.Enabled) && (!D4.Enabled)))
               || ((B4.Text == C4.Text) && (C4.Text == D4.Text) && (D4.Text == E4.Text) && ((!B4.Enabled) && (!E4.Enabled))))
                return true;

            if (((A5.Text == B5.Text) && (B5.Text == C5.Text) && (C5.Text == D5.Text) && ((!A5.Enabled) && (!D5.Enabled)))
               || ((B5.Text == C5.Text) && (C5.Text == D5.Text) && (D5.Text == E5.Text) && ((!B5.Enabled) && (!E5.Enabled))))
                return true;

            //if there is no 4 tiles in row continue
            return false;
        }

        private bool CheckWinnerHorizontal()
        {
            if (((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A3.Text == A4.Text) && ((!A1.Enabled) && (!A4.Enabled)))
                || ((A2.Text == A3.Text) && (A3.Text == A4.Text) && (A4.Text == A5.Text) && ((!A2.Enabled) && (!A5.Enabled))))
                return true;

            if (((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B3.Text == B4.Text) && ((!B1.Enabled) && (!B4.Enabled)))
                || ((B2.Text == B3.Text) && (B3.Text == B4.Text) && (B4.Text == B5.Text) && ((!B2.Enabled) && (!B5.Enabled))))
                return true;

            if (((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C3.Text == C4.Text) && ((!C1.Enabled) && (!C4.Enabled)))
                || ((C2.Text == C3.Text) && (C3.Text == C4.Text) && (C4.Text == C5.Text) && ((!C2.Enabled) && (!C5.Enabled))))
                return true;

            if (((D1.Text == D2.Text) && (D2.Text == D3.Text) && (D3.Text == D4.Text) && ((!D1.Enabled) && (!D4.Enabled)))
                || ((D2.Text == D3.Text) && (D3.Text == D4.Text) && (D4.Text == D5.Text) && ((!D2.Enabled) && (!D5.Enabled))))
                return true;

            if (((E1.Text == E2.Text) && (E2.Text == E3.Text) && (E3.Text == E4.Text) && ((!E1.Enabled) && (!E4.Enabled)))
                || ((E2.Text == E3.Text) && (E3.Text == E4.Text) && (E4.Text == E5.Text) && ((!E2.Enabled) && (!E5.Enabled))))
                return true;
            //if there is no 4 tiles in row continue
            return false;
        }

        private async void ComputerMove()
        {
            Button move = await RandComputerMoveAsync();
            Thread.Sleep(500);
            move.PerformClick();
        }

        private async Task<Button> RandComputerMoveAsync()
        {
            string path = $"api/TblPlayers/rnd/{btn_arr.Length}";
            int r_rnd = await GetRndNumAsync(path);
            return btn_arr[r_rnd];
        }
        static async Task<int> GetRndNumAsync(string path)
        {
            int rnd = 0;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                rnd = await response.Content.ReadAsAsync<int>();
            }

            return rnd;
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            this.resetBoard();  
        }

        private void resetBoard()
        {
            turn = true;
            game_over = false;
            rec.NumOfTurns = 0;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void saveExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TblRecord tbl = new TblRecord
            {
                NumOfTurns = rec.NumOfTurns,
                PlayerId = rec.PlayerId,
                PlayerMoves = string.Join(",", rec.playerMoves),
                Winner = rec.Winner
            };
            recDb.TblRecords.InsertOnSubmit(tbl);
            recDb.SubmitChanges();
            Game game = new Game { PlayerId = rec.PlayerId, Winner = rec.Winner };
            var url = await CreateGamesAsync(game);
            this.Close();
        }

        static async Task<Uri> CreateGamesAsync(Game game)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/TblGames", game);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
    
}
