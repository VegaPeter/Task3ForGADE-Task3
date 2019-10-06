using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peter_Spanos_19013035_Task2
{
    
    [Serializable] public class ResourceBuilding : Building
    {
        //Constructor that catches all the variables to use in their own class
        public ResourceBuilding(int x, int y, int h, int f, string sy, bool des)
        {
            xPos = x;
            yPos = y;
            health = h;
            faction = f;
            symbol = sy;
            isDestroyed = des;
        }

        //Additional variables to be used in the class
        private string resourceType = "Grog";
        private int resourcesGenerated = 0;
        private int resourcesGeneratedPerRound;
        private int resourcePool = 100;

        //Fields that the class requires access to 
        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }

        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public int MaxHealth
        {
            get { return base.health; }
        }

        public int Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        public bool IsDestroyed { get; set; }

        public override void Destruction()
        {
            symbol = ",,,";
            isDestroyed = true;
        }

        //Override string to send unit information
        public override string ToString()
        {
            string temp = "";
            temp += "Resource Building: ";
            temp += " Resource Type: " + resourceType;
            temp += " Symbol: {" + symbol + "}";
            temp += " Position: (" + xPos + "," + yPos + ")";
            temp += " Faction: " + faction + " Health: " + health;
            temp += (isDestroyed ? " DESTROYED!" : " STILL STANDING!");
            return temp;
        }

        //Method that handles the round to round changes for the building
        public int ResourceTick()
        {
            resourceType = "Grog"; //Resource name
            resourcesGeneratedPerRound = 10; //Resource per tick
            resourcePool -= resourcesGeneratedPerRound; //Leftover resources
            resourcesGenerated += resourcesGeneratedPerRound; //Total resources in stockpile

            return resourcesGenerated;
        }
    }
}
