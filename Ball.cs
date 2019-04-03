using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Ball är mallen för att skapa boll-objekt
    class Ball
    {
        private string type;
        private string color;
        private int quality;  //Bollens kvalité som avgör när bollen går sönder
        static int FOOTBALL_QUALITY = 10;  //Här bestäms kvalitén för de olika bollarna
        static int TENNISBALL_QUALITY = 5;
        static int YARNBALL_QUALITY = 2;

        //Huvudkonstruktor för klassen
        public Ball(string type, string color)
        {
            this.type = type;
            this.color = color;

            if(type.Equals("Fotboll"))
            {
                quality = FOOTBALL_QUALITY;
            }
            else if (type.Equals("Tennisboll"))
            {
                quality = TENNISBALL_QUALITY;
            }
            else if (type.Equals("Garnboll"))
            {
                quality = YARNBALL_QUALITY;
            }
        }       

        //Copy konstruktor som skapar kopior av bollar för att ersätta gamla "trasiga"
        //Konstruktorn är överlagrad och anropar huvudkonstruktorn med den gamla bollens värden för att skapa en ny boll
        public Ball(Ball ball) : this(ball.GetBallType(), ball.GetColor())
        {           
        }       

        //Metoden GetBallType används för att hämta bolltyp
        public string GetBallType()
        {
            return type;
        }

        //Metoden GetColor används för att hämta bollens färg
        public string GetColor()
        {
            return color;
        }

        //Metoden GetQuality används för att hämta bollens kvalité
        public int GetQuality()
        {
            return quality;
        }

        //Metoden LowerQuality används för att sänka kvalitén på bollen när den har använts
        public void LowerQuality(int lower)
        {
            quality -= lower;  //Bollens kvalité minskar            

            if(quality < 1)  //Om bollens kvalité är under 1, alltså noll, så ska den inte kunna minskas mer
            {
                quality = 0;  //Bollens kvalité kan inte vara under noll
                Console.WriteLine("{0}en är nu sönder", type);                
            }            
        }

        //ToString metod för utskrift av bollobjekt
        public override string ToString()
        {
            return string.Format("Denna {0}en är {1} och har {2} i kvalité", type, color, quality);
        }
    }
}
