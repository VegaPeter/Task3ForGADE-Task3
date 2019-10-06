using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSpanos_Task3_19013035
{
    [Serializable]
    public class WizardUnit : Unit
    {
        //Fields that the WizardUnit class needs access to
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
            set { base.symbol = value; }
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


    }
}
