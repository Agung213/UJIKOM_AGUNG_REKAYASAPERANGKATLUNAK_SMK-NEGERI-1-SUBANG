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
    public partial class a_awal : Form
    {
        public a_awal()
        {
            InitializeComponent();
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datapetugas_MouseClick(object sender, MouseEventArgs e)
        {
            a_data_pet ad = new a_data_pet();
            ad.Show();
            this.Hide();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            a_spp b = new a_spp();
            b.Show();
            this.Hide();
        }

        

       
    }
}
