using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public partial class frmCareers : Form
    {
        private int selId;

        private void FillData()
        {
            using(var db= new RoboDataEntities())
            {
                List<career> data = db.careers.ToList();
                dataGridView1.DataSource = new BindingSource(data, null);
            }
        }

        private void ResetControl()
        {
            selId = 0;
            txtCode.Text = txtName.Text = String.Empty;
            btnOk.Text = "Add";
            btnCancel.Enabled = false;
            txtCode.Focus();
        }

        public frmCareers()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmProvinces_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using(var db = new RoboDataEntities())
            {
                if(selId>0)
                {
                    career c = db.careers.FirstOrDefault(n => n.IdCar == selId);
                    if (c != null)
                    {
                        c.Code = txtCode.Text;
                        c.Name = txtName.Text;
                    }
                }
                else
                {
                    career c = new career();
                    c.Code = txtCode.Text;
                    c.Name = txtName.Text;
                    db.careers.Add(c);
                }

                if (db.SaveChanges() > 0) FillData();
            }
            ResetControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selId = (int)dataGridView1.SelectedRows[0].Cells["colIdCar"].Value;
            txtCode.Text = dataGridView1.SelectedRows[0].Cells["colCode"].Value==null?"":dataGridView1.SelectedRows[0].Cells["colCode"].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells["colName"].Value.ToString();            
            btnCancel.Enabled = true;
            btnOk.Text = "Save";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells["colIdCar"].Value;
                    using (var db = new RoboDataEntities())
                    {
                        db.careers.Remove(db.careers.FirstOrDefault(c => c.IdCar == id));
                        if (db.SaveChanges() > 0)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
