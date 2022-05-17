using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp2Server
{
    class client
    {
        public Socket socket {get; set;}
        public Label whichLabel { get; set; }
        public string role { get; set; }
        public string id { get; set; }
    }
}
