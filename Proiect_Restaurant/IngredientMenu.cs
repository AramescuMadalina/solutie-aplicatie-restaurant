using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Restaurant
{
    internal class IngredientMenu
    {
        public List<Ingredient> Menus;


        public IngredientMenu()
        {
            Menus = new List<Ingredient>();
        }

        public void ShowMenuList()

        {
            Console.WriteLine();
            for (int i = 0; i < Menus.Count; i++)
            {
                Console.WriteLine((i + 1) + " : " + Menus[i].GetDataMenu());
            }


        }
        public void DisplayProduct(int position)
        {
            if (position > Menus.Count) { return; }
            Console.WriteLine("Preparatul a fost adaugat in lista : " + Menus[position - 1].Nume + " la pretul de " + Menus[position - 1].Pret);

        }

        public void ShowMyList(List<Ingredient> collection)
        {
            Console.WriteLine("Lista mea: ");
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine((i + 1) + " : " + collection[i].GetDataMenu());

            }
        }

        internal void Add(Ingredient ingredient)
        {

        }
        public void DeleteItemFromList(int position)
        {

            Console.WriteLine("Preparatul a fost sters: " + Menus[position - 1].Nume + " la pretul de " + Menus[position - 1].Pret);

        }

        public List<Ingredient> FilterByName(string nume)
        {
            return Menus.FindAll(x => x.Nume == nume).ToList();
        }

        public List<Ingredient> FilterByPrice(string pret)
        {
            return Menus.FindAll(x => x.Pret == pret).ToList();
        }

        public static void ShowMenuListCollection(List<Ingredient> collection)

        {
            Console.WriteLine();
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine((i + 1) + " : " + collection[i].GetDataMenu());
            }
        }
    }
}



