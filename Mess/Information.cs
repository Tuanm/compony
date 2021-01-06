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
    partial class Information : Form {
        private Information() {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        public Information(MemberInfo info) : this() {
            infoNameOutput.Text = info.Name;
            infoEmailOutput.Text = info.Email;
            infoBirthdayOutput.Text = info.Birthday;
            infoAddressOutput.Text = info.Address;
            infoPositionOutput.Text = info.Position.ToString();
            infoDepartmentOutput.Text = info.Department.ToString();
        }

        public string Namee {
            get => infoNameOutput.Text;
        }

        public string Email {
            get => infoEmailOutput.Text;
        }

        public string Birthday {
            get => infoBirthdayOutput.Text;
        }

        public string Address {
            get => infoAddressOutput.Text;
        }

        public int Department {
            get {
                if (int.TryParse(infoDepartmentOutput.Text, out int department)) {
                    return department;
                }
                return 0;
            }
        }

        public MemberPosition Position {
            get {
                if (infoPositionOutput.Text
                    .Equals(MemberPosition.Employee.ToString())) {
                    return MemberPosition.Employee;
                }
                if (infoPositionOutput.Text
                    .Equals(MemberPosition.HeadOfDepartment.ToString())) {
                    return MemberPosition.HeadOfDepartment;
                }
                return MemberPosition.None;
            }
        }

        private void infoOK_Click(object sender, EventArgs e) {
            this.Close(); // @xuanh recommended
        }

        private void infoCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}
