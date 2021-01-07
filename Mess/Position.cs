using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mess {
    enum MemberPosition {
        HeadOfDepartment,
        Employee,
        None
    }

    class HeadOfDepartment : Member {
        protected List<Member> _members;

        public HeadOfDepartment(MemberInfo info) : base(info) {
            _info.Position = MemberPosition.HeadOfDepartment;
            _members = new List<Member>();
            InitializeMembers();
        }

        protected void InitializeMembers() {
            foreach (var subinfo in _info.SubMembers) {
                var member = Service.GetMember(subinfo.Name);
                if (member != null) {
                    _members.Add(member);
                }
            }
        }

        public override bool Higher(Member member) {
            if (member == null) return false;
            return Info.Higher(member.Info);
        }

        public override bool Join(Department department) {
            if (department == null) return false;
            if (department.Add(this)) {
                if (_department != null) {
                    _department.Remove(this);
                }
                _department = department;
                return true;
            }
            return false;
        }

        public override bool Hire(MemberInfo info, string head) {
            return _info.Append(info, head);
        }

        public override bool Fire(string name) {
            return _info.Remove(name);
        }

        public override bool Fire(Member member) {
            if (_members.Contains(member)) {
                _members.Remove(member);
                return true;
            }
            return false;
        }

        public override void Ask(Member member, ref List<Member> asked) {
            if (!member.Higher(this)) return;
            lock (this) {
                foreach (var subinfo in _info.SubMembers) {
                    var mem = Service.GetMember(subinfo.Name);
                    if (mem != null) {
                        mem.Ask(this, ref asked);
                    }
                }
                if (!asked.Contains(this)) asked.Add(this);
            }
        }
    }

    class Employee : Member {
        public Employee(MemberInfo info) : base(info) {
            info.Position = MemberPosition.Employee;
        }

        public override bool Higher(Member member) {
            return false;
        }

        public override bool Join(Department department) {
            if (department == null) return false;

            if (_department != null) {
                _department.Remove(this);
            }

            if (department.Add(this)) {
                _department = department;
                return true;
            }
            return false;
        }

        public override bool Hire(MemberInfo info, string head) {
            return false;
        }

        public override bool Fire(string name) {
            return false;
        }

        public override bool Fire(Member member) {
            return false;
        }

        public override void Ask(Member member, ref List<Member> asked) {
            if (!member.Higher(this)) return;
            if (!asked.Contains(this)) asked.Add(this);
        }
    }
}
