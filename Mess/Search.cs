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
    partial class Search : Form {
        private Search() {
            InitializeComponent();
        }

        private MemberInfo _root;
        private DepartmentInfo _department;

        public Search(MemberInfo root, DepartmentInfo department) : this() {
            _root = root;
            _department = department;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            if(txtAddress.Text.Length > 1 || txtBirthday.Text.Length > 1 || label55.Text.Length > 1 || txtName.Text.Length > 1) {
                gridMember.Rows.Clear();
                int department;
                try {
                    department = int.Parse(txtDepartment.Text);
                } catch (Exception) {

                    department = int.MinValue;
                }
                MemberInfo memSearch = new MemberInfo() {
                    Name = txtName.Text,
                    Birthday = txtBirthday.Text,
                    Department = department,
                    Address = txtAddress.Text};
                MemberIterator memIter = new MemberIterator(_root);
                for (MemberInfo mem = (MemberInfo)memIter.First(); mem != null; mem = (MemberInfo)memIter.Next()) {
                    if (memSearch.Name.Equals("") || mem.Name == memSearch.Name) {                  
                        if (memSearch.Birthday.Equals("") || mem.Birthday == memSearch.Birthday) {
                            if (memSearch.Address.Equals("") || mem.Address == memSearch.Address) {
                                if (txtDepartment.Text.Equals("") || mem.Department == memSearch.Department) {
                                    gridMember.Rows.Add(mem.Name, mem.Birthday, mem.Department, mem.Address);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}
