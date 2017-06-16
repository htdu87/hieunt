﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public partial class frmMain : Form
    {
        private Thread thread;

        private void FillData()
        {
            using(var db = new RoboDataEntities())
            {
                List<Recruitment> data = db.Recruitments.OrderByDescending(r => r.Rodate).ToList();
                dataGridView1.DataSource = new BindingSource(data, null);
            }
        }

        private void FillForm()
        {
            using (var db = new RoboDataEntities())
            {
                List<Province> dataPro = db.Provinces.OrderBy(p=>p.IdPro).ToList();
                List<Recruitment> dataRec = db.Recruitments.OrderByDescending(r => r.Rodate).ToList();

                Invoke((MethodInvoker)delegate
                {
                    cmbTinh.ComboBox.DataSource = new BindingSource(dataPro, null);
                    cmbTinh.ComboBox.DisplayMember = "Name";
                    dataGridView1.DataSource = new BindingSource(dataRec, null);
                    lblStatus.Text = "Ready";
                    btnStart.Enabled = true;
                });
            }
        }


        private void Run(string url)
        {
            Invoke((MethodInvoker)delegate
            {
                progBar.Value = 0;
                progBar.Visible = true;
                lblStatus.Text = "Getting data...";
            });
            
            using (var db = new RoboDataEntities())
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = web.Load(url);
                foreach (HtmlNode node in document.DocumentNode.SelectNodes("//table[contains(@class, 'table-content')]/tbody/tr"))
                {
                    string href = node.SelectSingleNode("td/a[contains(@class,'item')]").Attributes["href"].Value;
                    string code = href.Substring(href.LastIndexOf('-') + 1).Replace(".html", "");
                    string position = node.SelectSingleNode("td/a[contains(@class,'item')]").Attributes["title"].Value;
                    string[] places = node.SelectSingleNode("td[2]/span").InnerText.Trim().Split('\n');
                    for (int i = 0; i < places.Length; i++)
                    {
                        places[i] = places[i].Trim();
                    }
                    string place = String.Join("/", places);
                    string salary = node.SelectSingleNode("td[3]").InnerText.Trim();
                    string expiry = node.SelectSingleNode("td[4]").InnerText.Trim();

                    if (db.Recruitments.FirstOrDefault(r => r.Code == code) == null)
                    {
                        Recruitment rec = new Recruitment();
                        rec.Code = code;
                        rec.Position = position;
                        rec.Salary = salary;
                        rec.Place = place;
                        rec.Expiry = expiry;
                        rec.Url = href;
                        rec.Saved = false;
                        rec.Rodate = DateTime.Now;
                        db.Recruitments.Add(rec);
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        progBar.Value += 1;
                    });
                }

                if (db.SaveChanges() > 0)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        FillData();
                    });
                }
            }
            
            Invoke((MethodInvoker)delegate
            {
                progBar.Visible = false;
                lblStatus.Text = "Ready";
            });
        }

        public frmMain()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Loading data...";
            new Thread(() => FillForm()).Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string url = ((Province)cmbTinh.ComboBox.SelectedValue).Url;
            thread = new Thread(() => Run(url));
            thread.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells["colIdRec"].Value;
                    using(var db = new RoboDataEntities())
                    {
                        db.Recruitments.Remove(db.Recruitments.FirstOrDefault(r=>r.IdRec==id));
                        if(db.SaveChanges()>0)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string url = dataGridView1.SelectedRows[0].Cells["colUrl"].Value.ToString();
            if (new frmDetail(url).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
    }
}