using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mess {
    class MemberIterator : IIterator {
        List<MemberInfo> _memInfo;
        Stack<MemberInfo> _stackParent;
        Stack<MemberInfo> _stackChild;
        int _current = 0;
        public MemberIterator(MemberInfo m) {
            this._memInfo = m.SubMembers;
            Stack<MemberInfo> _stackParent = new Stack<MemberInfo>();
            Stack<MemberInfo> _stackChild = new Stack<MemberInfo>();
            this._stackParent = _stackParent;
            this._stackChild = _stackChild;
        }

        public int Count {
            get {
                return _memInfo.Count;
            }
        }

        public object First() {
            _current = 0;
            _stackChild.Push(_memInfo[_current]);
            return _memInfo[_current];
        }

        public bool IsDone() {
            return _current >= _memInfo.Count;
        }

        public object Next() {
            _current += 1;
            if (!IsDone()) {
                _stackChild.Push(_memInfo[_current]);
                return _memInfo[_current];
            }
            else {
                if(_stackParent.Count > 0) {
                    while(_stackParent.Count > 0) {
                        MemberInfo temp = _stackParent.Pop();
                        if (temp.SubMembers.Count > 0) {
                            _memInfo = temp.SubMembers;
                            _current = 0;
                            return _memInfo[_current];
                        }
                    }
                    return null;
                }
                else {
                    if (_stackChild.Count > 0) {
                        while (_stackChild.Count > 0) {
                            _stackParent.Push(_stackChild.Pop());
                        }
                        MemberInfo temp2 = _stackParent.Pop();
                        if (temp2.SubMembers.Count > 0) {
                            _memInfo = temp2.SubMembers;
                            _current = 0;
                            return _memInfo[_current];
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
        }
    }
}
