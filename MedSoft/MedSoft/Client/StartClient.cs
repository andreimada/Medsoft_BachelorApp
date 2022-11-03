using Service;
using Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientDoctor {
    public class StartClient {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IService server = new ServerProxy("127.0.0.1", 55555);
            DoctorController controller = new DoctorController(server);
            DoctorLogin log = new DoctorLogin(controller);
            Application.Run(log);
        }
    }
}
