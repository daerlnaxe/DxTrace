using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxTrace
{
    public interface IMessage
    {
        string Prefix { get; set; }        
        DxTOptions Options{ get; set; }

        void BeginLine(string message = null, bool prefix = true);
        void EndLine(string message = null);
        void WriteLine(string message = null, bool prefix = true);
    }
}
