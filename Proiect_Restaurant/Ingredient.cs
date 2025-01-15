using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Restaurant
{
    internal class Ingredient
    {
        public string Nume;
        public string Pret;

        public Ingredient(string nume, string pret)
        {
            Nume = nume;
            Pret = pret;

        }
        public string GetDataMenu()
        {
            return $"{Nume}| Pret :{Pret}";
        }

    }
}

