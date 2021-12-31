using DawnMud.admin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawnMud.inherit
{
	public class Save : Dbase
	{
		public Save() : base()
		{
		}

		public int save()
		{
			if ((bool)get_temp("is_loging"))
				return 0;

			string data = JsonConvert.SerializeObject(this.query_entire_dbase());
			string saveFile = this.query_save_file();
			asure_file(saveFile);
			File.WriteAllText(saveFile, data);
			return 1;
		}

		public int restore()
		{
			var saveFile = this.query_save_file();
			if (!File.Exists(saveFile))
				return 0;
			var str = File.ReadAllText(saveFile);
			var obj = JsonConvert.SerializeObject(str);
			this.set_entire_dbase(obj);
			return 1;
		}

		public string query_save_file()
		{
			return Config.MUDLIB + "/data/" + ((string)(get("id")))[0] + "/" + (string)get("id") + ".o";
		}

		public void asure_file(string file)
		{
			var dir = Path.GetDirectoryName(file);

			var b = Directory.Exists(dir);
			if (!b)
			{
				Directory.CreateDirectory(dir);
			}
		}
	}
}

