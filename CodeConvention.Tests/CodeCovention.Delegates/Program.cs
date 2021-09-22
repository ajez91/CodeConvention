using System;
using System.Collections;
using System.Reflection;

namespace CodeCovention.Delegates
{
    //public class System
    //{
    //    //publiczna definicja delegaty (będzie klasą zagnieżdżoną)
    //    public delegate void Logi(string wiadomosc);

    //    //prywatna zmienna delegata
    //    private Logi _wyslijLogi;

    //    //setter dla zmeinnej delegata
    //    public void DodajCallback(Logi funkcja)
    //    {
    //        _wyslijLogi += funkcja;
    //    }

    //    public void UsunCallback(Logi funkcja)
    //    {
    //        _wyslijLogi += funkcja;
    //    }

    //    //przykladowa funkcjonalność naszej klasy
    //    public bool Logowanie(string user, string password)
    //    {
    //        /* jakeiś operacje odpowiedzialne za Autoryzację */

    //        _wyslijLogi("Nastąpiła próba logowania użytkownika: " + user);

    //        return true;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        //tworzymy instancję klasy i podpinamy funckję zwrotną
    //        System system = new System();
    //        system.DodajCallback(CallbackLogi);
    //        system.DodajCallback(DodatkoweLogi);

    //        system.Logowanie("user", "pass");

    //        Console.ReadKey();
    //    }

    //    static void CallbackLogi(string wiadomosc)
    //    {
    //        Console.WriteLine(wiadomosc);
    //        Console.WriteLine("Została wywołana funkcja zwrotna");
    //    }

    //    static void DodatkoweLogi(string wiadomosc)
    //    {
    //        Console.WriteLine("Dodatkowa wiadomość po logowaniu");
    //    }
    //}

    //public class Liczby
    //{
    //    // deklaracja publicznej delegaty
    //    public delegate void DelOperacja(ref ArrayList list);

    //    //prywatna kolekcja
    //    ArrayList _listaLiczb = new ArrayList();

    //    //konstruktor
    //    public Liczby(params int[] liczby)
    //    {
    //        _listaLiczb.AddRange(liczby);
    //    }

    //    //callback wywołujący delegatę. Co wywoła? Nie wiadomo!
    //    //zalezy to od kogoś, kto będzie pracował na naszej klasie
    //    public void Operacja(DelOperacja operacja)
    //    {
    //        operacja(ref _listaLiczb);
    //    }
    //}

    ////statyczna klasa z metodami, które pasują do callbacka
    //public static class Operacje
    //{
    //    public static void Drukuj(ref ArrayList lista)
    //    {
    //        foreach (var i in lista) { Console.Write(i); }
    //        Console.WriteLine();
    //    }

    //    public static void Odwroc(ref ArrayList lista)
    //    {
    //        lista.Reverse();
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Liczby l = new Liczby(1, 2, 3, 4, 5, 6);

    //        //wypisze liczby
    //        l.Operacja(Operacje.Drukuj);

    //        //wypisze liczby w odwrotnej kolejności
    //        l.Operacja(Operacje.Odwroc);
    //        l.Operacja(Operacje.Drukuj);

    //        Console.ReadKey();
    //    }
    //}
    //public class Matematyka
    //{
    //    public int Dodawanie(int x, int y)
    //    {
    //        return x + y;
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Matematyka m = new Matematyka();

    //        //podpięcie delegata Func do metody klasy Matematyka
    //        Func<int, int, int> dodawanie = m.Dodawanie;

    //        Console.WriteLine(dodawanie(1, 2));

    //        Console.ReadKey();
    //    }

    //class Osoba
    //{
    //    public String imie { get; set; }
    //    public Osoba(string imie) { this.imie = imie; }
    //    public void Info() { Console.WriteLine("imie: {0}", imie); }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Osoba osoba1 = new Osoba("Karol");
    //        Osoba osoba2 = osoba1;

    //        Console.WriteLine(osoba1.imie); // wyswietli Karol
    //        Console.WriteLine(osoba1.imie); // wyswietli Karol

    //        osoba1.imie = "Karol";
    //        osoba2.imie = "Arek";

    //        Console.WriteLine(osoba1.imie); // wyswietli Arek
    //        Console.WriteLine(osoba1.imie); // wyswietli Arek

    //        Console.ReadKey();
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var dog = Activator.CreateInstance(typeof(Dog)) as Dog;
            // Dostęp do właściowości klasy
            PropertyInfo[] properties = dog.GetType().GetProperties();
            PropertyInfo prep1 = properties[0];
            PropertyInfo prep2 = properties[1];
            // Ustawiamy wartość poszczególnych pól
            prep1.SetValue(dog, 3);
            prep2.SetValue(dog, "wilczur");
            // Wyświetlenie tych wartości
            Console.WriteLine(prep1.GetValue(dog, null));
            Console.WriteLine(prep2.GetValue(dog, null));
            // Dostęp do konstruktora
            var defaultConstr = typeof(Dog).GetConstructor(new Type[0]);
            var paramConstr = typeof(Dog).GetConstructor(new[] { typeof(int) });
            // Wywołanie konstruktorów
            var defConstrTest = (Dog)defaultConstr.Invoke(null);
            var secConstrTest = (Dog)paramConstr.Invoke(new object[] { 45 });
            // Wyświetlenie wartości po wywołaniu konstruktorów
            Console.WriteLine("Pierwszy konstruktor, liczba nóg: {0}", defConstrTest.NumberOfLegs);
            Console.WriteLine("Drugi konstruktor, liczba nóg: {0}", secConstrTest.NumberOfLegs);
            // Dostęp do metod
            var TestMethod = typeof(Dog).GetMethod("SetDogsBread");
            var InvokeMethod = (Dog)TestMethod.Invoke(dog, new object[] { "Mieszaniec" });
            Console.ReadKey();

            // Wynik działania programu
            // 3
            // wilczur
            // Pierwszy konstruktor, liczba nóg: 0
            // Drugi konstruktor, liczba nóg: 45
            // Refleksja! - Rasa psa: Mieszaniec
        }
    }
    class Dog
    {
        public int NumberOfLegs { get; set; }
        public string Breed { get; set; }
        public Dog()
        {
        }
        public Dog(int number)
        {
            NumberOfLegs = number;
        }
        public void SetDogsBread(string breed)
        {
            this.Breed = breed;
            Console.WriteLine("Refleksja! - Rasa psa: {0}", breed);
        }
        public void SetLegsNumber(int number)
        {
            this.NumberOfLegs = number;
        }
        public void Display()
        {
            Console.Write("Liczba nóg: {0}", NumberOfLegs);
            Console.WriteLine("Rasa psa: {0}", Breed);
        }
    }
}

