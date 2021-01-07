using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mess {
    class Bot {
        private Member _member;
        public bool IsActivated;
        public int Number;
        private bool _ok = true;
        private static Random _random = new Random();
        private int _max;

        public Bot(Member member) {
            _member = member;
            UpdateScene();
            // AutoUpdateScene();
        }

        public void AutoUpdateScene() {
            Task.Run(() => {
                while (IsActivated) {
                    Thread.Sleep(30000);
                    UpdateScene();
                }
            });
        }

        public void RandomlyUpdateScene() {
            if (_random.Next(_max) < _max / 10) {
                UpdateScene();
            }
        }

        public void UpdateScene() {
            var department = Service.GetDepartment(_member.Info.Department);
            if (department == null) {
                IsActivated = false;
                return;
            }
            Number = department.Number;
            _max = Workspace.GetSceneWidth(department);
        }

        public void GoAround() {
            if (IsActivated) {
                if (_ok) {
                    Task.Run(() => {
                        _ok = false;
                        _member.Target = Next(_member.Target);
                        _member.Move();
                        Service.GetImage(_member);
                        _ok = true;
                    });
                }
            }
        }

        private Point Next(Point target, int padding = 50) {
            Point _target = target;
            if (_member.Target == Point.Empty) {
                UpdateScene();
                Thread.Sleep(1000); // lemme take a break
                _target = new Point() {
                    X = _random.Next(_max - 2 * padding) + padding,
                    Y = _member.Location.Y
                };
            }
            return _target;
        }
    }
}
