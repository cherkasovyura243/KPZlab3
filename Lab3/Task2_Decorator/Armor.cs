using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task2_Decorator
{
    public class Armor : InventoryDecorator
    {
        public Armor(Hero hero) : base(hero)
        {
        }

        public override string GetDescription()
        {
            return hero.GetDescription() + " + броня";
        }

        public override int GetPower()
        {
            return hero.GetPower() + 30;
        }
    }
}
