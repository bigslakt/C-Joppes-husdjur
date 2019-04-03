using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Petowner är mallen för djurägaren och där det mesta av programmet utförs
    class Petowner
    {
        private string name;
        private int age;        

        List<Animal> pets;  //Listan över djurägarens djur
        List<Ball> balls;  //Lista över djurägarens bollar
        Food[] foods = {new Food ("Hundmat"), new Food ("Kattmat"), new Food ("Kött") };  //Vektor för "skafferiet"
        
        //Klassens konstruktor
        public Petowner(string name, int age)
        {
            this.name = name;
            this.age = age;
            pets = new List<Animal>();
            balls = new List<Ball>();
        }      

        //Metoden Menu är här programmet utgår ifrån och innehåller menyn 
        public void Menu()
        {
            //Några djurobjekt skapas
            //En string för djurets favorit-mat skickas med för att kunna styra så djuren kan ha olika favoritmat oberoende av djur-art
            Animal dog = new Dog(10, "Lina", "Kött", "Golden retreiver");
            Animal puppy = new Puppy(8, "Enzo", "Hundmat", "Labrador");
            Animal cat = new Cat(1, "Zolo", "Kattmat", "Bondkatt");
            Animal snake = new Snake(3, "Ziggy", "Kött", "Anakonda");
            
            //Djurobjekten läggs in i listan pets
            pets.Add(dog);
            pets.Add(puppy);
            pets.Add(cat);
            pets.Add(snake);

            //Objekt för bollar skapas 
            Ball football = new Ball("Fotboll", "vit");
            Ball tennisball = new Ball("Tennisboll", "grön");
            Ball yarnball = new Ball("Garnboll", "röd");

            balls.AddRange(new[] { football, tennisball, yarnball });  //Här läggs bollarna till i listan balls           

            int menuOption;  //Variabel för menyval            

            Console.WriteLine("Hej och välkommen hem till {0}! \n{0} är {1} år och har {2} husdjur.", name, age, pets.Count());
            Console.WriteLine("Genom detta programmet kan {0} interagera med sina djur.", name);
            Console.WriteLine("Du får här några alternativ att leka runt med!");            

            //Do while-loop som loopar programmets meny medan inmatat värde inte är noll
            do
            {
                menuOption = -1;  //menuOption får värdet -1 för att få ett värde som kan hanteras av defaulten i switch-case menyn vid eventuell felhantering

                Console.WriteLine();
                Console.WriteLine("MENY");
                Console.WriteLine("--------------");
                Console.WriteLine("1. Leka med djur");
                Console.WriteLine("2. Mata djur");
                Console.WriteLine("3. Lista över djur");
                Console.WriteLine("4. Kolla kvalité på boll");
                Console.WriteLine("0. Avsluta");
                Console.WriteLine("--------------");

                menuOption = ReadInput(4);  //Här anropas metoden ReadInput för felhantering, med ett maxvärde för inmatning (Här 4 alternativ i menyn)

                //Switch-case meny som hanterar menyval och anropar metoder därefter
                switch(menuOption)
                {
                    case 1:
                        Fetch();  
                        break;
                    case 2:
                        Feed();
                        break;
                    case 3:
                        ListPets(true);  //ListPets anropas med bool-värdet true för att skriva ut djuren som objekt
                        break;
                    case 4:
                        CheckBall();
                        break;
                    case 0:
                        Console.WriteLine("Välkommen tillbaka!");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Välj endast ett alternativ från menyn!");
                        Console.WriteLine();
                        break;
                }
            } while (menuOption != 0);
        }

        //Metoden Fetch används för att leka med djur
        public void Fetch()
        {
            int animalOption;  //Menyval för djur
            int ballOption;  //Menyval för boll            
            int ballNr = 0;  //Håller koll på bollarnas plats i menyn
            bool ballIntact = true;  //Håller koll på om bollen är hel

            Console.WriteLine("Här kan {0} leka med ett av sina djur!", name);
            Console.WriteLine("Välj ett djur!");  
            
            ListPets(false);  //ListPets anropas med bool-värdet false för att bara skriva ut djuren efter namn

            animalOption = ReadInput(pets.Count()) - 1;  //Metoden ReadInput anropas med metoden pets.Count, som räknar elementen för maxvärde (Här antal djur i listan)
            
            Console.WriteLine("Vilken boll ska {0} kasta till {1}?", name, pets[animalOption].GetName());
            Console.WriteLine();

            Console.WriteLine("BOLLAR");
            Console.WriteLine("-----------------");

            foreach(Ball ball in balls)  //foreach som loopar igenom bollmenyn
            {
                Console.WriteLine("{0}. {1}", ++ballNr, ball.GetBallType());  //ballNr används här för att skriva ut bollens plats i listan och GetBallType metoden anropas för att hämta bolltyp
            }
            Console.WriteLine("-----------------");

            ballOption = ReadInput(balls.Count) - 1;  //Metoden ReadInput anropas med metoden balls.Count, som räknar elementen för maxvärde (Här antal bollar i listan)            

            if (balls[ballOption].GetQuality() < 1) //Om bollens kvalité är under 1 så är den sönder
            {               
                Console.WriteLine("Bollen är sönder, vill du köpa en ny?");
                Console.Write("Skriv in (ja) om du vill köpa en ny boll: ");
                string answer = Console.ReadLine();
                Console.WriteLine();

                if (answer.Equals("ja"))  //Om "ja" matas in så köper man en ny boll
                {
                    Ball newBall = NewBall(balls[ballOption]);  //Här skapas ett nytt objekt som en kopia av den trasiga bollen genom metoden NewBall med vald boll som in-parameter
                    balls.RemoveAt(ballOption);  //Ta bort trasig boll
                    balls.Insert(ballOption, newBall);  //Lägg till ny boll på samma position
                    Console.WriteLine("{0} har nu en ny {1}!", name, newBall.GetBallType());
                }

                else
                {                    
                    Console.WriteLine("Det går inte att leka med en trasig boll!");
                    ballIntact = false;  //ballintact får värdet false för den är sönder
                }

                Console.WriteLine();
            }            

            if (ballIntact)  //Om bollen är hel...
            {               
                Console.WriteLine("{0} kastar {1}en till {2}!", name, balls[ballOption].GetBallType(), pets[animalOption].GetName());
                pets[animalOption].Interact(balls[ballOption]);  //Anrop av metoden Interact för det valda djuret, med den valda bollen som in-parameter                
            }
            
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn:");
            Console.ReadKey(true);
        }

        //Metoden Feed används för att mata djur
        public void Feed()
        {
            int animalOption;  //Menyval för djur
            int foodOption;  //Menyval för mat
            int foodNr = 0;  //Håller koll på matens plats i menyn

            Console.WriteLine("Här kan {0} mata sina djur!", name);
            Console.WriteLine("Välj ett djur som ska matas.");            
            ListPets(false);  //ListPets anropas med värdet false för att skriva ut djurens namn (inte som objekt)

            animalOption = ReadInput(pets.Count()) - 1;  //Metoden ReadInput anropas med pets.Count, som räknar elementen för maxvärde (Här antal djur i listan)            

            Console.WriteLine("Vilken mat ska {0} få?", pets[animalOption].GetName());
            Console.WriteLine();
            Console.WriteLine("SKAFFERIET");
            Console.WriteLine("-----------------");

            foreach(Food food in foods)  //foreach som loopar igenom listan för foods (skafferiet)
            {
                Console.WriteLine("{0}. {1}", ++foodNr, food.GetFoodType());  //foodNr används här för att skriva ut matens plats i menyn
            }

            Console.WriteLine("-----------------");            

            foodOption = ReadInput(foods.Count()) - 1;  //Metoden ReadInput anropas med foods.Count, som räknar elementen för maxvärde (Här antal maträtter i listan)            

            Console.WriteLine("{0} ger {1} lite {2}", name, pets[animalOption].GetName(), foods[foodOption].GetFoodType());
            pets[animalOption].Eat(foods[foodOption]);  //Anrop av metoden Eat för det valda djuret, med den valda maten som in-parameter

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn:");
            Console.ReadKey(true);
        }

        //Metoden ListPets skriver ut djuren som objekt eller bara deras namn och typ beroende på bool-variabeln petObject
        //Metoden återanvänds för att programmet inte ska behöva loopa igenom listan över djur på flera ställen
        public void ListPets(bool petObject)
        {
            int animalNr = 0;  //Håller koll på djurens plats i menyn

            Console.WriteLine();
            Console.WriteLine("DJUR");
            Console.WriteLine("----------------------------");

            foreach (Animal animal in pets)
            {
                if (petObject == true)  //Om metoden anropats med true som in-parameter så skrivs djuren ut som objekt
                {
                    Console.WriteLine(animal);
                }

                else  //annars skrivs djurens namn och typ ut
                {
                    Console.WriteLine("{0}. {1}en {2}", ++animalNr, animal.GetAnimalType(), animal.GetName());  //animalNr används här för att skriva ut djurens plats i menyn
                }
            }
            Console.WriteLine("----------------------------");

            if (petObject == true)  //Om metoden har anropats mesd true som inparameter (från menyn) så ska man sedan kunna gå tillbaka till menyn 
            {
                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn:");
                Console.ReadKey(true);
            }
        }

        //Metoden CheckBall används för att kolla utseende och kvalité på bollar
        public void CheckBall()
        {
            int ballOption;  //Menyval för boll
            int ballNr = 0;  //Håller reda på bollarnas plats i menyn

            Console.WriteLine("Här kan {0} kolla utseende och kvalité på sina bollar!", name);
            Console.WriteLine("Vilken boll ska kollas?");
            Console.WriteLine();

            Console.WriteLine("BOLLAR");
            Console.WriteLine("-----------------");

            foreach (Ball ball in balls)  //foreach för att loopa genom listan balls
            {
                Console.WriteLine("{0}. {1}", ++ballNr, ball.GetBallType());
            }
            Console.WriteLine("-----------------");

            ballOption = ReadInput(balls.Count()) - 1;  //Metoden ReadInput anropas med balls.Count, som räknar elementen för maxvärde (Här antal bollar i listan)            

            Console.WriteLine(balls[ballOption]);  //Objektet för vald boll skrivs ut
            
            if(balls[ballOption].GetQuality() < 1)  //Om bollens kvalité är under 1 så är den sönder och man kan då skaffa en ny
            {
                Console.WriteLine("Bollen är sönder!");
                Console.WriteLine("Vill du köpa en ny?");
                Console.WriteLine();
                Console.Write("Skriv in (ja) om du vill köpa en ny boll: ");
                string answer = Console.ReadLine();
                Console.WriteLine();

                if (answer.Equals("ja"))  //Om "ja" har matats in så skaffar man en ny boll
                {
                    Ball newBall = NewBall(balls[ballOption]);  //Här skapas ett nytt objekt av en boll som en kopia av den trasiga bollen genom metoden NewBall 
                    balls.RemoveAt(ballOption);  //Ta bort trasig boll från listan
                    balls.Insert(ballOption, newBall);  //Lägg till ny boll på samma plats som den trasiga
                    Console.WriteLine("{0} har nu en ny {1}!", name, newBall.GetBallType());
                }

                else
                {
                    Console.WriteLine("Bollen är fortfarande sönder");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn:");
            Console.ReadKey(true);
        }

        //Metoden NewBall används för att skapa nya bollar och anropas med den trasiga bollen som in-parameter
        public Ball NewBall(Ball ball)
        {            
            Ball newBall = new Ball(ball);  //Ny boll skapas som en kopia av den gamla bollen genom copy-konstruktor i Ball klassen            

            return newBall; //Den nya bollen returneras           
        }

        //Metoden ReadInput används som felhantering
        //Metoden anropas med ett maxvärde för inmatningen för att kontrollera att värdet inte är för högt
        public int ReadInput(int max)
        {
            int parsedValue = 0;  //Variabel för felhanterat värde som ska returneras
            bool loop = true;  //Bool-variabeln loop styr loopen som felhanterar inmatning

            //Felhanteringen loopas här för att användaren ska få försöka igen vid fel 
            do
            {
                try
                {
                    parsedValue = int.Parse(Console.ReadLine());  //parsedValue får här sitt värde genom inmatning                   
                }
                catch
                {
                    Console.WriteLine("Du får bara skriva in siffror!");
                    Console.WriteLine("Försök igen!");
                    continue;  //continue används för att avsluta pågående varv i loopen
                }               

                if(parsedValue < 0)
                {
                    Console.WriteLine("Du skrev in en för låg siffra!");
                    Console.WriteLine("Försök igen!");
                }

                else if(parsedValue > max)
                {
                    Console.WriteLine("Du skrev in en för hög siffra!");
                    Console.WriteLine("Försök igen!");
                }

                else
                {
                    loop = false;
                }

            } while (loop);

            return parsedValue;  //Felhanterat värde returneras
        }
    }
}
