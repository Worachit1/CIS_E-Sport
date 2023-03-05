using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS_E_Sport
{
    public partial class FormAllPlayer : Form
    {
        List<Player> listPlayers = new List<Player>();
        Player selectPlayer;
        public FormAllPlayer()
        {
            InitializeComponent();       
            //dataGridView1.DataSource = listPlayers;
        }

        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();

            if(formInfo.DialogResult == DialogResult.OK)
            {
                Player newplayer = formInfo.getPlayer();
                //Add new Player to List
                this.listPlayers.Add(newplayer);

                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = listPlayers;
                //Add list to Datagrid view
                formInfo.Close();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TEXT|*.txt|CSV|*.csv";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    this.dataGridView1.DataSource = listPlayers;
                    reader.ReadLine();                   
                }
            }
            
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save data form list to CSV file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TEXT|*.txt|CSV|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Player item in listPlayers)
                    {
                        writer.WriteLine(String.Format("{0} ,{1} , {2} ",
                        item.Name,
                        item.Lastname,
                        item.Major));
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                this.selectPlayer = (Player)row.DataBoundItem;

                this.tbName2.Text = selectPlayer.Name;
                this.tbLastname.Text = selectPlayer.Lastname;
            }
        }
    }
}
