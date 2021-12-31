using DawnMud.daemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.admin
{
    public static class App
    {
        public static Serverd SERVER_D { get; private set; }
        static App()
        {
            SERVER_D = new Serverd();
            SERVER_D.init();

        }
    }
}
