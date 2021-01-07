using System;
using System.Windows.Forms;


namespace Mess {
    partial class Hire : Form {
        public Hire() {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            InitializeEvents();
        }

        private void InitializeEvents() {
            addmemPositionHoD.CheckedChanged += (object sender, EventArgs e) => {
                if (addmemPositionHoD.Checked) {
                    addmemDepartmentNumber.Enabled = true;
                    addmemDepartmentNumberInput.Enabled = true;
                }
                else {
                    addmemDepartmentNumber.Enabled = false;
                    addmemDepartmentNumberInput.Enabled = false;
                }
            };
        }

        public string Namee {
            get => addmemNameInput.Text.Trim();
        }

        public string Email {
            get => addmemEmailInput.Text.Trim();
        }

        public string Birthday {
            get => addmemBirthdayInput.Text.Trim();
        }

        public string Address {
            get => addmemAddressInput.Text.Trim();
        }

        public MemberPosition Position {
            get {
                if (addmemPositionEmployee.Checked) {
                    return MemberPosition.Employee;
                }
                if (addmemPositionHoD.Checked) {
                    return MemberPosition.HeadOfDepartment;
                }
                return MemberPosition.None;
            }
        }

        public int Number {
            get {
                if (int.TryParse(
                    addmemDepartmentNumberInput.Text.Trim(), out int number)) {
                    return number;
                }
                return 0;
            }
        }

        private bool IsValid() {
            if (Namee.Length < 1) {
                new Notification("Whoops! Name too short!").ShowDialog();
                return false;
            }

            // check others

            return true;
        }

        private void addmemCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void addmemOK_Click(object sender, EventArgs e) {
            if (IsValid()) {
                this.Close();
            }
        }
    }
}
