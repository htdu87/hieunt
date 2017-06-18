using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            Invoke((MethodInvoker)delegate
            {
                try
                {
                    txtTen.Text = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/h3").InnerText.Trim();
                    txtDiachi.Text = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/span").InnerText.Replace("Địa chỉ:","").Trim();
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

                    var nodeEmail = document.DocumentNode.SelectSingleNode("//article/div[contains(@class, 'block-info-company')]/div/table/tr[3]/td[2]/p");
                    if (nodeEmail != null)
                        txtEmail.Text = nodeEmail.InnerText.Trim();

                    var nodePhone = document.DocumentNode.SelectSingleNode("//article/div[contains(@class, 'block-info-company')]/div/table/tr[4]/td[2]/p");
                    if (nodePhone != null)
                        txtSDT.Text = nodePhone.InnerText.Trim();

                    picLoding.Visible = false;
                }
                catch
                {
                    MessageBox.Show("Can not get detail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            });
        }

        public frmDetail(string url)
        {
            this.url = url;
            InitializeComponent();
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
            new Thread(()=>Run()).Start();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter file = File.AppendText(saveFileDialog1.FileName);
                string[] dates = txtHannop.Text.Split('-');
                file.WriteLine("INSERT INTO `tuyen_dung` (`id`, `ten`, `logo`, `dia_chi`, `dien_thoai`, `email`, `tieu_de`, `mo_ta`, `yeu_cau`, `quyen_loi`, `ho_so`, `han_nop`, `ngay`, `vi_tri`, `loai`, `trang_thai`, `luot_xem`, `nganh_nghe`, `tinh`) VALUES (NULL, '"+txtTen.Text+"', NULL, '"+txtDiachi.Text+"', '"+txtSDT.Text+"', '"+txtEmail.Text+"', '"+txtTieude.Text+"', '"+txtMota.Text+"', '"+txtYeucau.Text+"', '"+txtQuyenloi.Text+"', '"+String.Empty+"', '"+dates[2]+"-"+dates[1]+"-"+dates[0]+"', curdate(), '0', '1', '0', '0', '"+txtNganhnghe.Text+"', '"+txtTinh.Text+"');");
                string[] careers = txtNganhnghe.Text.Split(',');
                string[] places = txtTinh.Text.Split(',');
                using(var db = new RoboDataEntities())
                {
                    foreach(string str in careers)
                    {
                        career car = db.careers.FirstOrDefault(c => c.Name == str.Trim());
                        if(car !=null)
                        {
                            file.WriteLine("INSERT INTO `td_nn` (`id`, `ma_nn`) select max(id), "+car.Code+" from tuyen_dung;");
                        }
                    }

                    foreach (string str in places)
                    {
                        province pro = db.provinces.FirstOrDefault(p => p.Name == str.Replace("Việc làm", "").Trim());
                        if(pro!=null)
                        {
                            file.WriteLine("INSERT INTO `td_tinh` (`id`, `ma_tinh`) select max(id), "+pro.Code+" from tuyen_dung;");
                        }
                    }
                }
                
                file.Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
