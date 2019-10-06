using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Peter_Spanos_19013035_Task2
{
    [Serializable] public class RangedUnit : Unit
    {
        public bool IsDead { get; set; }

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
            get { return base.maxHealth; }
        }

        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }
        
        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }

        public int Faction
        {
            get { return base.faction; }
        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol= value; }
        }

        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }

        public RangedUnit(int x, int y, int h, int s, int a, int ar, int f, string sy)
        {
            XPos = x;
            YPos = y;
            Health = h;
            base.maxHealth = h;
            Speed = s;
            Attack = a;
            AttackRange = ar;
            base.faction = f;
            Symbol = sy;
            Name = "Archer";
            IsAttacking = false;
            IsDead = false; 
        }

        public override void Death()
        {
            symbol = "_";
            IsDead = true;
        }

        public override void Move(int dir)
        {
            switch(dir)
            {
                case 0: YPos--;  break; //North
                case 1: XPos++; break; //East
                case 2: YPos++;  break; //South
                case 3: XPos--;  break; //West
                default: break;
            }
        }

        public override void Combat(Unit attacker)
        {
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.Attack - ru.AttackRange);
            }

            if(Health <= 0)
            {
                Death(); //Me_IRL
            }
        }

        public override bool InRange(Unit other)
        {
            int distance = 0;
            int otherX = 0;
            int otherY = 0;
            if (other is MeleeUnit)
            {
                otherX = ((MeleeUnit)other).XPos;
                otherY = ((MeleeUnit)other).YPos;
            }
            else if (other is RangedUnit)
            {
                otherX = ((RangedUnit)other).XPos;
                otherY = ((RangedUnit)other).YPos;
            }

            distance = Math.Abs(XPos - otherX) + Math.Abs(YPos - otherY);
            if(distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override (Unit, int) Closest(List<Unit> units)
        {
            int shortest = 100;
            Unit closest = this;
            //Closest Unit and Distance                    
            foreach (Unit u in units)
            {
                if (u is MeleeUnit)
                {
                    MeleeUnit otherMu = (MeleeUnit)u;
                    int distance = Math.Abs(this.XPos - otherMu.XPos)
                               + Math.Abs(this.YPos - otherMu.YPos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherMu;
                    }
                }
                else if (u is RangedUnit)
                {
                    RangedUnit otherRu = (RangedUnit)u;
                    int distance = Math.Abs(this.XPos - otherRu.XPos)
                               + Math.Abs(this.YPos - otherRu.YPos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherRu;
                    }
                }

            }
            return (closest, shortest);
        }

        public override string ToString()
        {
            string temp = "";
            temp += "Name: " + name;
            temp += " Ranged: ";
            temp += " {" + Symbol + "}";
            temp += " (" + XPos + "," + YPos + ") ";
            temp += Health + ", " + Attack + ", " + AttackRange + ", " + Speed;
            temp += (IsDead ? " DEAD!" : " ALIVE!");
            return temp;
        }

    }
}
