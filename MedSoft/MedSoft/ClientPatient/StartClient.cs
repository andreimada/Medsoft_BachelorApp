using Service;
using System;
using Networking;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPatient {
    public class StartClient {
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IService server = new ServerProxy("127.0.0.1", 55555);
            PatientController controller = new PatientController(server);
            PatientLogin log = new PatientLogin(controller);
            Application.Run(log);
        }
    }
}
