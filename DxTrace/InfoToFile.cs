using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxTrace
{
    public class InfoToFile : IMessage
    {
        public string Prefix { get; set; }
        
        public string FileLog { get; set; }

        private bool ShowPrefix { get; set; }
        private bool TimeStamp { get; set; }

        private DxTOptions _Options;
        public DxTOptions Options
        {
            get { return _Options; }
            set
            {
                if (value.HasFlag(DxTOptions.Prefix)) ShowPrefix = true;
                if (value.HasFlag(DxTOptions.TimeStamp)) TimeStamp = true;
                _Options = value;
            }
        }

        public InfoToFile(string file, bool overwrite)
        {       
            
            FileLog = file;

            FileMode fm;

            if (overwrite) fm = FileMode.Create;
            else fm = FileMode.OpenOrCreate;

            using (File.Open(FileLog, fm)) ;
        }


        public void BeginLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";
            using (StreamWriter fs = new StreamWriter(FileLog, true))
            {
                fs.Write(message);
            }
        }

        public void EndLine(string message = null)
        {
            using (StreamWriter fs = new StreamWriter(FileLog, true))
            {
                fs.WriteLine(message);
            }
        }


        public void WriteLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";

            using (StreamWriter fs = new StreamWriter(FileLog, true))
            {
                fs.WriteLine(message);
            }
        }
    }
}
