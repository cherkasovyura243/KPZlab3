using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task2_Decorator
{
    public abstract class InventoryDecorator : Hero
    {
        protected Hero hero;

        public InventoryDecorator(Hero hero)
        {
            this.hero = hero;
        }
    }
}
