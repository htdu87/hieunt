using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBot
{
    public partial class frmMain : Form
    {
        private System.Windows.Forms.Timer timer;
        private Thread thread;

        private void Action()
        {
            int count = 0;
            using (var db = new hieunt_tdEntities())
            {
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = 0;
                    btnStart.Enabled = btnStartHide.Enabled = btnSaveStart.Enabled = false;
                    progressBar1.Maximum = db.provinces.Count();
                });
                
                //List<province> lsProvince = db.provinces.OrderBy(a=>a.IdPro).Skip(0).Take(2).ToList();
                List<province> lsProvince = db.provinces.ToList();
                foreach (province p in lsProvince)
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument document = web.Load(p.Url);
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

                        if (db.recruitments.FirstOrDefault(r => r.Code == code) == null)
                        {
                            recruitment rec = new recruitment();
                            rec.Code = code;
                            rec.Position = position;
                            rec.Salary = salary;
                            rec.Place = place;
                            rec.Expiry = expiry;
                            rec.Url = href;
                            rec.Saved = false;
                            rec.Rodate = DateTime.Now;
                            db.recruitments.Add(rec);
                            db.SaveChanges();

                            //insert to database
                            count += Save(href, db, code);
                        }
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Value++;
                    });
                }
            }

            Invoke((MethodInvoker)delegate
            {
                btnStart.Enabled = btnStartHide.Enabled = btnSaveStart.Enabled = true;
                progressBar1.Value = 0;
                if (count > 0)
                {
                    notifyIcon1.BalloonTipTitle = "Auto Bot";
                    notifyIcon1.BalloonTipText = "Auto Bot has been inserted " + count + " new record";
                    notifyIcon1.ShowBalloonTip(2000);
                }
            });
        }

        private int Save(String url, hieunt_tdEntities db, string code)
        {
            int count = 0;
            Debug.WriteLine("Processing: " + url);
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);
            
            try
            {
                string ten = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/h3").InnerText.Trim();
                string diachi = document.DocumentNode.SelectSingleNode("//article[contains(@class, 'block-content')]/div[2]/span").InnerText.Replace("Địa chỉ:", "").Trim();
                string tieude = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'text-primary')]/span").InnerText.Trim();
                string tinh = String.Empty;
                foreach (HtmlNode node in document.DocumentNode.SelectNodes("//article[contains(@class, 'block-content')]/div[5]/div/ul/li[4]/a"))
                {
                    tinh += " " + node.InnerText.Replace("Việc làm ", "") + ",";
                }
                tinh = tinh.TrimStart().Trim(',');

                string nnghe = String.Empty;
                foreach (HtmlNode node in document.DocumentNode.SelectNodes("//article[contains(@class, 'block-content')]/div[5]/div/ul/li[5]/a"))
                {
                    nnghe += " " + node.InnerText + ",";
                }
                nnghe = nnghe.TrimStart().Trim(',');

                string mota = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[1]/td[2]").InnerText.Trim();
                string yeucau = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[2]/td[2]").InnerText.Trim();
                string quyenloi = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[3]/td[2]").InnerText.Trim();
                var nHannop = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[4]/td[2]/b");
                string hannop = String.Empty;
                if (nHannop == null)
                    hannop = document.DocumentNode.SelectSingleNode("//article/table[1]/tbody/tr[5]/td[2]").InnerText.Trim();
                else
                    hannop = nHannop.InnerText.Trim();
                    
                string nophs = "<div><a target=\"_blank\" href=\"https://www.timviecnhanh.com/nguoi-tim-viec/ung-tuyen-cong-viec-new?id=" + code + "\">Nộp hồ sơ tại đây</a></div>";

                string email = String.Empty;
                var nodeEmail = document.DocumentNode.SelectSingleNode("//article/div[contains(@class, 'block-info-company')]/div/table/tr[3]/td[2]/p");
                if (nodeEmail != null)
                    email = nodeEmail.InnerText.Trim();

                string phone = String.Empty;
                var nodePhone = document.DocumentNode.SelectSingleNode("//article/div[contains(@class, 'block-info-company')]/div/table/tr[4]/td[2]/p");
                if (nodePhone != null)
                    phone = nodePhone.InnerText.Trim();

                string[] dates = hannop.Split('-');
                db.Database.ExecuteSqlCommand("INSERT INTO `tuyen_dung` (`id`, `ten`, `logo`, `dia_chi`, `dien_thoai`, `email`, `tieu_de`, `mo_ta`, `yeu_cau`, `quyen_loi`, `ho_so`, `han_nop`, `ngay`, `vi_tri`, `loai`, `trang_thai`, `luot_xem`, `nganh_nghe`, `tinh`) VALUES (NULL, '" + ten + "', NULL, '" + diachi + "', '" + phone + "', '" + email + "', '" + tieude + "', '" + mota + "', '" + yeucau + "', '" + quyenloi + "', '" + hannop + "', '" + dates[2] + "-" + dates[1] + "-" + dates[0] + "', now(), '0', '1', '0', '0', '" + nnghe + "', '" + tinh + "');");
                string[] careers = nnghe.Split(',');
                string[] places = tinh.Split(',');
                    
                foreach (string str in careers)
                {
                    career car = db.careers.FirstOrDefault(c => c.Name == str.Trim());
                    if (car != null)
                    {
                        db.Database.ExecuteSqlCommand("INSERT INTO `td_nn` (`id`, `ma_nn`) select max(id), " + car.Code + " from tuyen_dung;");
                    }
                }

                foreach (string str in places)
                {
                    province pro = db.provinces.FirstOrDefault(p => p.Name == str.Replace("Việc làm", "").Trim());
                    if (pro != null)
                    {
                        db.Database.ExecuteSqlCommand("INSERT INTO `td_tinh` (`id`, `ma_tinh`) select max(id), " + pro.Code + " from tuyen_dung;");
                    }
                }

                count++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: "+ex.Message);
            }
            return count;
        }

        private void BuildTrayApp()
        {
            notifyIcon1.BalloonTipTitle = "Auto Bot";
            notifyIcon1.BalloonTipText = "I'm still running here!";
            notifyIcon1.ShowBalloonTip(3000);
            this.Hide();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblInterval.Text = trackBar1.Value.ToString();
        }

        private void btnSaveStart_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ref_interval"].Value = trackBar1.Value.ToString();
            config.Save();

            timer.Start();
            new Thread(() => Action()).Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            thread =  new Thread(() => Action());
            thread.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string interval=ConfigurationManager.AppSettings["ref_interval"];
            int intInterval=Convert.ToInt32(interval);
            lblInterval.Text = interval;
            trackBar1.Value = intInterval;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = intInterval*60*1000;
            //timer.Interval = 60*1000;
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Tick");
            thread = new Thread(() => Action());
            thread.Start();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            BuildTrayApp();
        }

        private void btnStartHide_Click(object sender, EventArgs e)
        {
            timer.Start();
            thread = new Thread(() => Action());
            thread.Start();
            BuildTrayApp();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread!=null&&thread.IsAlive)
            {
                thread.Abort();
            }
        }
    }
}
