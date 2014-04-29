using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace a_star
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var form = new main();
            Application.Run(new main());
        }
    }
}
