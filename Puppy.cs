using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Puppy är en subklass som ärver Dog-klassen och som är mallen för att skapa objekt av hundvalpar
    class Puppy : Dog
    {        
        private int months;  //Hundvalpen har en ålder i månader istället för år

        //Konstruktor för klassen
        public Puppy(int age, string name, string favFood, string breed) : base(age, name, favFood, breed)
        {
            animalType = "Hundvalp";
            lowerValue = 1;

            //Villkorssats för att styra valpens ålder i månader
            if (age > 12)
            {
                months = 12;
            }
            else if(age < 1)
            {
                months = 1;
            }
            else
            {
                months = age;                
            }

            this.age = 0;  //Ålder i år får värdet noll för att hundvalpen bara ska ha ålder i månader
        }

        //Den overridade metoden Interact är där lek med hundvalpen sker, anropas med en boll som in-paramter
        public override void Interact(Ball ball)
        {
            if (!hungry)  //Om djuret inte är hungrigt så händer detta
            {
                Console.WriteLine("{0} nafsar på bollen.", name);
                Console.WriteLine("Bollens kvalité minskar.");
                ball.LowerQuality(lowerValue);  //Metoden LowerQuality anropas för att sänka bollens kvalité efter lek
                LowerHungerMeter();  //Anrop av metoden LowerHungerMeter för att påverka hundvalpens hunger efter lek
            }

            else  //Annars om hunden är hungrig så orkar den inte leka
            {
                Console.WriteLine("{0} är hungrig och orkar inte leka...", name);
            }
        }

        //ToString metod för utskrift av objekt
        public override string ToString()
        {
            return string.Format("{0}en {1} är av rasen {2}, har {3} som favoritmat och är {4} månader", animalType, name, breed, favFood, months);
        }
    }
}
