using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mess {
    public partial class Manager : Form {
        public Manager() {
            InitializeComponent();
            InitializeWorkspaces();
        }

        private bool _running;
        private List<Workspace> _workspaces = new List<Workspace>();

        public void InitializeWorkspaces() {
            Service.Start();

            Service.JoinAll();

            var tuan = Service.GetMember("Tuan");

            Service.DisableAuto(new List<Member>() {
                tuan
            });

            _workspaces.Add(Service.GetWorkspace(tuan.Name));
            // _workspaces.Add(Service.GetWorkspace(xuanh.Name));
            // _workspaces.Add(Service.GetWorkspace(khiem.Name));
        }

        public void Start() {
            this.WindowState = FormWindowState.Minimized;

            foreach (var workspace in _workspaces) {
                try {
                    if (workspace != null) {
                        workspace.Show();
                    }
                } catch (Exception) {
                    // do nothing
                }
            }
        }

        public void Terminate() {
            foreach (var workspace in _workspaces) {
                try {
                    if (workspace != null) {
                        workspace.Close();
                    }
                } catch (Exception) {
                    // do nothing
                }
            }

            Service.Terminate();
        }

        private void startButton_Click(object sender, EventArgs e) {
            if (!_running) {
                Start();
                startButton.Text = "Terminate";
            }
            else {
                Terminate();
                this.Dispose();
            }
            _running = !_running;
        }
    }
}
