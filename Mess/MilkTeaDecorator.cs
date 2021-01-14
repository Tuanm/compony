using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess
{
        public abstract class MilkTeaDecorator : IMilkTea
        {
            private IMilkTea _milkTea;
            protected MilkTeaDecorator(IMilkTea wrappee)
            {
                _milkTea = wrappee;
            }
/*            public virtual int Cost()
            {
                return _milkTea.Cost();
            }*/
            public virtual string Name()
            {
                return _milkTea.Name();
            }
        }
    }
