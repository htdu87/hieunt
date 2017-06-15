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
    public partial class frmNguonTin : BaseChildForm
    {
        private NGUON nguon;

        private void FillData()
        {
            using(var db = new DatabaseContext())
            {
                List<NGUON> data = db.NGUONs.ToList();
                dataGridView1.DataSource = new BindingSource(data, null);
            }
        }

        public frmNguonTin()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                if(nguon==null)
                {
                    NGUON n = new NGUON();
                    n.TEN_NGUON = textBox1.Text;
                    db.NGUONs.Add(n);
                }
                else
                {
                    db.NGUONs.FirstOrDefault(n => n.ID_NGUON == nguon.ID_NGUON).TEN_NGUON=textBox1.Text;
                }

                if(db.SaveChanges()>0)
                {
                    FillData();
                    textBox1.Text = String.Empty;
                    textBox1.Focus();
                    btnOK.Text = "Thêm";
                    btnCancel.Enabled = false;
                    nguon = null;
                }
            }
        }

        private void frmNguonTin_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            using (var db = new DatabaseContext())
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Column1"].Value;
                nguon = db.NGUONs.FirstOrDefault(n => n.ID_NGUON == id);
                if(nguon!=null)
                {
                    textBox1.Text = nguon.TEN_NGUON;
                    btnOK.Text = "Cập nhật";
                    btnCancel.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox1.Focus();
            btnOK.Text = "Thêm";
            btnCancel.Enabled = false;
        }
    }
}
