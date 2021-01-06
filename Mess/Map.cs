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
    partial class Map : Form {
        private Map() {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        public Map(DepartmentInfo info) : this() {
            TreeNode upper = new TreeNode() {
                Text = info.Upper.ToString()
            };
            TreeNode current = new TreeNode() {
                Text = info.Number.ToString()
            };
            
            CreateNode(current, info);
            if (info.Number == 0) {
                upper = current;
            }
            else {
                upper.Nodes.Add(current);
            }
            
            current.ForeColor = Color.Green;

            tree.Nodes.Add(upper);

            tree.ExpandAll();
            tree.SelectedNode = current;
        }

        private void CreateNode(TreeNode node, DepartmentInfo info) {
            foreach (var subinfo in info.SubDepartments) {
                var subnode = new TreeNode() {
                    Text = subinfo.Number.ToString()
                };
                CreateNode(subnode, subinfo);
                node.Nodes.Add(subnode);
            }
        }

        private void exit_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}
