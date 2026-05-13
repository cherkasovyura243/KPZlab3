using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task2_Decorator
{
    public class Mage : Hero
    {
        public override string GetDescription()
        {
            return "Маг";
        }

        public override int GetPower()
        {
            return 80;
        }
    }
}
