using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GoFish
{
    internal class Talia
    {
        public List<Karta> Karty { get; private set; } = new List<Karta>();

        private List<string> wysokosciKart = new List<string>() { "A", "K", "D", "W", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        private List<string> koloryKart = new List<string>() { "T", "K", "k", "P" };

        public Talia()
        {

            foreach (var wysokosc in wysokosciKart)
            {
                foreach (var kolor in koloryKart)
                {
                    Karty.Add(new Karta(wysokosc, kolor));
                }
            }
        }

        public void WyswietlLiczbeKartWTalii()
        {
            Console.WriteLine($"\n\nW talii znajduje się {Karty.Count} kart");
        }

        public void WyswieltTalie()
        {
            Console.WriteLine("\nTak wygląda talia kart:");

            foreach (var karta in Karty)
            {
                Console.WriteLine(karta);
            }
        }
    }
}
