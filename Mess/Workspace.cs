using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Mess {
    partial class Workspace : Form {
        public Workspace() {
            InitializeComponent();
        }

        private Department _department;
        private List<Member> _members;
        private List<Member> _asked;
        private List<Door> _doors;
        private Member _me;
        private Dictionary<Button, Action> _permissions;
        private int _seeing = -1;

        public int Number { get => _department.Number; }
        public static int GetSceneWidth(Department department, int width = 500) {
            int doorNumbers = department.Count;
            if (doorNumbers == 0) return (int)(1.5 * width);
            return (doorNumbers + 1) * width;
        }

        public override string ToString() {
            return $"{_me} in workspace {Number}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            Service.Terminate();
            // e.Cancel = true; // cancel closing form
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            this.scene.Height = this.ClientSize.Height;
            this.enter.Location = new Point() {
                X = enter.Location.X,
                Y = this.scene.Height - 200 - this.enter.Height / 2
            };
        }

        public Workspace(string me, int number) : this() {
            _asked = new List<Member>();
            InitializeScene(me, number);
            InitializeEvents();
        }

        public void UpdateScene() {
            InitializeScene(_me.Name, _department.Number);
        }

        private void InitializeScene(string me, int number, int pre = -1) {
            _department = Service.GetDepartment(number);
            _members = _department.Members;
            InitializeDepartment(me, pre: pre);
            InitializeImages();
        }

        private void InitializeImages() {
            // TODO: add more things (flowers, clock, etc.)
        }

        private void InitializeDepartment(string me, int pre = -1, int width = 500) {
            timer.Enabled = false;
            _doors = new List<Door>();
            var doorNumbers = _department.Count;
            // distance between 2 doors is 'width'
            if (doorNumbers == 0) {
                scene.Width = this.Width;
            }
            else {
                scene.Width = (doorNumbers + 1) * width;
            }
            var doorStartLocation = new Point(width, scene.Height);
            Door upperDoor = new Door(true) {
                Location = new Point() {
                    X = 0,
                    Y = doorStartLocation.Y
                },
                Number = _department.Info.Upper,
                IsUpperDoor = true
            };
            _doors.Add(upperDoor);
            for (var index = 0; index < doorNumbers; index++) {
                Door door = new Door() {
                    Location = new Point() {
                        X = doorStartLocation.X,
                        Y = doorStartLocation.Y
                    },
                    Number = _department.Info.SubDepartments[index].Number
                };
                _doors.Add(door);
                doorStartLocation.X += width;
            }
            foreach (var member in _members) {
                if (member.Name.Equals(me)) {
                    _me = member;
                    if (pre == -1) break;
                    foreach (var door in _doors) {
                        if (door.Number == pre) {
                            _me.Location = door.Location;
                            break;
                        }
                    }
                    break;
                }
            }
            CheckPermissions();
            this.Text = this.ToString();
            timer.Enabled = true;
        }

        private void Hire() {
            var dialog = new Hire();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                var info = new MemberInfo() {
                    Name = dialog.Namee,
                    Email = dialog.Email,
                    Birthday = dialog.Birthday,
                    Address = dialog.Address,
                    Department = dialog.Number,
                    Position = dialog.Position
                };
                if (info.Department == 0) {
                    info.Department = _department.Number;
                }
                bool[] addable = Service.TryAdd(info, _department.Number);
                if (!addable[0]) {
                    new Notification("Whoops!\r\nMember existed.").ShowDialog();
                }
                else if (!addable[1]) {
                    new Notification("Whoops!\r\nDepartment existed.").ShowDialog();
                }
                else {
                    var member = Service.GetMember(info.Name);
                    info = member.Info;
                    if (!_me.Hire(info, _department.Info.Head)) {
                        Service.RemoveMember(member);
                        new Notification(
                            "Whoops!\r\nDepartment full.\r\n"
                            + $"Capacity: {Department.Capacity}\r\n").ShowDialog();
                    }
                    else {
                        if (info.Email.Length < 1
                            || info.Birthday.Length < 1 || info.Address.Length < 1) {
                            new Notification(
                                "Some information is missing or not correct. "
                                + "But you can change later by managing members.\r\n")
                                .ShowDialog();
                        }
                    }
                }
            }
        }

        private void Fire() {
            if (_seeing != -1) {
                new Notification(
                    "Whoops!\r\n"
                    + "You cannot fire your member(s) "
                    + "while following a member.\r\n")
                    .ShowDialog();
                return;
            }
            var dialog = new Fire(_me.Info);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                var info = dialog.Info;
                _me.SetInfo(info.SubMembers);
                var removed = dialog.Removed;
                foreach (var mem in removed) {
                    var member = Service.GetMember(mem.Name);
                    _asked.Remove(member);
                    Service.RemoveMember(member);
                }
                InitializeScene(_me.Name, _me.Current);
            }
        }

        private void Change() {
            if (_asked.Count == 0) {
                string notification
                    = "You must ask someone before using this function.\r\n"
                    + "Click the on-top-right image to follow a member.\r\n";
                new Notification(notification)
                    .ShowDialog();
            }
            else {
                new Manage(_asked).ShowDialog();
            }
        }

        private void InitializeEvents() {
            void StopAsking() {
                _seeing = -1;
                seeing.Text = string.Empty;
                ask.Visible = false;
            }
            scene.Click += (object sender, EventArgs e) => {
                StopAsking();
                _me.Target = (e as MouseEventArgs).Location;
            };
            enter.Click += (object sender, EventArgs e) => {
                StopAsking();
                TryEnter();
            };
            menu.Click += (object sender, EventArgs e) => {
                if (change.Visible) {
                    menu.Text = "☰";
                }
                else {
                    menu.Text = "✕";
                }
                foreach (var permission in _permissions.Keys) {
                    permission.Visible = !permission.Visible;
                }
            };
            map.Click += (object sender, EventArgs e) => {
                new Map(_department.Info).ShowDialog();
            };
            foreach (var permission in _permissions.Keys) {
                permission.Click += (object sender, EventArgs e) => {
                    _permissions[permission]();
                };
            }
            foreach (Control control in this.Controls) {
                if (control is Label) {
                    control.MouseHover += (object sender, EventArgs e) => {
                        control.ForeColor = Color.White;
                    };
                    control.MouseLeave += (object sender, EventArgs e) => {
                        control.ForeColor = Color.Black;
                    };
                }
            }
            information.Click += (object sender, EventArgs e) => {
                var dialog = new Information(_me.Info);
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK) {
                    var email = dialog.Email;
                    var birthday = dialog.Birthday;
                    var address = dialog.Address;
                    _me.SetInfo(email, birthday, address);
                }
            };
            leftSeeing.Click += (object sender, EventArgs e) => {
                if (_members.Count > 1) {
                    while (true) {
                        if (--_seeing <= -1) {
                            _seeing = _members.Count - 1;
                        }
                        seeing.Text = _members[_seeing].Name;
                        if (!seeing.Text.Equals(_me.Name)) break;
                    }
                    ask.Visible = true;
                }
                else {
                    new Notification(
                        "There is no one but you in this workspace\r\n")
                        .ShowDialog();
                    StopAsking();
                }
            };
            rightSeeing.Click += (object sender, EventArgs e) => {
                if (_members.Count > 1) {
                    while (true) {
                        if (++_seeing >= _members.Count) {
                            _seeing = 0;
                        }
                        seeing.Text = _members[_seeing].Name;
                        if (!seeing.Text.Equals(_me.Name)) break;
                    }
                    ask.Visible = true;
                }
                else {
                    new Notification(
                        "There is no one but you in this workspace\r\n")
                        .ShowDialog();
                    StopAsking();
                }
            };
            ask.Click += (object sender, EventArgs e) => {
                if (_seeing >= 0) {
                    if (Math.Abs(_me.Target.X - _me.Location.X)
                        > this.Width / 2) return;
                    string data = string.Empty;
                    var member = _members[_seeing];
                    if (_me.Higher(member)) {
                        member.Ask(_me, ref _asked);
                        data = $"You asked {member.Name}.\r\n"
                            + "You've got his info.\r\n";
                    }
                    else {
                        data = "You have no permission to ask this member.\r\n";
                    }
                    new Notification(data).ShowDialog();
                    StopAsking();
                }
            };
            timer.Tick += (object sender, EventArgs e) => {
                if (_me == null) {
                    new Notification("Whoops! You have been out.").ShowDialog();
                    Service.RemoveWorkspace(this);
                    return;
                }
                if (_seeing != -1) {
                    _me.Target = _members[_seeing].Location;
                }
                MemberStatus status = _me.Move();
                CheckScene(status);
                DrawImages();
                DisplayEnterRange();
                Service.Auto(Number); // bots-auto movement
            };
        }

        private void CheckPermissions() {
            _permissions = new Dictionary<Button, Action>() {
                { hire, Hire },
                { fire, Fire },
                { change, Change }
            };
            var head = Service.GetMember(_department.Info.Head);
            if (_me == null) return;
            if (_me.Higher(head)) {
                foreach (var permission in _permissions.Keys) {
                    permission.Enabled = true;
                }
            }
            else {
                foreach (var permission in _permissions.Keys) {
                    permission.Enabled = false;
                }
            }
        }

        private void DrawImages() {
            bool IsInScreen(Point location) {
                if ((location.X > _me.Location.X - this.Width)
                    && (location.X < _me.Location.X + this.Width)) {
                    return true;
                }
                return false;
            }

            Image image = new Bitmap(scene.Width, scene.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            var index = 0;
            if (Number == _department.Info.Upper) {
                index = 1;
            }
            for (; index < _doors.Count; index++) {
                var door = _doors[index];
                if (!IsInScreen(door.Location)) continue;
                var img = door.DoorImage;
                var location = new Point() {
                    X = door.Location.X - img.Width / 2,
                    Y = scene.Height - img.Height
                };
                graphics.DrawImage(img, location);
                graphics.DrawString(door.Number.ToString(),
                    enter.Font, Brushes.Black, new Point() {
                        X = location.X,
                        Y = location.Y - (int)(enter.Font.Size * 2)
                    });
            }

            Service.GetImage(_me); // set image for me
            foreach (var member in _members) {
                if (member == null) {
                    // check when member was removed
                    _members.Remove(member);
                    continue;
                }
                if (!IsInScreen(member.Location)) continue;
                Image img = Service.GetCopiedImage(member);
                var location = new Point() {
                    X = member.Location.X - img.Width / 2,
                    Y = scene.Height - img.Height
                };
                graphics.DrawImage(img, location);
                graphics.DrawString(member.Name,
                    this.Font, Brushes.Black, new Point() {
                        X = location.X,
                        Y = location.Y - (int)(this.Font.Size * 2)
                    });
            }

            scene.Image = image;
        }

        private void TryEnter(int range = 50, int width = 500) {
            // distance between 2 doors is 'width'
            int index = (int)Math.Round(1.0 * _me.Location.X / width) - 1;
            if (index < 0) {
                if (Math.Abs(_me.Location.X) < 2 * range) {
                    var upper = Service.GetDepartment(_department.Info.Upper);
                    if (upper.Number != Number) {
                        if (_me.Join(upper)) {
                            InitializeScene(_me.Name, upper.Number, this.Number);
                        }
                        else {
                            new Notification("Workspace too crowded!").ShowDialog();
                        }
                    }
                }  
            }
            else if (index + 1 < _doors.Count) {
                if (Math.Abs(_me.Location.X - _doors[index + 1].Location.X) < range) {
                    var sub = Service.GetDepartment(_department.Info
                        .SubDepartments[index].Number);
                    if (_me.Join(sub)) {
                        _me.Location = Point.Empty;
                        InitializeScene(_me.Name, sub.Number);
                    }
                    else {
                        new Notification("Workspace too crowded!").ShowDialog();
                    }
                }
            }
        }

        private void DisplayEnterRange(int range = 50, int width = 500) {
            // distance between 2 doors is 'width'
            int index = (int)Math.Round(1.0 * _me.Location.X / width) - 1;
            if (index < 0) {
                enter.Location = new Point() {
                    X = 10,
                    Y = enter.Location.Y
                };
                if (Math.Abs(_me.Location.X) < 2 * range) {
                    if (Number != _department.Info.Upper) {
                        enter.Visible = true;
                    }
                }
                else {
                    enter.Visible = false;
                }
            }
            else if (index + 1 < _doors.Count) {
                var doorX = _doors[index + 1].Location.X;
                enter.Location = new Point() {
                    X = doorX + scene.Location.X - enter.Width / 2,
                    Y = enter.Location.Y
                };
                if (Math.Abs(_me.Location.X - _doors[index + 1].Location.X) < range) {
                    enter.Visible = true;
                }
                else {
                    enter.Visible = false;
                }
            }
            else {
                enter.Visible = false;
            }
        }

        private void CheckScene(MemberStatus status, int step = 5, int range = 200) {
            var location = new Point() {
                X = scene.Location.X + _me.Location.X,
                Y = _me.Location.Y
            };
            if (_me.Location.X > scene.Width) {
                _me.Location = new Point() {
                    X = scene.Width,
                    Y = _me.Location.Y
                };
            }
            else if (_me.Location.X < 0) {
                _me.Location = Point.Empty;
            }

            if (false) {
                if ((scene.Width > this.Width)
                    && (_me.Location.X > this.Width / 2)
                    && (_me.Location.X + this.Width / 2 < scene.Width)) {
                    scene.Location = new Point() {
                        X = -(_me.Location.X - this.Width / 2),
                        Y = scene.Location.Y
                    };
                }
                else if (scene.Width < this.Width) {
                    scene.Location = new Point() {
                        X = 0,
                        Y = scene.Location.Y
                    };
                }
            }
            else {
                if (location.X + range > this.Width) {
                    if (scene.Location.X + this.Width == scene.Width) {
                        // no check
                        return;
                    }
                    scene.Location = new Point() {
                        X = scene.Location.X - range,
                        Y = scene.Location.Y
                    };
                }
                else if (location.X - range < 0) {
                    if (scene.Location.X == 0) {
                        // no check
                        return;
                    }
                    scene.Location = new Point() {
                        X = scene.Location.X + range,
                        Y = scene.Location.Y
                    };
                }
                else {
                    // do nothing
                }
            }
        }

        public void About(string text) {
            aboutContent.Text = text;
            aboutme.Click += (object sender, EventArgs e) => {
                new Notification(aboutContent.Text).ShowDialog();
            };
        }
    }
}
