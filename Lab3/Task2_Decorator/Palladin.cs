using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Task2_Decorator
{
    public class Palladin : Hero
    {
        public override string GetDescription()
        {
            return "Паладин";
        }

        public override int GetPower()
        {
            return 120;
        }
    }
}
