using DawnMud.admin;
using DawnMud.include;
using DawnMud.objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.daemons
{
    public class Serverd
    {
        private TcpListener _listener;
        private List<User> _users;
        private List<TcpClient> _sockets;

        public void init()
        {
            _users = new List<User>();
            _sockets = new List<TcpClient>();
            IPAddress address = IPAddress.Parse("127.0.0.1");
            _listener = new TcpListener(address, Config.PORT);
            _listener.Start();
        }

        public void quit(User user)
        {
            int idx = _sockets.IndexOf(user._socket);
            if (idx >=0)
            {
                _sockets.RemoveAt(idx);
                _users.RemoveAt(idx);
                user.close_socket();
            }
        }


        public void back_end()
        {
            while (true)
            {
                TcpClient socket =  _listener.AcceptTcpClient();
                User user = new User(socket);
                _users.Add(user);

                user.set_temp("is_loging", 1);
                user.set_temp("login_step", "getid");
                string welcome = File.ReadAllText(Config.MUDLIB + "/etc/welcome");
                user.message(ANSI.HIG + welcome + ANSI.NOR);
                user.message(ANSI.HIG + "请输入您的ID：" + ANSI.NOR);
                user.begin_read_command();
            }
        }

        private void welcome(User user)
        {

        }

        private void close(User user)
        {
            user.quit();
        }
    }
}
