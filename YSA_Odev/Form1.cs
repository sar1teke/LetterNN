using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace YSA_Odev
{
    public partial class Form1 : Form
    {
        private const int SATIRLAR = 7;
        private const int SUTUNLAR = 5;
        private const int HUCRE_BOYUTU = 50;
        private bool[,] matrisDurumu = new bool[SATIRLAR, SUTUNLAR];
        private YapaySinirAgi ysa;
        private int[] girisVektoru = new int[35];
        private int[,] istenenCikti = new int[5, 5]
        {
            {1, 0, 0, 0, 0},  // A
            {0, 1, 0, 0, 0},  // B
            {0, 0, 1, 0, 0},  // C
            {0, 0, 0, 1, 0},  // D
            {0, 0, 0, 0, 1}   // E
        };
        private double epsilon = 0.1;  // Epsilon değeri

        public Form1()
        {
            InitializeComponent();
            MatrisiBaslat();
            Panel1.MouseClick += Panel1_MouseClick;
            Panel1.Paint += Panel1_Paint;
            PaneliAyarla();

            // Butonlara olay yöneticileri ekle
            button_Temizle.Click += button_Temizle_Click;
            button_CizgiKaldir.Click += button_CizgiKaldir_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Uygulama başlatıldığında yapılacak işlemler
        }
        private void MatrisiBaslat()
        {
            for (int i = 0; i < SATIRLAR; i++)
            {
                for (int j = 0; j < SUTUNLAR; j++)
                {
                    matrisDurumu[i, j] = false;  // Matrisi başlangıçta beyaz (false) olarak ayarla
                }
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Çizgileri ve doldurulacak hücreleri çizmek için döngü
            for (int i = 0; i < SATIRLAR; i++)
            {
                for (int j = 0; j < SUTUNLAR; j++)
                {
                    Pen kalem = Pens.Gray;
                    // Dikdörtgenin dört kenarını çiz
                    g.DrawLine(kalem, j * HUCRE_BOYUTU, i * HUCRE_BOYUTU, j * HUCRE_BOYUTU, (i + 1) * HUCRE_BOYUTU);
                    g.DrawLine(kalem, j * HUCRE_BOYUTU, i * HUCRE_BOYUTU, (j + 1) * HUCRE_BOYUTU, i * HUCRE_BOYUTU);
                    g.DrawLine(kalem, (j + 1) * HUCRE_BOYUTU, i * HUCRE_BOYUTU, (j + 1) * HUCRE_BOYUTU, (i + 1) * HUCRE_BOYUTU);
                    g.DrawLine(kalem, j * HUCRE_BOYUTU, (i + 1) * HUCRE_BOYUTU, (j + 1) * HUCRE_BOYUTU, (i + 1) * HUCRE_BOYUTU);

                    // Hücrenin içini doldur
                    Brush firca = matrisDurumu[i, j] ? Brushes.Black : Brushes.White;
                    g.FillRectangle(firca, j * HUCRE_BOYUTU + 1, i * HUCRE_BOYUTU + 1, HUCRE_BOYUTU - 1, HUCRE_BOYUTU - 1);
                }
            }
        }
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int sutun = e.X / HUCRE_BOYUTU;
            int satir = e.Y / HUCRE_BOYUTU;
            matrisDurumu[satir, sutun] = !matrisDurumu[satir, sutun];
            Panel1.Invalidate(); // Paneli yeniden çizmek için
        }
        private void PaneliAyarla()
        {
            int index = 0;
            foreach (Control ctrl in Panel1.Controls)
            {
                if (ctrl is Button dugme)
                {
                    dugme.Click += (sender, e) =>
                    {
                        Button tiklananDugme = sender as Button;
                        if (tiklananDugme.BackColor == Color.White)
                        {
                            tiklananDugme.BackColor = Color.Black;
                            girisVektoru[index] = 1;
                        }
                        else
                        {
                            tiklananDugme.BackColor = Color.White;
                            girisVektoru[index] = 0;
                        }
                        index++;
                    };
                }
            }
        }
        private void MatristenGirisVektorunuGuncelle()
        {
            int index = 0;
            for (int i = 0; i < SATIRLAR; i++)
            {
                for (int j = 0; j < SUTUNLAR; j++)
                {
                    girisVektoru[index++] = matrisDurumu[i, j] ? 1 : 0;
                }
            }
        }

        private void HataEtiketiniGuncelle(string hataMesaji)
        {
            if (label3.InvokeRequired)
            {
                label3.Invoke(new Action<string>((s) => { label3.Text = s; }), hataMesaji);
            }
            else
            {
                label3.Text = hataMesaji;
            }
        }

        
        private void DosyayaAgirliklariKaydet(string dosyaYolu, List<double> agirliklar)
        {
            using (StreamWriter sw = new StreamWriter(dosyaYolu, false)) // Dosyanın üzerine yaz
            {
                foreach (var agirlik in agirliklar)
                {
                    sw.WriteLine(agirlik.ToString("F6")); // 6 basamaklı ondalık olarak formatla
                }
            }
        }
        private void button_Egit_Click_1(object sender, EventArgs e)
        {
            // Yapay sinir ağını başlat
            ysa = new YapaySinirAgi(35, 15, 5);  // Buradaki parametreler örnek amaçlıdır.
            ysa.Epsilon = 0.1;  // Sabit bir epsilon değeri

            // Eğitim başlat
            // EğitimVerisi.Data ve istenenCikti gibi daha önce tanımlanmış olmalıdır
            ysa.Egit(EgitimVerisi.Veriler, istenenCikti, 1000, this);

            MessageBox.Show("Eğitim tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button_Tanimla_Click_1(object sender, EventArgs e)
        {
            if (ysa == null)
            {
                MessageBox.Show("Model henüz eğitilmedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MatristenGirisVektorunuGuncelle();
            var tahminSonuclari = ysa.TahminEt(girisVektoru);
            double[] ciktilar = tahminSonuclari.ciktilar; // Güncellenmiş kullanım
            richTextBox1.Clear();
            richTextBox1.AppendText("Tahmin Sonuçları:\n");

            char[] harfler = { 'A', 'B', 'C', 'D', 'E' };

            // En yüksek benzerlik değerini bulma
            double enYuksekBenzerlik = ciktilar.Max();
            int enYuksekIndeks = Array.IndexOf(ciktilar, enYuksekBenzerlik); // En yüksek değere sahip indeksi bul

            // Tüm harfler için benzerlik oranlarını yazdır
            for (int i = 0; i < ciktilar.Length; i++)
            {
                richTextBox1.AppendText($"{harfler[i]} çıkışı = {ciktilar[i]:G10}\n");
            }

            // En yüksek benzerlik oranına sahip harfi vurgula
            richTextBox1.AppendText($"\nÇizim, {ciktilar[enYuksekIndeks]:G10} değeriyle '{harfler[enYuksekIndeks]}' harfine en çok benziyor.\n");
        }

        private void button_Temizle_Click(object sender, EventArgs e)
        {
            // RichTextBox'ı temizle
            richTextBox1.Clear();

            // Panel üzerindeki tüm çizimleri temizle
            for (int i = 0; i < SATIRLAR; i++)
            {
                for (int j = 0; j < SUTUNLAR; j++)
                {
                    matrisDurumu[i, j] = false;
                }
            }

            // Paneli yeniden çizmek için
            Panel1.Invalidate();
        }

        private void button_CizgiKaldir_Click(object sender, EventArgs e)
        {
            // Panel üzerindeki tüm çizgileri (matrisi) temizle
            for (int i = 0; i < SATIRLAR; i++)
            {
                for (int j = 0; j < SUTUNLAR; j++)
                {
                    matrisDurumu[i, j] = false;
                }
            }
            // Paneli yeniden çizmek için
            Panel1.Invalidate();
        }

        private void buttonEpsilonGuncelle_Click(object sender, EventArgs e)
        {
            if (ysa == null)
            {
                ysa = new YapaySinirAgi(35, 15, 5);  // Varsayılan bir epsilon değeri ile başlatın
            }

            if (double.TryParse(textBoxEpsilon.Text, out double yeniEpsilon))
            {
                ysa.Epsilon = yeniEpsilon;
                MessageBox.Show($"Epsilon değeri kabul edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class EgitimVerisi
        {
            public static int[,,] Veriler = new int[5, 7, 5]
            {
            {
                {0,0,1,0,0},
                {0,1,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,1},
                {1,0,0,0,1},
                {1,0,0,0,1}
            },
            {
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0}
            },
            {
                {0,0,1,1,1},
                {0,1,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {0,1,0,0,0},
                {0,0,1,1,1}
            },
            {
                {1,1,1,0,0},
                {1,0,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,1,0},
                {1,1,1,0,0}
            },
            {
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1}
            }
            };
        }

        public class YapaySinirAgi
        {
            private int girisNöronlari;
            private int gizliNöronlar;
            private int cikisNöronlari;
            private double[,] agirliklarGirisGizli;
            private double[,] agirliklarGizliCikis;
            private double ogrenmeOrani = 0.1;
            private double epsilon;

            public void AgirliklariKaydet(string dosyaYolu)
            {
                using (StreamWriter sw = new StreamWriter(dosyaYolu, false))
                {
                    sw.WriteLine("Input-Hidden Weights:");
                    for (int i = 0; i < agirliklarGirisGizli.GetLength(0); i++)
                    {
                        for (int j = 0; j < agirliklarGirisGizli.GetLength(1); j++)
                        {
                            sw.Write(agirliklarGirisGizli[i, j] + " ");
                        }
                        sw.WriteLine();
                    }

                    sw.WriteLine("Hidden-Output Weights:");
                    for (int i = 0; i < agirliklarGizliCikis.GetLength(0); i++)
                    {
                        for (int j = 0; j < agirliklarGizliCikis.GetLength(1); j++)
                        {
                            sw.Write(agirliklarGizliCikis[i, j] + " ");
                        }
                        sw.WriteLine();
                    }
                }
            }
            public List<double> GuncelAgirliklariAl()
            {
                List<double> guncelAgirliklar = new List<double>();
                // Örnek olarak giriş-gizli katman ağırlıklarını ekleyelim
                for (int i = 0; i < agirliklarGirisGizli.GetLength(0); i++)
                {
                    for (int j = 0; j < agirliklarGizliCikis.GetLength(1); j++)
                    {
                        guncelAgirliklar.Add(agirliklarGirisGizli[i, j]);
                    }
                }
                // Gizli-çıktı katmanı ağırlıklarını ekleyelim
                for (int i = 0; i < agirliklarGizliCikis.GetLength(0); i++)
                {
                    for (int j = 0; j < agirliklarGizliCikis.GetLength(1); j++)
                    {
                        guncelAgirliklar.Add(agirliklarGizliCikis[i, j]);
                    }
                }
                return guncelAgirliklar;
            }

            public double Epsilon
            {
                get { return epsilon; }
                set { epsilon = value; }
            }
            public YapaySinirAgi(int girisNöronlari, int gizliNöronlar, int cikisNöronlari)
            {
                this.girisNöronlari = girisNöronlari;
                this.gizliNöronlar = gizliNöronlar;
                this.cikisNöronlari = cikisNöronlari;
                this.epsilon = epsilon;
                AgirliklariBaslat();
            }

            private void AgirliklariBaslat()
            {
                agirliklarGirisGizli = new double[girisNöronlari, gizliNöronlar];
                agirliklarGizliCikis = new double[gizliNöronlar, cikisNöronlari];
                Random rnd = new Random();
                for (int i = 0; i < girisNöronlari; i++)
                    for (int j = 0; j < gizliNöronlar; j++)
                        agirliklarGirisGizli[i, j] = rnd.NextDouble() - 0.5;

                for (int i = 0; i < gizliNöronlar; i++)
                    for (int j = 0; j < cikisNöronlari; j++)
                        agirliklarGizliCikis[i, j] = rnd.NextDouble() - 0.5;
            }

            delegate void EtiketGuncelleCallback(string metin);
            public void Egit(int[,,] egitimVerisi, int[,] hedefCiktilar, int donemSayisi, Form1 formOrnegi)
            {
                for (int donem = 0; donem < donemSayisi; donem++)
                {
                    double toplamHata = 0;
                    for (int ornek = 0; ornek < egitimVerisi.GetLength(0); ornek++)
                    {
                        int[] giris = new int[girisNöronlari];
                        int index = 0;
                        for (int i = 0; i < egitimVerisi.GetLength(1); i++)
                        {
                            for (int j = 0; j < egitimVerisi.GetLength(2); j++)
                            {
                                giris[index++] = egitimVerisi[ornek, i, j];
                            }
                        }

                        var (ciktilar, gizliCiktilar) = TahminEt(giris);
                        double[] ciktiHatalari = new double[cikisNöronlari];

                        for (int i = 0; i < cikisNöronlari; i++)
                        {
                            double hata = hedefCiktilar[ornek, i] - ciktilar[i];
                            ciktiHatalari[i] = hata;
                            toplamHata += Math.Abs(hata);
                        }

                        AgirliklariGuncelle(giris, gizliCiktilar, ciktiHatalari);
                    }

                    double ortalamaHata = toplamHata / (egitimVerisi.GetLength(0) * cikisNöronlari);
                    formOrnegi.HataEtiketiniGuncelle(ortalamaHata.ToString());
                    if (ortalamaHata < epsilon)
                    {
                        MessageBox.Show($"Eğitim, {donem + 1} dönem sonunda durduruldu. Ortalama hata: {ortalamaHata}", "Eğitim Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                string dosyaYolu = "C:\\Users\\srtk\\source\\repos\\YSA_Odev\\agirliklar.txt";
                AgirliklariKaydet(dosyaYolu);
            }
            private void AgirliklariGuncelle(int[] girisler, double[] gizliCiktilar, double[] ciktiHatalari)
            {
                // Gizli katmandan çıktı katmanına ağırlıkları güncelle
                for (int i = 0; i < gizliNöronlar; i++)
                {
                    for (int j = 0; j < cikisNöronlari; j++)
                    {
                        agirliklarGizliCikis[i, j] += ogrenmeOrani * ciktiHatalari[j] * gizliCiktilar[i];
                    }
                }

                // Giriş katmandan gizli katmana ağırlıkları güncelle
                for (int i = 0; i < girisNöronlari; i++)
                {
                    for (int j = 0; j < gizliNöronlar; j++)
                    {
                        // Gizli katman hatalarını hesapla ve kullan
                        double gizliHata = 0;
                        for (int k = 0; k < cikisNöronlari; k++)
                        {
                            gizliHata += ciktiHatalari[k] * agirliklarGizliCikis[j, k];
                        }
                        gizliHata *= TureviSigmoid(gizliCiktilar[j]);
                        agirliklarGirisGizli[i, j] += ogrenmeOrani * gizliHata * girisler[i];
                    }
                }
            }
            private double Sigmoid(double x)
            {
                return 1.0 / (1 + Math.Exp(-x));
            }
            private double TureviSigmoid(double x)
            {
                double sig = Sigmoid(x);
                return sig * (1 - sig);
            }
            public (double[] ciktilar, double[] gizliCiktilar) TahminEt(int[] giris)
            {
                double[] gizliKatmanCiktilari = new double[gizliNöronlar];
                for (int i = 0; i < gizliNöronlar; i++)
                {
                    gizliKatmanCiktilari[i] = 0;
                    for (int j = 0; j < girisNöronlari; j++)
                        gizliKatmanCiktilari[i] += giris[j] * agirliklarGirisGizli[j, i];
                    gizliKatmanCiktilari[i] = Sigmoid(gizliKatmanCiktilari[i]);
                }

                double[] ciktiKatmanCiktilari = new double[cikisNöronlari];
                for (int i = 0; i < cikisNöronlari; i++)
                {
                    ciktiKatmanCiktilari[i] = 0;
                    for (int j = 0; j < gizliNöronlar; j++)
                        ciktiKatmanCiktilari[i] += gizliKatmanCiktilari[j] * agirliklarGizliCikis[j, i];
                    ciktiKatmanCiktilari[i] = Sigmoid(ciktiKatmanCiktilari[i]);
                }

                return (ciktiKatmanCiktilari, gizliKatmanCiktilari);
            }
        }
        private void buttonUpdateEpsilon_Click(object sender, EventArgs e)
        {
            
            // textBoxEpsilon'den alınan metni double olarak ayrıştırma
            if (double.TryParse(textBoxEpsilon.Text, out double newEpsilon))
            {
                // Yeni epsilon değerini yapay sinir ağına atama
                if (ysa != null)  // ysa, YapaySinirAgi tipinde bir örnektir
                {
                    ysa.Epsilon = newEpsilon;
                    MessageBox.Show($"Epsilon değeri {newEpsilon} olarak güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxEpsilon.Text = "";
                }
                else
                {
                    MessageBox.Show("Yapay sinir ağı henüz başlatılmamış. Lütfen önce eğitim yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Girilen değer uygun bir sayısal format değilse hata mesajı göster
                MessageBox.Show("Lütfen geçerli bir sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
