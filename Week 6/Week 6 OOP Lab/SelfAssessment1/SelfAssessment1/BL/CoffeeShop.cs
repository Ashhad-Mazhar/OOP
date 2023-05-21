using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment1.BL
{
    class CoffeeShop
    {
        public CoffeeShop(string name)
        {
            this.name = name;
        }
        public string name;
        public List<MenuItem> menu = new List<MenuItem>();
        List<string> orders = new List<string>();
    }
}
