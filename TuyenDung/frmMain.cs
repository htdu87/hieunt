using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuyenDung
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void dmNguonTin_Click(object sender, EventArgs e)
        {
            new frmNguonTin().Show();
        }

        private void dmTinhThanh_Click(object sender, EventArgs e)
        {
            new frmTinhThanh().Show();
        }
    }
}
