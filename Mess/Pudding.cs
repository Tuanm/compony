using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess
{
    public class Pudding : MilkTeaDecorator
    {
        public Pudding(IMilkTea wrappee) : base(wrappee)
        {
            //
        }
/*        public override int Cost()
        {
            return 5000 + base.Cost();
        }*/
        public override string Name()
        {
            return base.Name() + " add pudding";
        }
    }
}
