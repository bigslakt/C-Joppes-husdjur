using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Snake är en subklass som ärver Animal-klassen och som är mallen för att skapa objekt av ormar
    class Snake : Animal
    {
        //Konstruktor för klassen 
        public Snake(int age, string name, string favFood, string breed) : base(age, name, favFood, breed)
        {
            animalType = "Orm";           
        }

        //Den overridade metoden HungryAnimal används för att styra ormens beteende om den inte får sin favoritmat när den är hungrig
        public override void HungryAnimal()
        {
            Console.WriteLine("{0} väser av hunger!", name);
        }
    }
}
