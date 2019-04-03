using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Dog är en subklass som ärver Animal-klassen och som är mallen för att skapa objekt av hundar
    class Dog : Animal
    {
        //Konstruktor för klassen
        public Dog(int age, string name, string favFood, string breed) : base(age, name, favFood, breed)
        {
            animalType = "Hund";
            lowerValue = 2;  //lowerValue har ett värde som bestämmer hur mycket bollens kvalité ska sänkas efter lek
        }

        //Den overridade metoden Interact är där lek med hunden sker, anropas med en boll som in-paramter
        public override void Interact(Ball ball)
        {
            if (!hungry)  //Om djuret inte är hungrigt så händer detta
            {
                Console.WriteLine("{0} leker och biter hårt i bollen!", name);
                Console.WriteLine("Bollens kvalité minskar.");
                ball.LowerQuality(lowerValue);  //Metoden LowerQuality anropas för att sänka bollens kvalité efter lek
                LowerHungerMeter();  //Anrop av metoden LowerHungerMeter för att påverka hundens hunger efter lek
            }          

            else  //Annars om hunden är hungrig så orkar den inte leka
            {
                Console.WriteLine("{0} är hungrig och orkar inte leka...", name);
            }

        }       
    }
}
