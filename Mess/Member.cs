using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mess {
    enum MemberStatus {
        Stand,
        MoveLeft,
        MoveRight
    }

    class MemberInfo {
        public static MemberInfo Empty = new MemberInfo() {
            Name = string.Empty,
            Email = string.Empty,
            Birthday = string.Empty,
            Address = string.Empty,
            Position = MemberPosition.None,
            Location = Point.Empty
        };
        public static int Capacity = Mess.Department.Capacity - 1;
        public string Name;
        public string Email;
        public string Birthday;
        public string Address;
        public MemberPosition Position;
        public int Department;
        public Point Location;
        public List<MemberInfo> SubMembers;

        public MemberInfo() {
            Name = Email = Birthday = Address = string.Empty;
            Position = MemberPosition.Employee;
            Location = Point.Empty;
            SubMembers = new List<MemberInfo>();
        }

        public override string ToString() {
            var data = "\r\n"
                + $"Name: {Name}\r\n"
                + $"Email: {Email}\r\n"
                + $"Birthday: {Birthday}\r\n"
                + $"Address: {Address}\r\n"
                + $"Position: {Position}\r\n"
                + $"Workspace: {Department}\r\n";

            return data;
        }

        public bool Higher(MemberInfo member) {
            if (Name.Equals(member.Name)) return true;
            foreach (var submember in SubMembers) {
                if (submember.Name.Equals(member)) return true;
                if (submember.Higher(member)) return true;
            }
            return false;
        }

        public void Append(MemberInfo info) {
            SubMembers.Add(info);
        }

        public bool Append(MemberInfo info, string head) {
            if (Name.Equals(head)) {
                if (SubMembers.Count < Capacity) {
                    SubMembers.Add(info);
                    return true;
                }
                return false;
            }
            else {
                foreach (var member in SubMembers) {
                    if (member.Append(info, head)) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Remove(string name) {
            foreach (var submemner in SubMembers) {
                if (submemner.Name.Equals(name)) {
                    SubMembers.Remove(submemner);
                    return true;
                }
            }
            foreach (var submemner in SubMembers) {
                if (submemner.Remove(name)) {
                    return true;
                }
            }
            return false;
        }
    }

    abstract class Member {
        protected Department _department;
        protected MemberInfo _info;
        public MemberInfo Info { get => _info; }
        public string Name { get => _info.Name; }
        public Point Location {
            get => _info.Location;
            set => _info.Location = value;
        }
        public MemberStatus Status;
        public Point Target = Point.Empty;
        
        public Member(MemberInfo info) {
            _info = info;
        }

        public override string ToString() {
            return Name;
        }

        public void SetInfo(string email, string birthday, string address) {
            _info.Email = email;
            _info.Birthday = birthday;
            _info.Address = address;
        }

        public void SetInfo(List<MemberInfo> submembers) {
            _info.SubMembers = submembers;
        }

        public int Current {
            get { 
                if (_department != null) {
                    return _department.Number;
                }
                return -1;
            }
        }

        public MemberStatus Move(int step = 5, int range = 20) {
            if (Target != Point.Empty) {
                if (Math.Abs(Location.X - Target.X) > range) {
                    if (Location.X < Target.X) {
                        Location = new Point() {
                            X = Location.X + step
                        };
                        Status = MemberStatus.MoveRight;
                    }
                    else {
                        Location = new Point() {
                            X = Location.X - step
                        };
                        Status = MemberStatus.MoveLeft;
                    }
                }
                else {
                    Target = Point.Empty;
                    Status = MemberStatus.Stand;
                }
            }
            return Status;
        }

        public abstract bool Higher(Member member);
        public abstract bool Join(Department department);
        public abstract bool Hire(MemberInfo info, string head);
        public abstract bool Fire(string name);
        public abstract bool Fire(Member member);
        public abstract void Ask(Member member, ref List<Member> asked);
    }
}
