/****************************************************************************
**                              SAKARYA ÜNİVERSİTESİ
**                    BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                          BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                         NESNEYE DAYALI PROGRAMLAMA DERSİ
**                              2021-2022 BAHAR DÖNEMİ
**
**                              ÖDEV NUMARASI:2. ÖDEV
**                              ÖĞRENCİ ADI:SUDE ÖZKANOĞLU
**                              ÖĞRENCİ NUMARASI:G201210034
**                              DERSİN ALINDIĞI GRUP:II. ÖĞRETİM C GRUBU
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Gerekli olan labellarımızı,textboxımızı ve butonumuzu tanımladık
        Label lblTanim1 = new Label();
        Label lblTanim2 = new Label();
        TextBox txtSayi = new TextBox();
        Button btnHesapla = new Button();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Labellarımızın metinlerini oluşturduk,boyutlarını ve formdaki konumlarını belirledik
            lblTanim1.Text = "X";
            lblTanim2.Text = "Y";

            lblTanim1.Width = 50;
            lblTanim1.Location = new Point(200, 90);

            lblTanim2.Width = 50;
            lblTanim2.Location = new Point(200, 130);

            //Textboxımız içinde formdaki konumlarını belirledik ve boyutlarını ayarladık
            txtSayi.Width = 100;
            txtSayi.Height = 30;
            txtSayi.Location = new Point(250, 90);

            //Butonumuzun metnini oluşturduk,konumunu ve boyutunu ayarladık
            btnHesapla.Text = "Hesapla";
            btnHesapla.Width = 100;
            btnHesapla.Location = new Point(250, 170);

            //Butonumuza bastığımız btnHesapla_Click classımızın çalışabilmesi için methodumuzu oluşturduk
            btnHesapla.Click += new EventHandler(btnHesapla_Click);

            //Labelların,textboxun ve butonun ekranda görünmesi için gerekli olan methodları yazdık 
            this.Controls.Add(lblTanim1);
            this.Controls.Add(lblTanim2);
            this.Controls.Add(txtSayi);
            this.Controls.Add(btnHesapla);
        }
        //Butonumuza bastığımızda gerçekleşek olan işlemler için classımızı tanımladık
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //Girilen sayımızın yazıya dönüşen halinin yazılacağı yeni bir label tanımladık,boyutunu ve konumunu ayarladık
            Label lblYazi = new Label();
            lblYazi.Visible = true;
            lblYazi.Width = 10000;
            lblYazi.Location = new Point(250, 130);
            //Grekli olan değişkenlerimizi tanımladık 
            string birler = "";
            string onlar = "";
            string yüzler = "";
            string binler = "";
            string onbinler = "";
            string sifir = "";
            string tamSayi = "";
            string onbinlerTam = "";
            string binlerTam = "";
            string kesirBinler = "";
            string kesirYüzler = "";
            string kesirOnlar = "";
            string kesirBirler = "";
            string kesirSifir = "";
            string kesirKısım = "";
            string onbinlerKesir = "";
            int kesirKısım2 = 0;
            int kontrolDegiskeni = 0;
            int tamKisim = 0;

            string para = txtSayi.Text;

            string sayilar = "1,2,3,4,5,6,7,8,9,0,.";
            //sayilar stringimizin elemanları dışında karakter girilip girilmediğini kontrol etmek için bir for döngüsü oluşturduk
            for (int i = 0; i < para.Length; i++)
            {
                if (sayilar.Contains(para[i]))
                {
                    continue;
                }
                else
                {
                    //Elemanlar dışında bir karakter girildiyse messagebox ile kullanıcıya bir uyarı verdik
                    MessageBox.Show("Hatalı Karakter Girildi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
            }
            //Paramızın index karakterlerini bir char dizisine ToCharArray methodunu kullanara atadık
            char[] karakterler = para.ToCharArray();
            int l = 0;
            //Paramızın doğru bir şekilde lira ve kuruş kısmına ayrılabilmesi için eğer sayımızda varsa noktanın hangi indexte olduğunu bulduk
            for (l = 0; l < para.Length; l++)
            {
                if (karakterler[l] == '.')
                {
                    kontrolDegiskeni = 1;
                    break;
                }
            }
            //Nokta içermeyen paramızın uzunluğunu kontrol ettik
            if (para.Length > 5 && kontrolDegiskeni == 0)
            {
                //Karakter sınırı aşıldığında kullanıcımıza bir hata mesajı verdik
                MessageBox.Show("Karakter Sınırı Aşıldı!", "Hata", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            //Nokta içeren paramızın uzunluğunu kontrol ettik
            if (para.Length > 7 && kontrolDegiskeni == 1)
            {
                //Karakter sınırı aşıldığında kullanıcımıza bir hata mesajı verdik
                MessageBox.Show("Karakter Sınırı Aşıldı!","Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            //Nokta içeren paramız için lira ve kuruş kısımlarını ayırdık
            if (kontrolDegiskeni == 1)
            {
                tamSayi = para.Substring(0, l);
                tamKisim = Convert.ToInt32(tamSayi);
                kesirKısım = para.Substring(l + 1);
                kesirKısım2 = Convert.ToInt32(kesirKısım);
            }
            else
            {
                tamKisim = Convert.ToInt32(para);
            }
            //Nokta bulundurmayan ve 5 haneli olan paramızın değerini metin olarak ekrana yazdırabilmek için gerekli olan if döngümüzü oluşturduk
            if (para.Length == 5 && kontrolDegiskeni == 0)
            {
                //Paramızın on binler ve binler basamaklarını ayırıp switch-case döngümüz ile metinsel ifadelerini oluşturduk
                tamSayi = para.Substring(0, 2);
                tamKisim = Convert.ToInt32(tamSayi);
                
                switch ((tamKisim / 10))
                {
                    case 9: onbinlerTam = ("Doksan "); break;
                    case 8: onbinlerTam = ("Seksen "); break;
                    case 7: onbinlerTam = ("Yetmiş "); break;
                    case 6: onbinlerTam = ("Altmış "); break;
                    case 5: onbinlerTam = ("Elli "); break;
                    case 4: onbinlerTam = ("Kırk "); break;
                    case 3: onbinlerTam = ("Otuz "); break;
                    case 2: onbinlerTam = ("Yirmi "); break;
                    case 1: onbinlerTam = ("On "); break;
                }
                switch ((tamKisim % 10))
                {
                    case 9: binlerTam = ("Dokuz "); break;
                    case 8: binlerTam = ("Sekiz "); break;
                    case 7: binlerTam = ("Yedi "); break;
                    case 6: binlerTam = ("Altı "); break;
                    case 5: binlerTam = ("Beş "); break;
                    case 4: binlerTam = ("Dört "); break;
                    case 3: binlerTam = ("Üç "); break;
                    case 2: binlerTam = ("İki "); break;
                    case 1: binlerTam = ("Bir "); break;
                }
                if (tamKisim == 0)
                {
                    sifir = "Sıfır";
                }
                //Paramızın yüzler,onlar ve birler basamaklarını ayırıp switch-case döngümüz ile metinsel ifadelerini oluşturduk 
                tamSayi = para.Substring(2);
                tamKisim = Convert.ToInt32(tamSayi);

                switch ((tamKisim % 1000) / 100)
                {
                    case 9: yüzler = ("Dokuz Yüz "); break;
                    case 8: yüzler = ("Sekiz Yüz "); break;
                    case 7: yüzler = ("Yedi Yüz "); break;
                    case 6: yüzler = ("Altı Yüz "); break;
                    case 5: yüzler = ("Beş Yüz "); break;
                    case 4: yüzler = ("Dört Yüz "); break;
                    case 3: yüzler = ("Üç Yüz "); break;
                    case 2: yüzler = ("İki Yüz "); break;
                    case 1: yüzler = ("Yüz "); break;
                }
                switch ((tamKisim % 100) / 10)
                {
                    case 9: onlar = ("Doksan "); break;
                    case 8: onlar = ("Seksen "); break;
                    case 7: onlar = ("Yetmiş "); break;
                    case 6: onlar = ("Altmış "); break;
                    case 5: onlar = ("Elli "); break;
                    case 4: onlar = ("Kırk "); break;
                    case 3: onlar = ("Otuz "); break;
                    case 2: onlar = ("Yirmi "); break;
                    case 1: onlar = ("On "); break;
                }
                switch ((tamKisim % 10))
                {
                    case 9: birler = ("Dokuz "); break;
                    case 8: birler = ("Sekiz "); break;
                    case 7: birler = ("Yedi "); break;
                    case 6: birler = ("Altı "); break;
                    case 5: birler = ("Beş "); break;
                    case 4: birler = ("Dört "); break;
                    case 3: birler = ("Üç "); break;
                    case 2: birler = ("İki "); break;
                    case 1: birler = ("Bir "); break;
                }
                //Paramızın miktarını metinsel ifadelerimizi kullanarak ekrana yazdırdık
                lblYazi.Font = new Font(lblYazi.Font, FontStyle.Bold);
                lblYazi.Text = onbinlerTam + binlerTam + sifir + " Bin " + yüzler + onlar + birler + " TL ";
                this.Controls.Add(lblYazi);
            }
            //Paramız 5 basamaktan daha azsa veya 5 basamaktan daha az ve nokta bulunduruyorsa ;
            else
            {
                //5 basamağın altında olan paramızın metinsel ifadelerini elde edebilmek için switch-case döngülerini kullandık
                switch (tamKisim / 1000)
                {
                    case 9: binler = ("Dokuz Bin "); break;
                    case 8: binler = ("Sekiz Bin "); break;
                    case 7: binler = ("Yedi Bin "); break;
                    case 6: binler = ("Altı Bin "); break;
                    case 5: binler = ("Beş Bin "); break;
                    case 4: binler = ("Dört Bin "); break;
                    case 3: binler = ("Üç Bin "); break;
                    case 2: binler = ("İki Bin "); break;
                    case 1: binler = ("Bin "); break;
                }
                switch ((tamKisim % 1000) / 100)
                {
                    case 9: yüzler = ("Dokuz Yüz "); break;
                    case 8: yüzler = ("Sekiz Yüz "); break;
                    case 7: yüzler = ("Yedi Yüz "); break;
                    case 6: yüzler = ("Altı Yüz "); break;
                    case 5: yüzler = ("Beş Yüz "); break;
                    case 4: yüzler = ("Dört Yüz "); break;
                    case 3: yüzler = ("Üç Yüz "); break;
                    case 2: yüzler = ("İki Yüz "); break;
                    case 1: yüzler = ("Yüz "); break;
                }
                switch ((tamKisim % 100) / 10)
                {
                    case 9: onlar = ("Doksan "); break;
                    case 8: onlar = ("Seksen "); break;
                    case 7: onlar = ("Yetmiş "); break;
                    case 6: onlar = ("Altmış "); break;
                    case 5: onlar = ("Elli "); break;
                    case 4: onlar = ("Kırk "); break;
                    case 3: onlar = ("Otuz "); break;
                    case 2: onlar = ("Yirmi "); break;
                    case 1: onlar = ("On "); break;
                }
                switch ((tamKisim % 10))
                {
                    case 9: birler = ("Dokuz "); break;
                    case 8: birler = ("Sekiz "); break;
                    case 7: birler = ("Yedi "); break;
                    case 6: birler = ("Altı "); break;
                    case 5: birler = ("Beş "); break;
                    case 4: birler = ("Dört "); break;
                    case 3: birler = ("Üç "); break;
                    case 2: birler = ("İki "); break;
                    case 1: birler = ("Bir "); break;
                }
                if (tamKisim == 0)
                {
                    sifir = "Sıfır";
                }
                //(ÖZEL DURUM) Paramızın tam kısmı 1 basamaklı ve noktadan sonraki kısmı 5 haneden oluşan bir kesir kısım ise;
                if (tamKisim < 10 && para.Length == 7)
                {
                    //Paramızın kesir kısmının noktadan sonraki ilk iki basamağını ayırdık
                    string birlerTam = "";
                    kesirKısım = para.Substring(2, 2);
                    kesirKısım2 = Convert.ToInt32(kesirKısım);
                    //Paramızın tam kısmını ayırdık
                    tamSayi = para.Substring(0, 1);
                    tamKisim = Convert.ToInt32(tamSayi);
                    //Paramızın doğru bir şekilde metinsel ifadelere dönüşebilmesi için tam ve kesir kısım için gerekli olan switch-case döngülerini oluşturduk
                    switch ((tamKisim))
                    {
                        case 9: birlerTam = ("Dokuz "); break;
                        case 8: birlerTam = ("Sekiz "); break;
                        case 7: birlerTam = ("Yedi "); break;
                        case 6: birlerTam = ("Altı "); break;
                        case 5: birlerTam = ("Beş "); break;
                        case 4: birlerTam = ("Dört "); break;
                        case 3: birlerTam = ("Üç "); break;
                        case 2: birlerTam = ("İki "); break;
                        case 1: birlerTam = ("Bir "); break;
                    }
                    switch ((kesirKısım2 / 10))
                    {
                        case 9: onbinlerTam = ("Doksan "); break;
                        case 8: onbinlerTam = ("Seksen "); break;
                        case 7: onbinlerTam = ("Yetmiş "); break;
                        case 6: onbinlerTam = ("Altmış "); break;
                        case 5: onbinlerTam = ("Elli "); break;
                        case 4: onbinlerTam = ("Kırk "); break;
                        case 3: onbinlerTam = ("Otuz "); break;
                        case 2: onbinlerTam = ("Yirmi "); break;
                        case 1: onbinlerTam = ("On "); break;
                    }
                    switch ((kesirKısım2 % 10))
                    {
                        case 9: binlerTam = ("Dokuz "); break;
                        case 8: binlerTam = ("Sekiz "); break;
                        case 7: binlerTam = ("Yedi "); break;
                        case 6: binlerTam = ("Altı "); break;
                        case 5: binlerTam = ("Beş "); break;
                        case 4: binlerTam = ("Dört "); break;
                        case 3: binlerTam = ("Üç "); break;
                        case 2: binlerTam = ("İki "); break;
                        case 1: binlerTam = ("Bir "); break;
                    }
                    if (kesirKısım2 == 0)
                    {
                        sifir = "Sıfır";
                    }
                    //Paramızın kesir kısmında kalan son üç basamağını elde ettik
                    kesirKısım = para.Substring(2);
                    kesirKısım2 = Convert.ToInt32(kesirKısım);
                    //Kesir kısmında kalan son üç basamağı metinsel ifadelere dönüştüreceğimiz döngülerimizi oluşturduk
                    switch ((kesirKısım2 % 1000) / 100)
                    {
                        case 9: yüzler = ("Dokuz Yüz "); break;
                        case 8: yüzler = ("Sekiz Yüz "); break;
                        case 7: yüzler = ("Yedi Yüz "); break;
                        case 6: yüzler = ("Altı Yüz "); break;
                        case 5: yüzler = ("Beş Yüz "); break;
                        case 4: yüzler = ("Dört Yüz "); break;
                        case 3: yüzler = ("Üç Yüz "); break;
                        case 2: yüzler = ("İki Yüz "); break;
                        case 1: yüzler = ("Yüz "); break;
                    }
                    switch ((kesirKısım2 % 100) / 10)
                    {
                        case 9: onlar = ("Doksan "); break;
                        case 8: onlar = ("Seksen "); break;
                        case 7: onlar = ("Yetmiş "); break;
                        case 6: onlar = ("Altmış "); break;
                        case 5: onlar = ("Elli "); break;
                        case 4: onlar = ("Kırk "); break;
                        case 3: onlar = ("Otuz "); break;
                        case 2: onlar = ("Yirmi "); break;
                        case 1: onlar = ("On "); break;
                    }
                    switch ((kesirKısım2 % 10))
                    {
                        case 9: birler = ("Dokuz "); break;
                        case 8: birler = ("Sekiz "); break;
                        case 7: birler = ("Yedi "); break;
                        case 6: birler = ("Altı "); break;
                        case 5: birler = ("Beş "); break;
                        case 4: birler = ("Dört "); break;
                        case 3: birler = ("Üç "); break;
                        case 2: birler = ("İki "); break;
                        case 1: birler = ("Bir "); break;
                    }
                    //Metinsel ifadelerimizi kullanarak paramızı metinsel biçimde ekrana yazdırdık
                    lblYazi.Font = new Font(lblYazi.Font, FontStyle.Bold);
                    lblYazi.Text = birlerTam + " TL " + onbinlerTam + binlerTam + sifir + " Bin " + yüzler + onlar + birler + " Kuruş ";
                    this.Controls.Add(lblYazi);
                }
                //Özel durum dışında kalan paramızın kesir kısmı için çalışacak olan else ifademizi tanımladık
                else
                {
                    //Kesir kısmımızın metinsel ifadelerini elde edebilmek için döngülerimizi oluşturduk
                    switch (kesirKısım2 / 1000)
                    {
                        case 9: kesirBinler = ("Dokuz Bin "); break;
                        case 8: kesirBinler = ("Sekiz Bin "); break;
                        case 7: kesirBinler = ("Yedi Bin "); break;
                        case 6: kesirBinler = ("Altı Bin "); break;
                        case 5: kesirBinler = ("Beş Bin "); break;
                        case 4: kesirBinler = ("Dört Bin "); break;
                        case 3: kesirBinler = ("Üç Bin "); break;
                        case 2: kesirBinler = ("İki Bin "); break;
                        case 1: kesirBinler = ("Bin "); break;
                    }
                    switch ((kesirKısım2 % 1000) / 100)
                    {
                        case 9: kesirYüzler = ("Dokuz Yüz "); break;
                        case 8: kesirYüzler = ("Sekiz Yüz "); break;
                        case 7: kesirYüzler = ("Yedi Yüz "); break;
                        case 6: kesirYüzler = ("Altı Yüz "); break;
                        case 5: kesirYüzler = ("Beş Yüz "); break;
                        case 4: kesirYüzler = ("Dört Yüz "); break;
                        case 3: kesirYüzler = ("Üç Yüz "); break;
                        case 2: kesirYüzler = ("İki Yüz "); break;
                        case 1: kesirYüzler = ("Yüz "); break;
                    }
                    switch ((kesirKısım2 % 100) / 10)
                    {
                        case 9: kesirOnlar = ("Doksan "); break;
                        case 8: kesirOnlar = ("Seksen "); break;
                        case 7: kesirOnlar = ("Yetmiş "); break;
                        case 6: kesirOnlar = ("Altmış "); break;
                        case 5: kesirOnlar = ("Elli "); break;
                        case 4: kesirOnlar = ("Kırk "); break;
                        case 3: kesirOnlar = ("Otuz "); break;
                        case 2: kesirOnlar = ("Yirmi "); break;
                        case 1: kesirOnlar = ("On "); break;
                    }
                    switch ((kesirKısım2 % 10))
                    {
                        case 9: kesirBirler = ("Dokuz "); break;
                        case 8: kesirBirler = ("Sekiz "); break;
                        case 7: kesirBirler = ("Yedi "); break;
                        case 6: kesirBirler = ("Altı "); break;
                        case 5: kesirBirler = ("Beş "); break;
                        case 4: kesirBirler = ("Dört "); break;
                        case 3: kesirBirler = ("Üç "); break;
                        case 2: kesirBirler = ("İki "); break;
                        case 1: kesirBirler = ("Bir "); break;
                    }
                    if (kesirKısım2 == 0)
                    {
                        kesirSifir = "Sıfır";
                    }
                    //Elde ettiğimiz metinsel ifadeleri kullanarak paramızın metin halini ekrana yazdırdık
                    lblYazi.Font = new Font(lblYazi.Font, FontStyle.Bold);
                    lblYazi.Text = onbinler + binler + yüzler + onlar + birler + sifir + " TL " + kesirBinler + kesirYüzler + kesirOnlar + kesirBirler + kesirSifir + " Kuruş ";
                    this.Controls.Add(lblYazi);
                }
            }
        }
    }
}

