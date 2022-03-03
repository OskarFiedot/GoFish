using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    internal class Karta
    {
        public string Wysokosc { get; private set; }

        public string Kolor { get; private set; }

        public Karta(string wysokosc, string kolor)
        {
            Wysokosc = wysokosc;

            Kolor = kolor;
        }

        public override string ToString()
        {
            return $" |{Wysokosc}{Kolor}| ";
        }
    }
}
