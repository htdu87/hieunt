﻿using HtmlAgilityPack;
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
    public partial class frmDetail : Form
    {
        private string url;

        private void Run()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);
            txtTen.Text = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/h3").InnerText.Trim();
            txtDiachi.Text = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/span").InnerText.Trim();
            txtTieude.Text = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'text-primary')]/span").InnerText.Trim();
            string tinh = String.Empty;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//article[contains(@class, 'block-content')]/div[5]/div/ul/li[4]/a"))
            {
                tinh += " " + node.InnerText + ",";
            }
            txtTinh.Text = tinh.TrimStart().Trim(',');

            string nnghe = String.Empty;
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//article[contains(@class, 'block-content')]/div[5]/div/ul/li[5]/a"))
            {
                nnghe += " " + node.InnerText + ",";
            }
            txtNganhnghe.Text = nnghe.TrimStart().Trim(',');

            txtMota.Text = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[1]/td[2]").InnerText.Trim();
            txtYeucau.Text = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[2]/td[2]").InnerText.Trim();
            txtQuyenloi.Text = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[3]/td[2]").InnerText.Trim();
            txtHannop.Text = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[4]/td[2]").InnerText.Trim();
        }

        public frmDetail(string url)
        {
            this.url = url;
            InitializeComponent();
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
            Run();
        }
    }
}