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
    partial class Fire : Form {
        private Fire() {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        private TreeNode _current;
        private MemberInfo _info;
        private List<MemberInfo> _removed;

        public MemberInfo Info {
            get => _info;
        }

        public List<MemberInfo> Removed {
            get => _removed;
        }

        public Fire(MemberInfo info) : this() {
            _info = info;
            _current = new TreeNode() {
                Text = info.Name
            };
            CreateNode(_current, info);

            foreach (TreeNode node in _current.Nodes) {
                tree.Nodes.Add(node);
            }
            tree.ExpandAll();

            _removed = new List<MemberInfo>();
        }

        private void FireSelected(TreeNode node, MemberInfo info) {
            for (var index = node.Nodes.Count - 1; index >= 0; index--) {
                var subnode = node.Nodes[index];
                if (subnode.Checked) {
                    node.Nodes.Remove(subnode);
                    var subinfo = info.SubMembers[index];
                    _removed.Add(subinfo);
                    info.SubMembers.Remove(subinfo);
                }
                else {
                    FireSelected(subnode, info.SubMembers[index]);
                }
            }
        }

        private void CreateNode(TreeNode node, MemberInfo info) {
            foreach (var subinfo in info.SubMembers) {
                var subnode = new TreeNode() {
                    Text = subinfo.Name
                };
                CreateNode(subnode, subinfo);
                node.Nodes.Add(subnode);
            }
        }

        private void fireCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void fireOK_Click(object sender, EventArgs e) {
            FireSelected(_current, _info);
            this.Close();
        }
    }
}
