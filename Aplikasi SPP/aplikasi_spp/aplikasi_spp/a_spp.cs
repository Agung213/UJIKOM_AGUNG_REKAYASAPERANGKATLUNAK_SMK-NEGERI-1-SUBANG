using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;

namespace aplikasi_spp
{
    public partial class a_spp : Form
    {
        public a_spp()
        {
            InitializeComponent();
            tampilandatagrid();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            a_awal ad = new a_awal();
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            a_transaksi a = new a_transaksi();
            a.Show();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            string thn = bulan.Text;
            string nml = nominal.Text;
            string bln = bulan.Text;
            string koneksi = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);
            conn.Open();
            if (thn == "< Pilih >" && nml == "< Pilih >")
            {
                MessageBox.Show("Username, Password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (thn == "< Pilih >")
            {
                MessageBox.Show("Nama, password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nml == "< Pilih >")
            {
                MessageBox.Show("Nama, Username harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Apakah ingin di simpan?", "Simpan", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO spp(tahun,bulan,nominal)value(@tahun,@bulan,@nominal)";
                    cmd.Parameters.AddWithValue("@tahun", tahun.Text);
                    cmd.Parameters.AddWithValue("@bulan", bulan.Text);
                    cmd.Parameters.AddWithValue("@nominal", nominal.Text);
                    MessageBox.Show("Data Telah Tersimpan");
                    cmd.ExecuteNonQuery();
                    tahun.Text = "";
                    bulan.Text = "";
                    nominal.Text = "";
                    conn.Close();
                    tampilandatagrid();
                }
            }
        }
        private void tampilandatagrid()
        {
            string koneksi = "server= localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM spp", conn);
            DataTable dt = new DataTable();

            conn.Open();

            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_spp.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tahun.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            bulan.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            nominal.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            string kon = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection c = new MySqlConnection(kon);
            string query = "update spp set tahun='" + this.tahun.Text + "',bulan='" + this.bulan.Text + "', nominal= '" + this.nominal.Text + "'where id_spp='" + this.id_spp.Text + "';";
            MySqlCommand mycommand1 = new MySqlCommand(query, c);
            MySqlDataReader myreader2;
            c.Open();
            myreader2 = mycommand1.ExecuteReader();
            MessageBox.Show("Data Berhasil di Perbaharui");
            while (myreader2.Read())
            {
            }
            tahun.Text = "";
            bulan.Text = "";
            nominal.Text = "";
            c.Close();
            tampilandatagrid();

        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            string kon1 = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection k = new MySqlConnection(kon1);
            k.Open();
            string query = "DELETE FROM spp where id_spp ='" + this.id_spp.Text + "';";
            MySqlCommand MyCommand = new MySqlCommand(query, k);
            MySqlDataReader MyReader;

            MyReader = MyCommand.ExecuteReader();
            DialogResult dialog = MessageBox.Show("Apakah benar ingin di hapus?", "Hapus", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Data Berhasil di Hapus");
                while (MyReader.Read())
                {
                }
                id_spp.Text = "";
                tahun.Text = "";
                bulan.Text = "";
                nominal.Text = "";
                k.Close();
                tampilandatagrid();
            }


        }
    }
}

