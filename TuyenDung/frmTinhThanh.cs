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
    public partial class frmTinhThanh : BaseChildForm
    {
        private int selID;

        private void FillData()
        {
            using(var db = new DatabaseContext())
            {
                List<DM_TINH> data = db.DM_TINH.ToList();
                dataGridView1.DataSource = new BindingSource(data, null);
            }
        }

        private void Reset()
        {
            textBox1.Text = textBox2.Text = String.Empty;
            btnOK.Text = "Thêm";
            selID = 0;
            btnCancal.Enabled = false;
        }

        public frmTinhThanh()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmTinhThanh_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using(var db = new DatabaseContext())
            {
                if(selID==0)
                {
                    DM_TINH t = new DM_TINH();
                    t.MA_TINH = textBox1.Text;
                    t.TEN_TINH = textBox2.Text;
                    db.DM_TINH.Add(t);
                }
                else
                {
                    DM_TINH t = db.DM_TINH.FirstOrDefault(n => n.ID_TINH == selID);
                    t.MA_TINH = textBox1.Text;
                    t.TEN_TINH = textBox2.Text;
                }

                if(db.SaveChanges()>0)
                {
                    FillData();
                    Reset();
                }
            }
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            selID = (int)dataGridView1.SelectedRows[0].Cells["Column1"].Value;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Column3"].Value.ToString();
            btnOK.Text = "Cập nhật";
            btnCancal.Enabled = true;
        }

    }
}
