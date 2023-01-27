using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eggClicker
{
    internal class ClickerUpgrades
    {
        public string ClickerU { get; set; }
        public int ClickerUCost { get; set; }
        public override string ToString()
        {
            return ClickerU + " (" + ClickerUCost + " Eggs)";
        }
    }
}
