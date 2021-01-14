using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess
{
    public class MilkTea : IMilkTea
    {
        public int Cost()
        {
            return 20000;
        }
        public string Name()
        {
            return "Milk Tea";
        }
    }
}
