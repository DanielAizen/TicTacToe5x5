using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_DanielAizenband_Client
{
    public partial class Form1 : Form
    {
        Player rp;
        private static HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44365/");
            TblBindingNavigator.BindingSource = TblBindingSource;
        }

        static async Task<Player> GetPlayerAsync(string path)
        {
            Player player = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<Player>();
            }
            return player;
        }

        private async void SignIn_Click(object sender, EventArgs e)
        {
            await Task.Delay(1500);
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

             SignIn.Click += async (s, ev) =>
             {
                 await Task.Delay(1000);
                 string path = $"api/TblPlayers/{username}/{password}";
                 rp = await GetPlayerAsync(path);
                 if (rp != null)
                 {
                     GameForm gf = new GameForm(rp);
                     MessageBox.Show($"Hello and welcome back {rp.Username.Trim()}\n{rp.Phone.Trim()}\n{rp.Email.Trim()}");
                     gf.ShowDialog();
                 }

                
                 await Task.Delay(500);
                 UsernameTextBox.Clear();
                 PasswordTextBox.Clear();
                };

            await Task.Delay(2500);
            username = "";
            password = "";
        }
    }
}
