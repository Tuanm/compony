using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Mess {
    class Program {
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                string welcome
                    = "\rYou are director of a company. "
                    + "Everything you can do is going around, "
                    + "asking any employee for information. "
                    + "You can also hire new employee, fire some, etc. "
                    + "This is not a game, but enjoy it!\r\n";
                Application.Run(new Notification(welcome) {
                    IsCenterToScreen = true
                });

                Service.Start();
                Service.JoinAll();

                var me = Service.GetMember(string.Empty);
                if (me == null) {
                    throw new Exception(
                        "\rI guess you have modified some files.\r\n"
                        + "\rCuriosity killed the cat.\r\n");
                }
                Service.DisableAuto(new List<Member>() {
                    me 
                });

                var workspace = Service.GetWorkspace(me.Name);
                workspace.About("Tuanm & xuananh24 & tagiakhiem2000\r\n"
                    + "Hanoi, 2020, Jan. 13th\r\n"
                    + "https://github.com/Tuanm/compony" + "\r\n");
                Application.Run(workspace);

                Service.Terminate();

                string about = "UI designed & Composite implemented by Tuanm.\r\n"
                    + "Iterator implemented by xuananh24.\r\n"
                    + "Decorator implemented by tagiakhiem2000.\r\n"
                    + "Thanks for feedback!";
                Application.Run(new Notification(about) {
                    IsCenterToScreen = true
                });
            } catch (Exception e) {
                string message
                    = "\rWhoops! You found an error: "
                    + $"{e.Message}\r\n"
                    + "\rReport to me now! (https://m.me/Teemoing)\r\n";
                Application.Run(new Notification(message) {
                    IsCenterToScreen = true
                });
            }
        }
    }
}
