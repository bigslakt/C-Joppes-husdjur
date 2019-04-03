using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppes_djurfamilj
{
    //Klassen Food är mallen för att skapa mat-objekt
    class Food
    {
        private string type;  //Typ av mat

        //Konstruktor för klassen
        public Food(string type)
        {
            this.type = type;
        }

        //Metoden GetFoodType används för att hämta mat-typ
        public string GetFoodType()
        {
            return type;
        }
    }
}
