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
using System.Configuration;

namespace aplikasi_spp
{
    public partial class join : Form
    {
        public join()
        {
            InitializeComponent();
        }

        private void join_Load(object sender, EventArgs e)
        {
            string maincon = ConfigurationManager.ConnectionStrings["koneksi"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(maincon);
            
        }
    }
}
