using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSpanos_Task3_19013035
{
    [Serializable] public abstract class Building
    {
        //Variables for other classes to inherit
        protected int xPos,
                      yPos,
                      health,
                      maxHealth,
                      faction;
        protected string symbol;
        protected bool isDestroyed;

        //Abstract method for other buildings to inherit
        public abstract void Destruction();
        public abstract override string ToString();
    }
}
