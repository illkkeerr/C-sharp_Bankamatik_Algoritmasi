using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankamatikUygulamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Bankamatik_Uygulaması
            string choice, name;
            decimal balance = 100000m;
            double depositMoney, withdrawMoney, sendMoney, witdrawalLimit = 0;

        Menu:
            name = "";
            choice = "";
            Console.Clear();
            Console.WriteLine("Aktif Banka Hoşgeldiniz\nHangi İşlemi Yapmak İstersiniz");
            Console.WriteLine("1-Para Yatırma\n2-Para Çekme\n3-Para Gönderme\n4-Kart İade");
            Console.Write("Seçiniz:");
            choice = Console.ReadLine();
            Console.WriteLine("Lütfen Bekleyiniz...");
            Thread.Sleep(1500);

            if (choice == 1.ToString())
            {
            DepositedMoney:
                Console.Clear();
                depositMoney = 0;
                Console.WriteLine($"Para Yatırma işlemi\nBakiyeniz:{balance} TL");
                Console.Write("Hesabınıza ne kadar para yatırmak istersiniz:");

                try
                {
                    depositMoney = Convert.ToDouble(Console.ReadLine());
                    balance += (decimal)depositMoney;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Bir hata oluştu\nLütfen Bekleyiniz...");
                    Thread.Sleep(1500);
                    goto DepositedMoney;
                }

                Console.WriteLine("Lütfen Bekleyiniz...");
                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine($"{depositMoney} TL hesabınıza yatırıldı." +
                    $"\nGüncel Bakiyeniz:{balance} TL");
                Console.Write("Ana Menüye dönmek için 1'e,\nPara Yatırma işlemine devam etmek için 2'ye,\n" +
                    "Çıkış yapmak için 3'e basınız:");
            Choice:
                choice = Console.ReadLine();
                if (choice == "1")
                    goto Menu;
                else if (choice == "2")
                    goto DepositedMoney;
                else if (choice == "3")
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Yanlış bir seçim yaptınız.\nTekrar seçim yapınız");
                    Console.WriteLine("Ana Menü için 1,\nPara Yatırma işlemi için 2,\n" +
                   "Çıkış Yapma İşlemi için 3");
                    Console.Write("Seçiniz:");
                    goto Choice;
                }
            }
            else if (choice == 2.ToString())
            {
            WithdrawMoney:
                withdrawMoney = 0;
                Console.Clear();
                Console.Write($"Para Çekme İşlemi\nBakiyeniz:{balance} TL" +
                    $"\nNe kadar para çekmek istersiniz:");
                try
                {
                    withdrawMoney = Convert.ToDouble(Console.ReadLine());
                    if (withdrawMoney > 5000)
                    {
                        Console.WriteLine("Çekmek istediğiniz miktar günlük limitin 5000 TL'nin üstünde." +
                            "\nTekrar Deneyiniz...");
                        Thread.Sleep(1500);
                        goto WithdrawMoney;
                    }
                    else if ((decimal)withdrawMoney > balance)
                    {
                        Console.WriteLine("Bakiyenizde çekmek istediğiniz miktar kadar para yok." +
                            "\nTekrar Deneyiniz...");
                        Thread.Sleep(1500);
                        goto WithdrawMoney;
                    }
                    else
                    {
                        witdrawalLimit += withdrawMoney;
                        if (witdrawalLimit < 5001)
                            balance -= (decimal)withdrawMoney;
                        else
                        {
                            witdrawalLimit -= withdrawMoney;
                            Console.WriteLine("günlük 5000 TL çekim limitini aştınız." +
                                "\nTekrar Deneyiniz... ");
                            Thread.Sleep(1500);
                            goto WithdrawMoney;
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Bir hata oluştu.\nLütfen Bekleyiniz...");
                    Thread.Sleep(1500);
                    goto WithdrawMoney;
                }
                Console.WriteLine("Lütfen Bekleyiniz...");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine($"Lütfen {withdrawMoney} TL'nizi hazneden alınız." +
                    $"\nGüncel Bakiyeniz:{balance}");
                Console.Write("Menüye dönmek için 1'e" +
                    "\nPara çekme işlemine devam etmek için 2'ye\nÇıkış yapmak için 3'e basınız:");
            Choice:
                choice = Console.ReadLine();
                if (choice == "1")
                    goto Menu;
                else if (choice == "2")
                    goto WithdrawMoney;
                else if (choice == "3")
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bir hata oluştu.\nTekrar seçim yapınız...");
                    Thread.Sleep(1500);
                    Console.Write("Menüye dönmek için 1'e" +
                   "\nPara çekme işlemine devam etmek için 2'ye\nÇıkış yapmak için 3'e basınız:");

                    goto Choice;
                }


            }
            else if (choice == 3.ToString())
            {
            SendMoney:
                sendMoney = 0;
                Console.Clear();
                Console.Write($"Para Gönderme İşlemi\nBakiyeniz:{balance}" +
                    $"\nNe kadar para göndermek istersiniz:");
                try
                {
                    sendMoney = Convert.ToDouble(Console.ReadLine());
                    if ((decimal)sendMoney > balance)
                    {
                        Console.WriteLine("Bakiyenizde para göndermek için yeterli miktarda para yok." +
                            "\nLütfen Tekrar Deneyiniz...");
                        Thread.Sleep(1500);
                        goto SendMoney;
                    }
                    else
                    {
                        balance -= (decimal)sendMoney;
                        Console.Write("Para göndermek istediğiniz kişi\\kurum adını yazınız:");
                        name = Console.ReadLine();
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Bir hata oluştu.\nLütfen bekleyiniz...");
                    Thread.Sleep(1500);
                    goto SendMoney;
                }
                Console.WriteLine("Lütfen Bekleyiniz...");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine($"{sendMoney} TL {name} alıcısına gönderildi." +
                    $"\nGüncel Bakiyeniz:{balance}");
                Console.Write("Menüye dönmek için 1'e\nPara gönderme işlemine devam etmek için 2'ye" +
                    "\nÇıkış yapmak için 3'e basınız:");
            Choice:
                choice = Console.ReadLine();
                if (choice == "1")
                    goto Menu;
                else if (choice == "2")
                    goto SendMoney;
                else if (choice == "3")
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bir hata oluştu.\nTekrar Seçim Yapınız");
                    Thread.Sleep(1500);
                    Console.Write("Menüye dönmek için 1'e\nPara gönderme işlemine devam etmek için2'ye" +
                  "\nÇıkış yapmak için 3'e basınız:");
                    goto Choice;
                }

            }
            else if (choice == 4.ToString())
            {
                Console.Clear();
                Console.WriteLine("İşleminiz yapılıyor lütfen bekleyiniz...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Seçim yapılırken bir hata oluştu tekrar Ana Menüye yönlendiriliyorsunuz...");
                Thread.Sleep(1500);
                goto Menu;

            }


            #endregion
        }
    }
}
