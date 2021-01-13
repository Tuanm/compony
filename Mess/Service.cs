using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Mess {
    static class Service {
        public static Member MilkteaMan;
        private static string _source = @"../data/data.json";
        private static Dictionary<Member, ImageService> _members = new Dictionary<Member, ImageService>();
        private static List<Department> _departments = new List<Department>();
        private static Member _root;
        private static Dictionary<Member, Bot> _bots = new Dictionary<Member, Bot>();
        private static List<Workspace> _workspaces;

        public static void Start() {
            Load();
            MilkteaMan = new Employee(new MemberInfo() {
                Name = "hello",
                Location = new Point(300, 0)
            });
        }

        public static void Terminate() {
            Store();
        }

        private static void Store() {
            string data = JsonConvert.SerializeObject(_root.Info,
                Formatting.Indented);
            File.WriteAllText(_source, data);
        }

        private static void Load() {
            string data = File.ReadAllText(_source);
            var info = JsonConvert.DeserializeObject<MemberInfo>(data);
            var root = new HeadOfDepartment(info);
            var department = new Department(new DepartmentInfo() {
                Number = root.Info.Department,
                Upper = 0,
                Head = root.Name
            });
            Create(root, department);
            _members.Add(root, new ImageService());
            _departments.Add(department);
            _root = root;
            _workspaces = new List<Workspace>();
        }

        private static void Create(Member member, Department department) {
            foreach (var subinfo in member.Info.SubMembers) {
                Member submember;
                if (subinfo.Position == MemberPosition.HeadOfDepartment) {
                    submember = new HeadOfDepartment(subinfo);
                    var subdepartment = new Department(new DepartmentInfo() {
                        Number = submember.Info.Department,
                        Upper = member.Info.Department,
                        Head = submember.Name
                    });
                    Create(submember, subdepartment);
                    department.Add(subdepartment);
                    _departments.Add(subdepartment);
                }
                else {
                    submember = new Employee(subinfo);
                }
                _members.Add(submember, new ImageService());
            }
        }

        public static Workspace GetWorkspace(string name) {
            var member = GetMember(name);
            var number = member.Current;
            if (number == -1) {
                return null;
            }
            var workspace = new Workspace(name, number);
            _workspaces.Add(workspace);
            return workspace;
        }

        public static Department GetDepartment(int number) {
            foreach (var department in _departments) {
                if (department.Number == number) return department;
            }
            return null;
        }

        public static Member GetMember(string name) {
            foreach (var member in _members.Keys) {
                if (member.Name.Equals(name)) return member;
            }
            return null;
        }

        private static bool TryCreateMember(MemberInfo info,
            out Member mem) {
            mem = null;
            foreach (var member in _members.Keys) {
                if (member.Name.Equals(info.Name)) return false;
            }
            if (info.Position == MemberPosition.HeadOfDepartment) {
                mem = new HeadOfDepartment(info);
            }
            else {
                mem = new Employee(info);
            }
            return true;
        }

        private static bool TryCreateDepartment(DepartmentInfo info,
            out Department dep) {
            dep = null;
            foreach (var department in _departments) {
                if (department.Number == info.Number) return false;
            }
            dep = new Department(info);
            return true;
        }

        public static bool[] TryAdd(MemberInfo me, int upper = 0) {
            bool[] result = new bool[] {
                false, false
            };
            bool hasJoined = false;
            if (TryCreateMember(me, out Member member)) {
                result[0] = true;
                if (member.Info.Position == MemberPosition.HeadOfDepartment) {
                    var de = new DepartmentInfo() {
                        Number = me.Department,
                        Upper = upper,
                        Head = me.Name
                    };
                    if (TryCreateDepartment(de, out Department department)) {
                        GetDepartment(upper).Add(de);
                        result[1] = true;
                        _members.Add(member, new ImageService());
                        _departments.Add(department);
                        hasJoined = member.Join(department);
                    }
                }
                else {
                    result[1] = true;
                    _members.Add(member, new ImageService());
                    hasJoined = member.Join(GetDepartment(upper));

                }
                if (result[0] && result[1]) {
                    if (hasJoined) {
                        _bots.Add(member, new Bot(member) {
                            IsActivated = true
                        });
                        UpdateWorkspaces(upper);
                    }
                }
            }
            return result;
        }

        public static void RemoveMember(Member member) {
            var number = member.Current;
            var department = GetDepartment(number);
            _members.Remove(member);
            _bots.Remove(member);
            department.Remove(member);
            if (member.Name.Equals(department.Info.Head)) {
                RemoveDepartment(department);
            }
            else {
                UpdateWorkspaces(number);
            }
        }

        private static void RemoveDepartment(Department department) {
            var upper = GetDepartment(department.Info.Upper);
            for (var index = 0; index < department.Members.Count; index++) {
                var member = department.Members[index];
                member.Join(upper);
            }
            _departments.Remove(department);
            upper.Remove(department.Info);
            UpdateWorkspaces(upper.Number);
        }

        public static void UpdateWorkspaces(int number = -1) {
            foreach (var workspace in _workspaces) {
                if (workspace.Number == number) {
                    workspace.UpdateScene();
                }
            }
        }

        public static void RemoveWorkspace(Workspace workspace) {
            if (_workspaces.Contains(workspace)) {
                _workspaces.Remove(workspace);
                workspace.Close();
            }
        }

        public static void JoinAll() {
            _bots = new Dictionary<Member, Bot>();
            foreach (var member in _members.Keys) {
                _bots.Add(member, new Bot(member) {
                    IsActivated = true
                });
                var department = GetDepartment(member.Info.Department);
                if (!member.Join(department)) {
                    foreach (var de in _departments) {
                        if (member.Join(de)) {
                            break;
                        }
                    }
                }
            }
        }

        public static void DisableAuto(List<Member> members = null) {
            foreach (var member in members) {
                _bots[member].IsActivated = false;
            }
        }

        public static void Auto(int number = 0) {
            foreach (var bot in _bots.Values) {
                if (bot.Number == number) bot.GoAround();
            }
        }

        public static Image GetImage(Member member) {
            return _members[member].Get(member.Status);
        }

        public static Image GetCopiedImage(Member member) {
            return _members[member].Copy;
        }

        public static Image GetDoorImage(bool isUpperDoor = false) {
            if (isUpperDoor) {
                return ImageService.UpperDoorImage;
            }
            return ImageService.DoorImage;
        }

        public static Image GetMilkteaManImage() {
            return ImageService.MilkteaManImage;
        }

        public static Image GetMilkteaMachineImage() {
            return ImageService.MilkteaMachineImage;
        }

        class ImageService {
            public static Image DoorImage {
                get {
                    return Image.FromFile(@"../img/door.png");
                }
            }

            public static Image UpperDoorImage {
                get {
                    return Image.FromFile(@"../img/upper_door.png");
                }
            }

            public static Image MilkteaMachineImage {
                get {
                    return Image.FromFile(@"../img/milkteamachine.png");
                }
            }

            public static Image MilkteaManImage {
                get {
                    return Image.FromFile(@"../img/milkteaman.png");
                }
            }

            public static List<Image> MovingRight = new List<Image>() {
                Image.FromFile(@"../img/employee_m_r_1.png"),
                Image.FromFile(@"../img/employee_m_r_2.png")
            };
            public static List<Image> MovingLeft = new List<Image>() {
                Image.FromFile(@"../img/employee_m_l_1.png"),
                Image.FromFile(@"../img/employee_m_l_2.png")
            };
            public static List<Image> StandingRight = new List<Image>() {
                Image.FromFile(@"../img/employee_s_r_1.png"),
                Image.FromFile(@"../img/employee_s_r_2.png")
            };
            public static List<Image> StandingLeft = new List<Image>() {
                Image.FromFile(@"../img/employee_s_l_1.png"),
                Image.FromFile(@"../img/employee_s_l_2.png")
            };
            private MemberStatus _status = MemberStatus.Stand;
            private int _current = 0;
            private Image _img = StandingRight[0];
            public Image Copy = StandingRight[0];

            public Image Get(MemberStatus status) {
                if (status == MemberStatus.MoveRight) {
                    _img = MovingRight[_current];
                }
                else if (status == MemberStatus.MoveLeft) {
                    _img = MovingLeft[_current];
                }
                else {
                    if (_status == MemberStatus.MoveRight) {
                        _img = StandingRight[_current];
                    }
                    else if (_status == MemberStatus.MoveLeft) {
                        _img = StandingLeft[_current];
                    }
                }
                _status = status;
                _current = 1 - _current;
                Copy = _img;
                return _img;
            }
        }
    }
}
