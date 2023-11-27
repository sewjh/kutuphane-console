using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kullanicilar = new Dictionary<string, string>();
            var gorevliler = new Dictionary<string, string>();

            ArrayList kitaplik = new ArrayList();

            string cevap, eklenecek, silinecek, terfi, tenzil;
            string terfiKey = "default";
            string terfiValue = "default";
            string tenzilKey = "default";
            string tenzilValue = "default";
            bool terfiyeUygun = false;
            bool tenzileUygun = false;

            string kadi, parola;
            string hesap = "-";
            string giris = "-";
            int girisHakki = 3;

            string yoneticiKadi = "Asdf1234";
            string yoneticiParola = "123456";

            while (true)
            {
                if (giris == "-")
                {
                    Console.WriteLine("Giris yapmak istediğiniz profili seçiniz.\n(yonetici, kullanıcı, gorevli)\nKayıt olmak için 'kayit' yaziniz.");
                    giris = Console.ReadLine();
                }

                if (giris == "yonetici")
                {
                    Console.WriteLine("Önce kullanıcı adı, sonra parola giriniz.");
                    kadi = Console.ReadLine();
                    parola = Console.ReadLine();
                    if (kadi == yoneticiKadi && parola == yoneticiParola)
                    {
                        hesap = "yonetici";
                        Console.WriteLine("Kullanıcı adı ve parola doğru, yönetici girişi yapılıyor.");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }
                    else
                    {
                        girisHakki--;
                        Console.WriteLine("Kullanıcı adı veya parola yanlış. Kalan deneme hakkınız: {0}", girisHakki);
                        if (girisHakki == 0)
                        {
                            Console.WriteLine("3 defa yanlış deneme yaptınız, çıkış yapılıyor.");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                    }
                }
                else if (giris == "kayit")
                {
                    Console.WriteLine("Kullanıcı adı giriniz.");
                    kadi = Console.ReadLine();
                    Console.WriteLine("Parola giriniz.");
                    parola = Console.ReadLine();
                    Console.WriteLine("Hesap oluşturuluyor, lütfen bekleyin.");
                    System.Threading.Thread.Sleep(1500);
                    kullanicilar.Add(parola, kadi);
                    Console.WriteLine("Hesap oluşturma başarılı, lütfen giriş yapın");
                    System.Threading.Thread.Sleep(1000);
                    giris = "-";
                }
                else if (giris == "kullanıcı")
                {
                    Console.WriteLine("Önce kullanıcı adı, sonra parola giriniz.");
                    kadi = Console.ReadLine();
                    parola = Console.ReadLine();
                    foreach (KeyValuePair<string, string> kullanici in kullanicilar)
                    {
                        if (kullanici.Key == parola && kullanici.Value == kadi)
                        {
                            hesap = "kullanıcı";
                            Console.WriteLine("Kullanıcı adı ve parola doğru, giriş yapılıyor.");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            girisHakki--;
                            Console.WriteLine("Kullanıcı adı veya parola yanlış. Kalan deneme hakkınız: {0}", girisHakki);
                            if (girisHakki == 0)
                            {
                                Console.WriteLine("3 defa yanlış deneme yaptınız, çıkış yapılıyor.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                        }
                    }
                    if (girisHakki == 0)
                    {
                        break;
                    }
                    else if (hesap != "-")
                    {
                        break;
                    }
                }
            }

            if (hesap != "-")
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(750);
                    Console.WriteLine("");
                    Console.WriteLine("Yapmak istediğiniz işlemi seçiniz. \n" +
                        "*----KULLANICI---- \n" +
                        "1-Kitapları gör \n" +
                        "*----GÖREVLİ---- \n" +
                        "2-Kitap ekle \n" +
                        "3-Kitap sil \n" +
                        "*----YÖNETİCİ---- \n" +
                        "4-Görevli ekle \n" +
                        "5-Görevli çıkar \n" +
                        "6-Görevli listesi \n" +
                        "7-Kullanıcı listesi \n" +
                        "q-Çıkış");

                    cevap = Convert.ToString(Console.ReadLine());
                    System.Threading.Thread.Sleep(1000);

                    if (cevap == "2" && (hesap == "yonetici" || hesap == "gorevli"))
                    {
                        Console.WriteLine("Eklemek istediğiniz kitabın adını giriniz:");
                        eklenecek = Convert.ToString(Console.ReadLine());
                        kitaplik.Add(eklenecek);
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(eklenecek + " adlı kitap kütüphaneye eklendi.");
                    }
                    else if (cevap == "2" && hesap == "kullanıcı")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else if (cevap == "3" && (hesap == "yonetici" || hesap == "gorevli"))
                    {
                        Console.WriteLine("Kütüphanedeki kitaplar:");
                        foreach (string k in kitaplik)
                        {
                            Console.WriteLine(k);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Silmek istediğiniz kitabın adını giriniz:");
                        silinecek = Convert.ToString(Console.ReadLine());
                        System.Threading.Thread.Sleep(1000);
                        if (kitaplik.Contains(silinecek))
                        {
                            kitaplik.Remove(silinecek);
                            Console.WriteLine(silinecek + " adlı kitap kütüphaneden silindi.");
                        }
                        else if (!(kitaplik.Contains(silinecek)))
                        {
                            Console.WriteLine("Kütüphanede " + silinecek + " adlı kitap bulunamadı.");
                        }
                    }
                    else if (cevap == "2" && hesap == "kullanıcı")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else if (cevap == "1")
                    {
                        Console.WriteLine("Kütüphanedeki kitaplar:");
                        foreach (string k in kitaplik)
                        {
                            Console.WriteLine(k);
                        }
                    }
                    else if (cevap == "4" && hesap == "yonetici")
                    {
                        Console.WriteLine("Mevcut kullanıcılar:");
                        foreach (KeyValuePair<string, string> kullanici in kullanicilar)
                        {
                            Console.WriteLine(kullanici.Value);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Görevli yapmak istediğiniz kullanıcının adını girin.");
                        terfi = Console.ReadLine();
                        foreach (KeyValuePair<string, string> kullanici in kullanicilar)
                        {
                            if (kullanici.Value == terfi)
                            {
                                terfiyeUygun = true;
                                terfiKey = kullanici.Key;
                                terfiValue = kullanici.Value;
                            }
                        }
                        if (terfiyeUygun == true)
                        {
                            kullanicilar.Remove(terfiKey);
                            gorevliler.Add(terfiKey, terfiValue);
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine(terfiValue + " isimli kullanıcı başarıyla görevli yapıldı.");
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine("Aradığınız kullanıcı mevcut değil.");
                        }
                    }
                    else if (cevap == "4" && hesap != "yonetici")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else if (cevap == "5" && hesap == "yonetici")
                    {
                        Console.WriteLine("Mevcut görevliler:");
                        foreach (KeyValuePair<string, string> gorevli in gorevliler)
                        {
                            Console.WriteLine(gorevli.Value);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Yetkisini almak istediğiniz görevlinin adını girin.");
                        tenzil = Console.ReadLine();
                        foreach (KeyValuePair<string, string> gorevli in gorevliler)
                        {
                            if (gorevli.Value == tenzil)
                            {
                                tenzileUygun = true;
                                tenzilKey = gorevli.Key;
                                tenzilValue = gorevli.Value;
                            }
                        }
                        if (tenzileUygun == true)
                        {
                            gorevliler.Remove(tenzilKey);
                            kullanicilar.Add(tenzilKey, tenzilValue);
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine(tenzilValue + " isimli görevlinin yetkisi başarıyla alındı.");
                        } else
                        {
                            System.Threading.Thread.Sleep(500);
                            Console.WriteLine("Aradığınız görevli mevcut değil.");
                        }
                    } 
                    else if (cevap == "5" && hesap != "yonetici")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else if (cevap == "6" && hesap == "yonetici")
                    {
                        Console.WriteLine("Mevcut görevliler:");
                        foreach (KeyValuePair<string, string> gorevli in gorevliler)
                        {
                            Console.WriteLine(gorevli.Value);
                        }
                    }
                    else if (cevap == "6" && hesap != "yonetici")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else if (cevap == "7" && hesap == "yonetici")
                    {
                        Console.WriteLine("Mevcut kullanıcılar:");
                        foreach (KeyValuePair<string, string> kullanici in kullanicilar)
                        {
                            Console.WriteLine(kullanici.Value);
                        }
                    }
                    else if (cevap == "7" && hesap != "yonetici")
                    {
                        Console.WriteLine("Yetkiniz bu işlemi yapmak için yetersiz.");
                    }
                    else
                    {
                        Console.WriteLine("Yapmak istediğiniz işlem mevcut değil.");
                    }
                }
            }
        }
    }
}
