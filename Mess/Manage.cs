using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Mess {
    partial class Manage : Form {
        private Manage() {
            InitializeComponent();
        }

        private List<Member> _members;

        public Manage(List<Member> members) : this() {
            _members = members;
            InitializeDataView();
        }

        private void InitializeDataView() {
            foreach (var member in _members) {
                var info = member.Info;
                view.Rows.Add(
                    info.Name,
                    info.Email,
                    info.Birthday,
                    info.Address,
                    info.Position,
                    info.Department);
            }
        }

        private void save_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in view.Rows) {
                string name = (string)row.Cells[0].Value;
                string email = (string)row.Cells[1].Value;
                string birthday = (string)row.Cells[2].Value;
                string address = (string)row.Cells[3].Value;
                for (var index = 0; index < _members.Count; index++) {
                    if (_members[index].Name.Equals(name)) {
                        _members[index].SetInfo(email, birthday, address);
                        break;
                    }
                }
            }
        }
    }
}
