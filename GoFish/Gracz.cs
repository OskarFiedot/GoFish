using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    internal class Gracz
    {
        public string Nazwa { get; private set; }

        public bool Symulacja { get; private set; }

        public List<Karta> Karty { get; private set; } = new List<Karta>();

        public List<string> Stosy { get; private set; } = new List<string>();

        public Gracz(string nazwa, bool symulacja)
        {
            Nazwa = nazwa;

            Symulacja = symulacja;

            //Karty = new List<Karta>();

            //Stosy = new List<string>();
        }

        public void SprawdzStosy()
        {
            foreach (var karta in Karty)
            {
                if (!Stosy.Contains(karta.Wysokosc))
                {
                    var ileKartDanejWysokosci = 0;

                    foreach (var karta_2 in Karty)
                    {
                        if (karta.Wysokosc == karta_2.Wysokosc)
                        {
                            ileKartDanejWysokosci++;
                        }
                    }

                    if (ileKartDanejWysokosci == 4)
                    {
                        Stosy.Add(karta.Wysokosc);
                    }
                }
            }

            foreach (var stos in Stosy)
            {
                for (int i = 0; i < Karty.Count; i++)
                {
                    if (stos == Karty[i].Wysokosc)
                    {
                        Karty.Remove(Karty[i]);
                        i--;
                    }
                }
            }
        }

        public List<Karta> SprawdzKarty(string wysokosc)
        {
            var kartyDoOddania = new List<Karta>();

            for (int i = 0; i < Karty.Count; i++)
            {
                if (wysokosc == Karty[i].Wysokosc)
                {
                    kartyDoOddania.Add(Karty[i]);
                    Karty.Remove(Karty[i]);
                    i--;
                }
            }

            return kartyDoOddania;
        }

        public void WyswietlKartyGracza()
        {
            Console.Write($"\n\nKarty gracza {Nazwa}:");

            foreach (var karta in Karty)
            {
                Console.Write(karta);
            }

            if (Stosy.Count != 0)
            {
                Console.Write("+ stosy:");

                foreach (var stos in Stosy)
                {
                    Console.Write($"  {stos}");
                }
            }
        }

        public void WyswietlStosyGracza()
        {
            Console.Write($"\n{Nazwa}: ");

            foreach (var stos in Stosy)
            {
                Console.Write($"{stos} ");
            }
        }

        public int LiczbaKartGracza()
        {
            return (Karty.Count + (Stosy.Count * 4));
        }
    }
}
