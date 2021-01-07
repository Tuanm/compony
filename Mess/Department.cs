using System.Collections.Generic;
using System.Drawing;


namespace Mess {
    class DepartmentInfo {
        public static DepartmentInfo Empty = new DepartmentInfo() {
            Number = 0,
            Head = string.Empty
        };
        public int Number;
        public int Upper;
        public string Head;
        public List<DepartmentInfo> SubDepartments;

        public DepartmentInfo() {
            SubDepartments = new List<DepartmentInfo>();
            Head = string.Empty;
        }

        public override string ToString() {
            var data = $"\r\n"
                + $"Number: {Number}\r\n"
                + $"Upper: {Upper}\r\n"
                + $"Head: {Head}\r\n"
                + $"Count: {SubDepartments.Count}\r\n";

            return data;
        }

        public bool Contains(DepartmentInfo department) {
            foreach (DepartmentInfo subdepartment in SubDepartments) {
                if (subdepartment.Number == department.Number) return true;
                if (subdepartment.Contains(department)) return true;
            }
            return false;
        }

        public bool Append(DepartmentInfo info) {
            foreach (var department in SubDepartments) {
                if (department.Number.Equals(info.Number)) {
                    return false;
                }
            }
            SubDepartments.Add(info);
            info.Upper = Number;
            return true;
        }

        public bool Remove(DepartmentInfo info) {
            foreach (var department in SubDepartments) {
                if (department.Number.Equals(info.Number)) {
                    SubDepartments.Remove(department);
                    info.Upper = 0;
                    return true;
                }
            }
            return false;
        }
    }

    class Department {
        private DepartmentInfo _info;
        private List<Member> _members;
        public DepartmentInfo Info { get => _info; }
        public List<Member> Members { get => _members; }
        public int Number { get => _info.Number; }
        public int Count { get => _info.SubDepartments.Count; }
        public static int Capacity = 20;
        
        public Department(DepartmentInfo info) {
            _info = info;
            _members = new List<Member>();
        }

        public bool Add(Member member) {
            foreach (var mem in _members) {
                if (mem.Name.Equals(member.Name)) return false;
            }
            if (_members.Count < Department.Capacity) {
                _members.Add(member);
                return true;
            }
            return false;
        }

        public bool Remove(Member member) {
            foreach (var mem in _members) {
                if (mem.Name.Equals(member.Name)) {
                    _members.Remove(mem);
                    return true;
                }
            }
            return false;
        }

        public bool Add(DepartmentInfo department) {
            return _info.Append(department);
        }

        public bool Add(Department department) {
            return _info.Append(department.Info);
        }

        public bool Remove(DepartmentInfo department) {
            return _info.Remove(department);
        }

        public bool Contains(Department department) {
            return _info.Contains(department.Info);
        }

        public override string ToString() {
            return Number.ToString();
        }
    }


    class Door {
        public Point Location;
        public int Number;
        public Image DoorImage;
        public bool IsUpperDoor;

        public Door(bool isUpperDoor = false) {
            IsUpperDoor = isUpperDoor;
            Location = Point.Empty;
            Number = 0;
            DoorImage = Service.GetDoorImage(IsUpperDoor);
        }
    }
}
