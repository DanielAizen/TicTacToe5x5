using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_DanielAizenband_Client
{
    public partial class RecordingForm : Form
    {
        private RecordingDataContext recDb = new RecordingDataContext();
        public TblRecord r;
        TTTRec ttt_rec;
        private static HttpClient client = new HttpClient();
        private int is_clicked = -1;
        private int pId;


        public RecordingForm(int id)
        {
            InitializeComponent();
            pId = id;
        }


        private void RecordingForm_Load(object sender, EventArgs e)
        {
            TblDataGridView.DataSource = TblBindingSource;
            TblBindingNavigator.BindingSource = TblBindingSource;
            TblDataGridView.DataSource = from r in recDb.TblRecords
                                         where r.PlayerId == pId
                                         select r;
        }

        private async void SelectedRecButton_Click(object sender, EventArgs e)
        {
            if(is_clicked != -1)
            {
                var rec_to_show = from rec in recDb.TblRecords
                                  where rec.Id == is_clicked
                                  select rec;
                r = rec_to_show.First();
            }
            if (!RadioExButton.Checked)
            {
                ttt_rec = new TTTRec(r);
                ttt_rec.ShowDialog();
            }
            else
            {
                await HeavyCalc();
                RadioExButton.Enabled = false;
                MessageBox.Show("Sorry for the long wait");
                ttt_rec = new TTTRec(r);
                ttt_rec.ShowDialog();
            }
        }

        private async Task HeavyCalc()
        {
            await Task.Run(() => Waiting());
        }

        private void Waiting()
        {
           Thread.Sleep(3000);
        }

        private void TblDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TblDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            is_clicked = Convert.ToInt32(TblDataGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
        }

    }
}
