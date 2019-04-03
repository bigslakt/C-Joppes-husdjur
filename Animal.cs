using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Animal är en abstrakt basklass som måste ärvas innan man kan skapa objekt av den
    abstract class Animal
    {
        protected string animalType;  //Djurtyp
        protected int age;
        protected string name;
        protected string favFood;  //Djurets favoritmat
        protected string breed;  //Ras
        protected int animalFull;  //animalFull lagrar det värde som symboliserar att djuret är mätt
        protected int hungerMeter;  //hungerMeter initieras till samma värde som animalFull när den är mätt och minskar när den blir mer hugrig
        protected bool hungry;  //Bool-variabeln hungry styr om djuret är mätt eller hungrigt och styrs av variabeln hungerMeter
        protected int lowerValue;  //lowerValue får ett värde beroende på djurart och symboliserar hur mycket kvalitén ska sänkas på bollen när den används

        //Konstruktor för klassen
        public Animal(int age, string name, string favFood, string breed)
        {            
            this.age = age;
            this.name = name;
            this.favFood = favFood;
            this.breed = breed;
            animalFull = 4;  //Här bestämms värdet för när ett djur är mätt
            hungerMeter = animalFull;  //Här får hunger-mätaren värdet för när djuret är mätt
            hungry = false;  //hungry får false som startvärde, djuret är då mätt
            lowerValue = 1;
        }

        //Metoden GetName används för att hämta djurets namn
        public string GetName()
        {
            return name;
        }

        //Metoden GetAnimalType används för att hämta djur-typ
        public string GetAnimalType()
        {
            return animalType;
        }

        //Metoden LowerHungerMeter används för att sänka värdet för hunger 
        public void LowerHungerMeter()
        {
            hungerMeter--;  //Hungermätarn sänks för att symbolisera att djuret blir hungrigare

            if(hungerMeter == 0)  //När mätarn för hunger når noll så är djuret mätt
            {
                hungry = true;  //hungry får värdet true för att symbolisera att djuret blir mätt

                Console.WriteLine();
                Console.WriteLine("Nu är {0} hungrig!", name);
            }
        }

        //Metoden Interact är där lek med djuret sker, anropas med en boll som in-paramter
        public virtual void Interact(Ball ball)
        { 
            if (!hungry)  //Om djuret inte är hungrigt så händer detta 
            {
                Console.WriteLine("{0} nafsar på bollen.", name);
                Console.WriteLine("Bollens kvalité minskar.");
                ball.LowerQuality(lowerValue);  //Metoden LowerQuality anropas för att sänka bollens kvalité efter lek
                LowerHungerMeter();  //Anrop av metoden LowerHungerMeter för att påverka djurets hunger efter lek
            }

            else  //Annars om djuret är hungrigt så orkar det inte leka
            {
                Console.WriteLine("{0} är hungrig och orkar inte leka...", name);
            }
        }

        //Metoden Eat är där djuret äter och den anropas med mat som in-parameter
        public void Eat(Food food)
        {
            if(food.GetFoodType().Equals(favFood))  //Om maten som skickats med som in-paramter stämmer överrens med djurets favoritmat
            {
                Console.WriteLine("{0} fick sin favoritmat och äter glatt upp den!", name);
                Console.WriteLine("{0} är nu mätt!", name);
                hungerMeter = animalFull;  //hungerMeter får sitt startvärde igen för att symbolisera att djuret är mätt
                hungry = false;  //hungry får värdet false för att symbolisera att djuret är mätt
            }

            else  //Annars om djuret inte får sin favoritmat
            {
                Console.WriteLine("{0} tycker inte om maten och rör den inte.", name);

                if (hungry)  //Om djuret är hungrigt och får fel mat
                {
                    HungryAnimal();  //Metoden HungryAnimal anropas 
                }
            }
        }

        //Metoden HungryAnimal används för att styra djurets beteende om den inte får sin favoritmat när den är hungrig
        public virtual void HungryAnimal()
        {
            Console.WriteLine("{0} gnyr av hunger!", name);
        }

        //ToString metod för utskrift av objekt
        public override string ToString()
        {
            return string.Format("{0}en {1} är av rasen {2}, har {3} som favoritmat och är {4} år", animalType, name, breed, favFood, age);
        }
    }

    
}
