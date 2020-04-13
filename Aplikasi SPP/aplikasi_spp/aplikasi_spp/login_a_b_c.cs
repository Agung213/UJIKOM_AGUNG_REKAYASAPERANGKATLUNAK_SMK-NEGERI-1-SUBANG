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
    public partial class login_a_b_c : Form
    {
        public login_a_b_c()
        {
            InitializeComponent();
        }



        private void login_Click(object sender, EventArgs e)
        {
            string adm = "ADMIN";
            string pet = "PETUGAS";
            string user = username.Text;
            string pass = password.Text;
            string koneksi = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection con = new MySqlConnection(koneksi);

            if (user == "" && pass== "")
            {
                MessageBox.Show("Harap Masukan Username dan Password", "Peringatan !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user == "")
            {
                MessageBox.Show("Harap Masukan Username", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user == "")
            {
                MessageBox.Show("Harap Masukan Password", "Peringatan !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Ingin Login?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                try
                {
                    con.Open();
                    

                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM petugas WHERE username = '" + user + "' && password='" + pass + "' && level='" + adm + "'", con);
                    MySqlDataAdapter da1 = new MySqlDataAdapter("SELECT * FROM petugas WHERE username = '" + user + "' && password='" + pass + "' && level='" + pet + "'", con);
                    MySqlDataAdapter da2 = new MySqlDataAdapter("SELECT * FROM siswa WHERE nama_siswa = '" + user + "' && nis='" + pass + "'", con);
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    da.Fill(dt);
                    da1.Fill(dt1);
                    da2.Fill(dt2);

                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        MessageBox.Show("Selamat Datang " + user + ".");
                        a_awal awal_admin = new a_awal();
                        awal_admin.Show();
                    }
                    else if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Selamat Datang " + user + ".");
                        b_awal b_petugas = new b_awal();
                        b_petugas.Show();
                        this.Hide();
                    }
                    else if (dt2.Rows.Count > 0)
                    {
                        MessageBox.Show("Selamat Datang " + user + ".");
                        c_awal_siswa c_siswa = new c_awal_siswa();
                        c_siswa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("data salah", "peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    con.Close();
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show("Tak Ada Koneksi");                
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Benarkah Ingin Keluar?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}

