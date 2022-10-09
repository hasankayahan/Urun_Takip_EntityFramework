using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbUrunEntities db = new DbUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TblMüsteri.ToList();
            var degerler = from x in db.TblMüsteri select new
            {
                x.MüsteriID,
                x.Ad,
                x.Soyad,
                x.Sehir,
                x.Bakiye
               
            };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblMüsteri t = new TblMüsteri();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Sehir = TxtSehir.Text;
            t.Bakiye = decimal.Parse(TxtBakiye.Text);
            db.TblMüsteri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kaydetme İşlemi Başarılı");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblMüsteri.Find(id);
            db.TblMüsteri.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblMüsteri.Find(id);
            x.Ad = TxtAd.Text;
            x.Soyad = TxtSoyad.Text;
            x.Sehir = TxtSehir.Text;
            x.Bakiye=decimal.Parse(TxtBakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
