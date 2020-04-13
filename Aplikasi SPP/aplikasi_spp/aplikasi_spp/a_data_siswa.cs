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
    public partial class a_data_siswa : Form
    {
        public a_data_siswa()
        {
            InitializeComponent();
            tampilandatagrid();
        }

        

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            string koneksi = "server=localhost;database=aplikasispp;uid=root;pwd=''";
            MySqlConnection conn = new MySqlConnection(koneksi);
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO siswa(nis,nama_siswa,alamat,no_telp)value(@nis,@nama_siswa,@alamat,@no_telp)";
            //cmd.Parameters.AddWithValue("@nisn",nisn.Text);
            cmd.Parameters.AddWithValue("@nis", nis.Text);
            cmd.Parameters.AddWithValue("@nama_siswa", nama_siswa.Text);
            cmd.Parameters.AddWithValue("@alamat", alamat.Text);
            cmd.Parameters.AddWithValue("@no_telp", no_telp.Text);
            MessageBox.Show("Data Telah Disimpan");
            cmd.ExecuteNonQuery();
            nisn.Text = "";
            nis.Text = "";
            nama_siswa.Text = "";
            alamat.Text = "";
            no_telp.Text = "";
            tampilanclear();
            conn.Close();
            tampilandatagrid();
           
        }

        private void tampilanclear()
        {
            nisn.Clear();
            nis.Clear();
            alamat.Clear();
            no_telp.Clear();

        }
        private void tampilandatagrid()
        {
            string koneksi="server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(koneksi);

            MySqlCommand cmd = new MySqlCommand("SELECT nisn, nis, nama_siswa, alamat, no_telp from siswa", conn);
            DataTable dt = new DataTable();

            conn.Open();

            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

               //id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();   
               nisn.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
               nis.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
               nama_siswa.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
               alamat.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
               no_telp.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
               
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a_data_pet dat = new a_data_pet();
            dat.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
               string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
               MySqlConnection conn1 = new MySqlConnection(connectionString);

               string Query = "update siswa set nisn='" + this.nisn.Text + "',nis='" + this.nis.Text + "',nama_siswa='" + this.nama_siswa.Text + "',alamat='" + this.alamat.Text + "',no_telp='" + this.no_telp.Text + "' where nisn='" + this.nisn.Text + "';"; 
               MySqlCommand MyCommand2 = new MySqlCommand(Query, conn1);
               MySqlDataReader MyReader2;
               conn1.Open();
               MyReader2 = MyCommand2.ExecuteReader();
               MessageBox.Show("Data Updated");
               while (MyReader2.Read())
               {
               }
               nisn.Text = "";
               nis.Text = "";
               nama_siswa.Text = "";
               alamat.Text = "";
               no_telp.Text = "";
               id.Text = "";
               conn1.Close();
               tampilandatagrid();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            string connectionString = "server=localhost;database=aplikasispp;uid=root;pwd='';";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string Query = "DELETE FROM siswa WHERE nisn ='" + this.nisn.Text + "';";
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
                id.Text = "";
                nisn.Text = "";
                nis.Text = "";
                nama_siswa.Text = "";
                alamat.Text = "";
                no_telp.Text = "";
                tampilandatagrid();
            }
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            a_data_kelas ad = new a_data_kelas();
            ad.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            a_awal a = new a_awal();
            a.Show();
            this.Hide();

        }

        private void alamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void nama_siswa_TextChanged(object sender, EventArgs e)
        {

        }

        private void nis_TextChanged(object sender, EventArgs e)
        {

        }

        private void nisn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void no_telp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        //if ( nisn.Text=="" &&)


        }
    }

