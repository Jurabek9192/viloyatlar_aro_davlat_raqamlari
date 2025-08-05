using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Siz O'zbekistonlikmisiz? ha/yo'q");
            string answer = Console.ReadLine();

            if (answer.ToLower() != "ha")
            {
                Console.WriteLine("Kechirasiz, bu dastur O'zbekistonliklar uchun edi aslida!!!");
                // Dasturni tugatish
                return;
            }
            
            // --- Viloyat tanlash qismi ---
            Console.WriteLine("Juda soz, siz qaysi viloyatliksiz:");
            
            // Enumdagi barcha viloyatlarni raqamlar bilan birga ko'rsatish
            var viloyatlar = Enum.GetNames(typeof(Viloyat));
            for (int i = 0; i < viloyatlar.Length; i++)
            {
                // Enumdagi qiymatlar 1 dan boshlanadi, shuning uchun (i + 1) ishlatamiz
                Console.WriteLine($"{(i + 1)}. {viloyatlar[i]}");
            }
            
            int raqam = 0; // Foydalanuvchi tanlagan raqam
            bool isTanlandi = false;

            while (!isTanlandi)
            {
                Console.Write("\nTanlovingizni kiriting (raqam): ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int tempRaqam) && Enum.IsDefined(typeof(Viloyat), tempRaqam))
                {
                    // Tanlov to'g'ri bo'lsa, raqamni saqlab chiqib ketamiz
                    raqam = tempRaqam;
                    isTanlandi = true;
                }
                else
                {
                    Console.WriteLine("Xato kiritish. Iltimos, ro'yxatdagi raqamlardan birini kiriting.");
                }
            }

            // --- Natijani hisoblash qismi ---
            int start, finish;

            switch (raqam)
            {
                case 1: start = 60; finish = 69; break;
                case 2: start = 80; finish = 84; break;
                case 3: start = 25; finish = 29; break;
                case 4: start = 70; finish = 74; break;
                case 5: start = 85; finish = 89; break;
                case 6: start = 50; finish = 59; break;
                case 7: start = 30; finish = 39; break;
                case 8: start = 75; finish = 79; break;
                case 9: start = 20; finish = 24; break;
                case 10: start = 1; finish = 9; break;
                case 11: start = 10; finish = 19; break;
                case 12: start = 40; finish = 49; break;
                case 13: start = 95; finish = 99; break;
                case 14: start = 90; finish = 94; break;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!!!");
                    // Dasturni tugatish
                    return;
            }
            
            // Tanlangan viloyatni enum raqamiga qarab olish
            Viloyat tanlanganViloyat = (Viloyat)raqam;
            Console.WriteLine($"\nSiz {tanlanganViloyat} viloyatini tanladingiz!");

            Natija(start, finish, tanlanganViloyat);
        }

        // Viloyat enum'i main metodidan tashqariga olindi, bu kodni yanada tartibli qiladi
        public enum Viloyat
        {
            Andijon = 1,
            Buxoro,
            Jizzax,
            Qashqadaryo,
            Navoiy,
            Namangan,
            Samarqand,
            Surxondaryo,
            Sirdaryo,
            Toshkent,
            Toshkent_vil,
            Fargona,
            Xorazm,
            Qoraqalpogiston
        }

        static void Natija(int start, int finish, Viloyat tanlanganViloyat)
        {
            // Ichma-ich sikllar o'rniga matematik ko'paytirish usuli
            long result = (long)(finish - start + 1) * 26 * 10 * 10 * 10 * 26 * 26;
            
            Console.WriteLine($"{tanlanganViloyat}da eng ko'pi bilan {result:N0} ta fuqarolarga mashina rasmiylashtirish mumkin!!!");
        }
    }
}