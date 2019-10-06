﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peter_Spanos_19013035_Task2
{
    [Serializable] public abstract class Unit
    {
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

        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
        public abstract (Unit, int ) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();
    }
}
