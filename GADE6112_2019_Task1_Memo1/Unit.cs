using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSpanos_Task3_19013035
{
    [Serializable] public abstract class Unit
    {
        //Protected variables for other classes to inherit
        protected int xPos,
                      yPos,
                      health,
                      maxHealth,
                      speed,
                      attack,
                      attackRange,
                      faction;
        protected string symbol;
        protected bool isAttacking;
        protected string name;

        //Abstract methods 
        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other, Building otherino);
        public abstract (Unit, int ) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();
    }
}
