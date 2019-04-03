using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Cat är en subklass som ärver Animal-klassen och som är mallen för att skapa objekt av katter
    class Cat : Animal
    {
        //Konstruktor för klassen
        public Cat(int age, string name, string favFood, string breed) : base(age, name, favFood, breed)
        {
            animalType = "Katt";           
        }       

        //Den overridade metoden HungryAnimal används för att styra kattens beteende om den inte får sin favoritmat när den är hungrig
        public override void HungryAnimal()
        {
            Random random = new Random();  //Slumpgenerator
            int probability = random.Next(1, 101);  //Variabel som lagrar slumpat värde

            Console.WriteLine();
            Console.WriteLine("Katten är hungrig och springer ut och jagar efter möss!");
            Console.WriteLine();

            if(probability < 51)  //Om probability är under 51 så hittar katten en mus (50% chans)
            {
                Console.WriteLine("Den hittar en mus som den fångar och äter upp!");
                Console.WriteLine("{0} är nu mätt!", name);
                hungerMeter = animalFull;  //hungerMeter får sitt startvärde igen för att symbolisera att djuret är mätt
                hungry = false;  //hungry får värdet false för att symbolisera att djuret är mätt
            }

            else  //annars så hittar inte katten någon mus (50% risk)
            {
                Console.WriteLine("Den letar överallt men hittar ingen mus...");
                base.HungryAnimal();
            }           
        }        
    }
}
