using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess
{
    public class Fruit : MilkTeaDecorator
    {
        public Fruit(IMilkTea wrappee) : base(wrappee)
        {
            //
        }
/*        public override int Cost()
        {
            return 5000 + base.Cost();
        }*/
        public override string Name()
        {
            return base.Name()+" add fruit";
        }
    }
}
