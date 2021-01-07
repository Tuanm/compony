using System;
using System.Windows.Forms;


namespace Mess {
    partial class Notification : Form {
        private Notification() {
            InitializeComponent();
            InitializeEvents();
        }

        public bool IsCenterToScreen = false;

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (IsCenterToScreen) {
                CenterToScreen();
                this.message.TextAlign = HorizontalAlignment.Left;
            }
        }

        public Notification(string message) : this() {
            this.message.Text = message;
        }

        private void InitializeEvents() {
            ok.Click += (object sender, EventArgs e) => {
                this.Dispose();
            };
            ok.Focus();
        }
    }
}
