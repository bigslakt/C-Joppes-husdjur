using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    class Program
    {
        //Metoden Main är där programmet startar
        static void Main(string[] args)
        {
            Petowner petowner = new Petowner("Joppe", 25);  //Här skapas ett objekt av klassen Petowner
            petowner.Menu();  //Här anropas metoden Menu i petowner där programmet kommer utgå ifrån

            Console.WriteLine("Tryck på en tangent för att avsluta...");
            Console.ReadKey(true);
        }
    }
}
