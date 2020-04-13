using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace aplikasi_spp
{
    public partial class a_data_kelas : Form
    {
        public a_data_kelas()
        {
            InitializeComponent();
            tampilandatadrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            a_data_siswa sis = new a_data_siswa();
            sis.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            a_data_pet petu = new a_data_pet();
            petu.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            a_awal a = new a_awal();
            a.Show();
            this.Hide();
        }



        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            string koneksi = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);
            conn.Open();
            if (nama_kelas.Text == "< Pilih >" && kompetensi_keahlian.Text == "< Pilih >" && tingkat.Text == "< Pilih >")
            {
                MessageBox.Show("Kelas, jurusan dan tingkatnya harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_kelas.Text == "< Pilih >" && kompetensi_keahlian.Text == "< Pilih >")
            {
                MessageBox.Show("Kelas dan jurusannya harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_kelas.Text == "< Pilih >" && tingkat.Text == "< Pilih >")
            {
                MessageBox.Show("Kelas dan tingkatya harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (kompetensi_keahlian.Text == "< Pilih >" && tingkat.Text == "< Pilih >")
            {
                MessageBox.Show("Jurusan dan tingkatnya harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tingkat.Text == "< Pilih >")
            {
                MessageBox.Show("Tingkatnya harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nama_kelas.Text == "< Pilih >")
            {
                MessageBox.Show("Kelas harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (kompetensi_keahlian.Text == "< Pilih >")
            {
                MessageBox.Show("Jurusan harap di pilih terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Apakah ingin di simpan?", "Simpan", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MySqlCommand cmd;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO kelas(nama_kelas,kompetensi_keahlian,tingkat)value(@nama_kelas,@kompetensi_keahlian,@tingkat)";
                    cmd.Parameters.AddWithValue("@nama_kelas", nama_kelas.Text);
                    cmd.Parameters.AddWithValue("@kompetensi_keahlian", kompetensi_keahlian.Text);
                    cmd.Parameters.AddWithValue("@tingkat", tingkat.Text);
                    MessageBox.Show("Data Telah Tersimpan");
                    cmd.ExecuteNonQuery();
                    nama_kelas.Text = "";
                    kompetensi_keahlian.Text = "";
                    tingkat.Text = "";
                    conn.Close();
                    tampilandatadrid();
                }
            }
        }


           

        private void tampilandatadrid()
        {
            string konek = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection con = new MySqlConnection(konek);
            MySqlCommand cm = new MySqlCommand("SELECT * FROM kelas",con);
            DataTable dt = new DataTable();
            con.Open();
            MySqlDataReader sdr = cm.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_kelas.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            nama_kelas.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            kompetensi_keahlian.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tingkat.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            string kon = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection c = new MySqlConnection(kon);
            string query = "update kelas set nama_kelas='" + this.nama_kelas.Text + "',kompetensi_keahlian='" + this.kompetensi_keahlian.Text + "', tingkat= '" + this.tingkat.Text + "'where id_kelas='" + this.id_kelas.Text + "';"; 
            MySqlCommand mycommand1 = new MySqlCommand(query, c);
            MySqlDataReader myreader2;
            c.Open();
            myreader2 = mycommand1.ExecuteReader();
            MessageBox.Show("Data Berhasil di Perbaharui");
            while (myreader2.Read())
            {
            }
            nama_kelas.Text = "";
            kompetensi_keahlian.Text = "";
            tingkat.Text = "";
            c.Close();
            tampilandatadrid();
            
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            string kon1 = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection k = new MySqlConnection(kon1);
            k.Open();
            string query = "DELETE FROM kelas where id_kelas ='" + this.id_kelas.Text + "';";
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
                k.Close();
                nama_kelas.Text = "";
                kompetensi_keahlian.Text = "";
                tingkat.Text = "";

                tampilandatadrid();
            }
        }


    }
}
