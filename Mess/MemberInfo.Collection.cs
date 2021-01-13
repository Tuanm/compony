using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess {
    partial class MemberInfo : ICollection {
        public IIterator CreateIterator() {
            return new MemberIterator(this);
        }
    }
}
