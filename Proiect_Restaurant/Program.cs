
using Proiect_Restaurant;
using System;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;


//Aplicatia contine un meniu predefinit cu produse (denumire, lista ingrediente, pret).
//Utilizatorul poate filtra produsele dupa ingrediente sau pret si poate selecta un produs
//dupa pozitia acestuia sau denumire. Prin selectarea unui produs,
//utilizatorul are posibilitatea de a il adauga pe lista lui
//de comanda impreuna cu cantitatea dorita. Utilizatorul isi poate
//afisa lista curenta a comenzii care contine produsele droite,
//cantitatile acestora, preturile aferente dar si pretul total al comenzii.

class Program
{
    static IngredientMenu list;
    static IngredientMenu cumparaturiLista;
    static string[] MainMenuOptions = { "EXIT", "Afisare Meniu" };
    static string[] ShowMenuOptions = { "INAPOI", "Adaugare produs", "Afisare lista", "Filtru" };
    static string[] SelectionProductOptions = { "INAPOI", "Afisare lista" };
    static string[] DisplayListOption = { "INAPOI", "Stergere" };
    static string[] FiltruOptions = { "INAPOI", "Adaugare produs/cantitate" };
    static string[] FiltruOptionsExample = { "INAPOI", "Dupa Nume", "Dupa Pret" };
    static string[] Back = { "INAPOI" };

    public static void Main(string[] arg)
    {

        list = new IngredientMenu();
        cumparaturiLista = new IngredientMenu();

        GetData();
        ShowMainMenu();

    }

    static void GetData()
    {

        list.Menus.Add(new Ingredient("Piept de pui", "35 RON"));
        list.Menus.Add(new Ingredient("Paste carbonara", "28 RON"));
        list.Menus.Add(new Ingredient("Supa crema de pui", "25 RON"));
        list.Menus.Add(new Ingredient("Papanasi", "29 RON"));
        list.Menus.Add(new Ingredient("Clatite", "35 RON"));
    }

    static void ShowMainMenu()
    {
        int input;
        do
        {
            Console.Clear();
            Console.WriteLine("Bine ati venit in restaurantul nostru!!");
            Console.WriteLine();
            ShowOptions(MainMenuOptions);
            Console.WriteLine();
            input = CitesteInput();
            if (input != 1) continue;
            ShowAllRestaurantMenu();

        } while (input != 0);


    }

    static void ShowOptions(string[] commands)
    {
        for (int i = 0; i < commands.Length; i++)
        {
            Console.WriteLine(i + " : " + commands[i]);
        }
    }

    static int CitesteInput()
    {
        int a;

        Console.Write("Alegeti o optiune:");
        string aInput = Console.ReadLine();
        bool aValid = int.TryParse(aInput, out a);

        while (!aValid)
        {
            Console.WriteLine("Nu ati scris corect. Mai incercati o data!");
            Console.WriteLine("Alegeti o optiune:");
            aInput = Console.ReadLine();
            aValid = int.TryParse(aInput, out a);
        }
        return a;
    }


    static void ShowAllRestaurantMenu()
    {
        int input;
        do
        {
            Console.Clear();
            Console.WriteLine();
            list.ShowMenuList();
            Console.WriteLine();
            ShowOptions(ShowMenuOptions);
            Console.WriteLine();
            input = CitesteInput();
            if (input == 1)
            {
                CreateMyList();
            }
            else if (input == 2)
            {
                ShowEmptyListMessage();
                ShowMyList();
            }
            else if (input == 3)
            {
                FiltredList();
            }
            else if (input == 0)
            {
                ShowMainMenu();
            }
        } while (input != 0);


    }

    static void ShowMyList()
    {
        int input;
        do
        {
            Console.Clear();
            Console.WriteLine("Lista mea este:");
            cumparaturiLista.ShowMenuList();
            Console.WriteLine();
            ShowOptions(DisplayListOption);
            Console.WriteLine();
            input = CitesteInput();
            if (input == 1)
            {
                DeleteItem();

            }
            if (input == 0)
            {
                CreateMyList();
            };



        } while (input != 0);
    }

    static void CreateMyList()
    {
        int input;
        Console.Clear();

        do
        {
            Console.Clear();
            list.ShowMenuList();
            Console.WriteLine();
            ShowOptions(Back);
            input = CitesteInput();
            //Console.WriteLine("aici");
            if (input == 0)
            {
                //break;
                ShowAllRestaurantMenu();
            }
            if (input >= 1)
            {
                Console.Clear();
                cumparaturiLista.Menus.Add(list.Menus[input - 1]);
                list.DisplayProduct(input);
                Console.WriteLine();
                ShowOptions(SelectionProductOptions);
                ShowMyList();
            }
        } while (input != 0);

    }

    static void DeleteItem()
    {
        int input;
        //Console.Clear();
        Console.Clear();
        Console.WriteLine("Elementul pe care vreti sa il eliminati din lista este :");
        cumparaturiLista.ShowMenuList();
        Console.WriteLine();
        input = CitesteInput();
        Ingredient elementSters = cumparaturiLista.Menus[input - 1];
        Console.WriteLine();
        cumparaturiLista.Menus.Remove(elementSters);
        Console.WriteLine();
        int count = cumparaturiLista.Menus.Count();
        if (count == 0)
        {
            ShowEmptyListMessage();

        }

    }

    static void ShowEmptyListMessage()
    {
        //int count = cumparaturiLista.Menus.Count();
        int input;

        //do
        //{
        Console.Clear();
        int count = cumparaturiLista.Menus.Count();
        if (count == 0)
        {
            Console.Clear();
            Console.WriteLine("Lista mea este goala");
            Console.WriteLine();
            ShowOptions(Back);
        }
        //input = CitesteInput();

        if (count == 0)
        {
            input = CitesteInput();

            ShowAllRestaurantMenu();
        }
        //} while (input != 0);

    }

    static void FiltredList()
    {
        int input;
        Console.Clear();
        Console.WriteLine("Afisati lista dupa un filtru:");
        Console.WriteLine();
        ShowOptions(FiltruOptionsExample);
        do
        {
            // Console.Clear();
            //Console.WriteLine("Afisati lista dupa un filtru:");
            //Console.WriteLine();
            //ShowOptions(FiltruOptionsExample);
            //Console.WriteLine();
            Console.WriteLine();
            input = CitesteInput();
            Console.WriteLine();


            if (input == 1)
            {
                AddProductToListFromfiltreName();
            }
            else if (input == 2)
            {

                AddProductToListFromfiltrePrice();
            }
            else if (input == 0)
            {
                continue;
            }

        } while (input != 0);
    }

    static void AddProductToListFromfiltreName()
    {
        Console.Clear();
        List<Ingredient> filtredListByName = list.FilterByName("Clatite");
        IngredientMenu.ShowMenuListCollection(filtredListByName);
        Console.WriteLine();
        ShowOptions(Back);
        Console.WriteLine();
    }

    static void AddProductToListFromfiltrePrice()
    {

        Console.Clear();
        List<Ingredient> filtredListByPrice = list.FilterByPrice("28 RON");
        IngredientMenu.ShowMenuListCollection(filtredListByPrice);
        Console.WriteLine();
        ShowOptions(Back);
        Console.WriteLine();
    }
}


