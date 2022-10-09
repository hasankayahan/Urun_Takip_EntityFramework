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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities db = new DbUrunEntities();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            LblMusteriSayisi.Text = db.TblMüsteri.Count().ToString();
            LblKategoriSayisi.Text = db.TblKategori.Count().ToString();
            LblUrunSayisi.Text = db.TblUrunler.Count().ToString();
            LblBeyazEsyaSayisi.Text = db.TblUrunler.Count(x=>x.Kategori==1).ToString();
            LblToplamStokSayisi.Text=db.TblUrunler.Sum(x=>x.Stok).ToString();
            LblBugunSatısAdedi.Text = db.TblSatislar.Count(x => x.Tarih == bugun).ToString();
            LblToplamKasa.Text = db.TblSatislar.Sum(x => x.Toplam).ToString() + "₺";
            LblBugunKasaTutarı.Text=db.TblSatislar.Where(x=>x.Tarih==bugun).Sum(y=>y.Toplam).ToString() + "₺";
            LblEnYuksekUrun.Text = (from x in db.TblUrunler
                                           orderby x.SatisFiyat descending
                                           select x.UrunAd).FirstOrDefault();
            LblEnDusukFiyatUrun.Text = (from x in db.TblUrunler
                                        orderby x.SatisFiyat ascending
                                        select x.UrunAd).FirstOrDefault();
            LblEnfazlaStokUrun.Text = (from x in db.TblUrunler
                                    orderby x.Stok descending
                                    select x.UrunAd).FirstOrDefault();
            LblEnazStokUrun.Text = (from x in db.TblUrunler
                                    orderby x.Stok ascending
                                    select x.UrunAd).FirstOrDefault();
        }
    }
}
