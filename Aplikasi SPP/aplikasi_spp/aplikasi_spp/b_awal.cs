using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_spp
{
    public partial class b_awal : Form
    {
        public b_awal()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b_awal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
            a_awal a = new a_awal();
            a.Show();


        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Benarkah Ingin Keluar?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                login_a_b_c a = new login_a_b_c();
                a.Show();
            }
            else
            {
                this.Show();

            }
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            
            b_transaksi b = new b_transaksi();
            b.Show();
            this.Hide();

        }
    }
}
