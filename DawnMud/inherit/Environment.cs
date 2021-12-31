using DawnMud.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.inherit
{
    public class Environment : Save
    {
        private List<Dbase> _inv;
        private Environment _env = null;

        public Environment() : base()
        {
            _inv = new List<Dbase>();
        }

        public Dbase find_in_inv(object id)
        {
            foreach (var obj in _inv)
            {
                if (id == obj.get("id"))
                    return obj;
            }
            return null;
        }

        public void onMove(Dbase obj)
        {
            _inv.Append(obj);
        }

        public void onLeave(Dbase obj)
        {
            _inv.Remove(obj);
        }

        public void move(Environment obj)
        {
            obj.onMove(this);
            if (_env == null)
            {
            }
            else
            {
                _env.onLeave(this);
            }
            _env = obj;
            //global.app.COMMAND_D.doCommand(this, "look");
        }

        public void leave()
        {
            if (_env != null)
            {
                _env.onLeave(this);
                _env = null;
            }
        }
    }
}
