using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxTrace
{
    public class InfoToConsole : IMessage
    {
        public string Prefix { get; set; }

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

        public InfoToConsole()
        {

        }

        public void BeginLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";
            Console.Write(message);
        }

        public void EndLine(string message = null)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";
            Console.WriteLine(message);

        }
    }
}
