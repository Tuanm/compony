using Newtonsoft.Json;
using WMPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Mess {
    class Program {
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                string welcome = "\rYou are director of a company. "
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
                Application.Run(workspace);

                Service.Terminate();
            } catch (Exception e) {
                string message = "\rWhoops! You found an error: "
                    + $"{e.Message}\r\n"
                    + "\rReport to me now! (https://m.me/Teemoing)\r\n";
                Application.Run(new Notification(message) {
                    IsCenterToScreen = true
                });
            }
        }
    }
}
