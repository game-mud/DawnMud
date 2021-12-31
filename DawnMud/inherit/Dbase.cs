using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.inherit
{
    public class Dbase
    {
        Dictionary<string, object> _dbase;    
        Dictionary<string, object> _temp_dbase;
        public Dbase()
        {
            _dbase = new Dictionary<string, object>();
            _temp_dbase = new Dictionary<string, object>();
        }

        public object set(string p, object data)
        {
            _dbase[p] = data;
            return _dbase[p];
        }

        public object get(string p)
        {
            if (_dbase.ContainsKey(p))
                return _dbase[p];
            else
                return null;
        }

        public object add(string p, object data)
        {
            _dbase[p] = data;
            return _dbase[p];
        }

        public Dictionary<string, object> query_entire_dbase()
        {
            return _dbase;
        }

        public void set_entire_dbase(object obj)
        {
            _dbase = (Dictionary<string, object>)obj;
        }

        public object set_temp(string p, object data)
        {
            _temp_dbase[p] = data;
            return _temp_dbase[p];
        }
        public object get_temp(string p)
        {
            if (_temp_dbase.ContainsKey(p))
                return _temp_dbase[p];
            else
                return null;
        }

        public object add_temp(string p, object data)
        {
            _temp_dbase[p] = data;
            return _temp_dbase[p];
        }

    }

}
