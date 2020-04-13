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
    public partial class a_data_pet : Form
    {
        public a_data_pet()
        {
            InitializeComponent();
            tampilandatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a_data_siswa daa = new a_data_siswa();
            daa.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_petugas.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            username.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            password.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            nama_petugas.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            level.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            if (username.Text == "" && password.Text == "" && level.Text == "< Pilih >")
            {
                MessageBox.Show("Username, Password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && password.Text == "" && level.Text == "< Pilih >")
            {
                MessageBox.Show("Nama, password harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && username.Text == ""  && level.Text == "< Pilih >")
            {
                MessageBox.Show("Nama, Username harap di isi dan level harap  di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && username.Text == "" && password.Text == "" )
            {
               MessageBox.Show("Nama, username dan password harap di isi" , "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && username.Text == "")
            {
                 MessageBox.Show("Nama dan username harap di isi" , "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && password.Text == "")
            {
            MessageBox.Show("Nama dan password harap di isi" , "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_petugas.Text == "" && level.Text == "< Pilih >")
            {
            MessageBox.Show("Nama harap di isi dan level harap di pilih" , "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (username.Text == "" && password.Text == "")
            {
            MessageBox.Show("username dan passaword harap di isi" , "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Apakah ingin di simpan?", "Simpan", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {

                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO petugas (username,password,nama_petugas,level) VALUES (@username,@password,@nama_petugas,@level)";
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.Parameters.AddWithValue("@nama_petugas", nama_petugas.Text);
                    cmd.Parameters.AddWithValue("@level", level.Text);

                    MessageBox.Show("Data Telah disimpan");
                    cmd.ExecuteNonQuery();
                    username.Text = "";
                    password.Text = "";
                    nama_petugas.Text = "";
                    level.Text = "";
                    conn.Close();
                    tampilandatagrid();
                }
            }
        }
   
        private void tampilandatagrid()
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM petugas", conn);
            DataTable dt = new DataTable();
            conn.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);

            string Query = "update petugas set username='" + this.username.Text + "',password='" + this.password.Text + "',nama_petugas='" + this.nama_petugas.Text + "',level='" + this.level.Text + "' where id_petugas='" + this.id_petugas.Text + "';"; 
            MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader2;
            conn.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            MessageBox.Show("Data Updated");
            while (MyReader2.Read())
            {
            }
            username.Text = "";
            password.Text = "";
            nama_petugas.Text = "";
            level.Text = "";
            id_petugas.Text = "";
            conn.Close();
            tampilandatagrid();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            string koneksi = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);
            conn.Open();
            string Query = "DELETE FROM petugas WHERE id_petugas ='" + this.id_petugas.Text + "';";
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
                id_petugas.Text = "";
                username.Text = "";
                password.Text = "";
                nama_petugas.Text = "";
                level.Text = "";

                tampilandatagrid();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            a_data_kelas kel = new a_data_kelas();
            kel.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            a_awal a = new a_awal();
            a.Show();
            this.Hide();
        }
    }
}
