using DawnMud.admin;
using DawnMud.inherit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.objects
{
    public class User : Save
    {
        public TcpClient _socket;
        private byte[] readBuf;
        public User(TcpClient sock)
        {
            _socket = sock;
        }
        
        public void onCommand(string cmd)
        {
            // todo do command;
        }

        public string shortname()
        {
            string id = (string)get("id");
            if (id.Length > 0)
            {
                return (string)get("name") + "(" + id + ")";
            }
            else
            {
                return "Wrong ID";
            }
        }

        public string desc()
        {
            string str = shortname();
            return str += "\n" + "这里是这个人物的长描述巴拉巴拉。\n";
        }

        public void message(string msg)
        {
            byte[] bs = Encoding.Default.GetBytes(msg);
            var stream = _socket.GetStream();
            stream.Write(bs);
        }

        public void setup()
        {
            set("hp", 100);
            set("mp", 100);
            set("max_hp", 100);
            set("max_mp", 100);
        }

        public void quit()
        {
            stop_heart_beat();
            save();
        }

        public void start_heart_beat()
        {
            stop_heart_beat();
        }

        public void stop_heart_beat()
        {
        }

        public void heart_beat(User user)
        {
            user.message(user.shortname() + "HB ticker for " + Config.HEARTBEAT);
        }

        public void close_socket()
        {
            _socket.Close();
        }

        public void begin_read_command()
        {
            readBuf = new byte[8192];
            var stream = _socket.GetStream();
            stream.BeginRead(readBuf, 0, readBuf.Length, new AsyncCallback(read_callback), null);
        }


        private void read_callback(IAsyncResult ar)
        {
            var stream = _socket.GetStream();
            int count = stream.EndRead(ar);
            string cmd = Encoding.Default.GetString(readBuf, 0, count);

            onCommand(cmd);

            //再次异步读取
            readBuf = new byte[8192];
            stream.BeginRead(readBuf, 0, readBuf.Length, read_callback, null);
        }
    }
}
