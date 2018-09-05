using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxTrace
{
    //Todo implémenter timestamp
    public class InfoToIScreen : IMessage
    {
        public string Prefix { get; set; }
 
        public InfoScreen IScreen;

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

        public InfoToIScreen()
        {            
            IScreen = new InfoScreen();
            ShowWindow();
        }


        public void BeginLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";

            IScreen.Text += message;
        }

        public void EndLine(string message = null)
        {
            IScreen.Text += message + Environment.NewLine;
        }

        public void WriteLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";

            IScreen.Text += message + Environment.NewLine;
        }

        #region Graph
        public void ShowWindow()
        {
            IScreen.Show();
        }

        public void KillWindowAfter(int time)
        {
            IScreen.KillAfter(time);
        }

        public void KillWindow()
        {
            IScreen.Close();
        }
        #endregion
    }
}
