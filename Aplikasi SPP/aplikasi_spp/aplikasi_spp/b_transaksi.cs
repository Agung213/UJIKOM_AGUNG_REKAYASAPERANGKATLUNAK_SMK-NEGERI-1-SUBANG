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

namespace aplikasi_spp
{
    public partial class b_transaksi : Form
    {
        public b_transaksi()
        {
            InitializeComponent();
            tampildata();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            b_awal a = new b_awal();
            a.Show();
            this.Hide();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string Query = "DELETE FROM pembayaran WHERE id_pembayaran ='" + this.id_pembayaran.Text + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            DialogResult dialog = MessageBox.Show("Apakah benar ingin di hapus?", "Hapus", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MessageBox.Show("Data Berhasil di Hapus");
                while (MyReader2.Read())
                {
                }
                conn.Close();
                id_pembayaran.Text = "";
                id_petugas.Text = "";
                nisn.Text = "";
                tgl_bayar.Text = "";
                bulan_dibayar.Text = "";
                tahun_dibayar.Text = "";
                id_spp.Text = "";
                jumlah_bayar.Text = "";
                conn.Close();
                tampildata();

            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn1 = new MySqlConnection(connectionString);
            string query = "update pembayaran set  id_petugas='" + this.id_petugas.Text + "',nisn='" + this.nisn.Text + "',tgl_bayar'" + this.tgl_bayar.Text + "',bulan_dibayar'" + this.bulan_dibayar.Text + "',tahun_dibayar'" + this.tahun_dibayar.Text + "',id_spp'" + this.id_spp.Text + "',jumlah_bayar'" + this.jumlah_bayar.Text + "' where id_pembayaran='" + this.id_pembayaran.Text + "';";
            MySqlCommand MyCommand2 = new MySqlCommand(query, conn1);
            MySqlDataReader MyReader;
            conn1.Open();
            MyReader = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Diperbaharui");
            while (MyReader.Read())
            {
            }
            id_petugas.Text = "";
            nisn.Text = "";
            tgl_bayar.Text = "";
            bulan_dibayar.Text = "";
            tahun_dibayar.Text = "";
            id_spp.Text = "";
            jumlah_bayar.Text = "";
            conn1.Close();
            tampildata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_pembayaran.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            id_petugas.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            nisn.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tgl_bayar.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            bulan_dibayar.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            tahun_dibayar.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            id_spp.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            jumlah_bayar.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void tampildata()
        {
            string koneksi = "server= localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM pembayaran", conn);
            DataTable dt = new DataTable();

            conn.Open();

            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            if (id_petugas.Text == "" && nisn.Text == "" && tgl_bayar.Text == "")
            {
                MessageBox.Show("Username, Password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bulan_dibayar.Text == "" && tahun_dibayar.Text == "" && jumlah_bayar.Text == "< Pilih >")
            {
                MessageBox.Show("Nama, password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Apakah ingin di simpan?", "Simpan", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {

                    /*string constring = "server=localhost;database=aplikasispp;uid=root;pwd='';";
                    string query="insert into pembayaran (id_petugas,nisn,tgl_bayar,bulan_dibayar,tahun_dibayar,id_spp,jumlah_bayar)"+"value('"+this.id_petugas.Text+"','"+this.nisn.Text+"','"+this.tgl_bayar.Text+"','"+this.bulan_dibayar.Text+"','"+this.tahun_dibayar.Text+"','"+this.id_spp.Text+"','"+this.jumlah_bayar.Text+"');";
                    MySqlConnection condatabase = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand(query, condatabase);
                    MySqlDataReader myreader;
                    try
                    {
                        condatabase.Open();
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("Tersimpan");
                        while (myreader.Read())
                        {

                        }

                    }
                    */

                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO pembayaran(id_petugas,nisn,tgl_bayar,bulan_dibayar,tahun_dibayar,id_spp,jumlah_bayar)value(@id_petugas,@nisn,@tgl_bayar,@bulan_dibayar,@tahun_dibayar,@id_spp,@jumlah_bayar)";
                    cmd.Parameters.AddWithValue("@id_petugas", id_petugas.Text);
                    cmd.Parameters.AddWithValue("@nisn", nisn.Text);
                    cmd.Parameters.AddWithValue("@tgl_bayar", tgl_bayar.MaxDate);
                    cmd.Parameters.AddWithValue("@bulan_dibayar", bulan_dibayar.Text);
                    cmd.Parameters.AddWithValue("@tahun_dibayar", tahun_dibayar.Text);
                    cmd.Parameters.AddWithValue("@id_spp", id_spp.Text);
                    cmd.Parameters.AddWithValue("@jumlah_bayar", jumlah_bayar.Text);
                    MessageBox.Show("Data Telah disimpan");
                    cmd.ExecuteNonQuery();
                    id_petugas.Text = "";
                    nisn.Text = "";
                    tgl_bayar.Text = "";
                    bulan_dibayar.Text = "";
                    tahun_dibayar.Text = "";
                    id_spp.Text = "";
                    jumlah_bayar.Text = "";
                    tampildata();

                }
            }

        }

    }
}
