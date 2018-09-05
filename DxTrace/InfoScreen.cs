using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxTrace
{
    public partial class InfoScreen : Form, IMessage
    {
        private bool _Block;

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

        public InfoScreen()
        {
            InitializeComponent();

        }




        /*public string GetLog()
        {
            return Log.Text;
        }*/


        private void btLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void KillAfter(int time)
        {
            btLeave.Visible = true;
            btAlive.Visible = true;
            //Cursor.Current = Cursors.Default;
            UseWaitCursor = false;

            for (int i = time; i > 0; i--)
            {
                if (_Block)
                {
                    btLeave.Text = Lang.Leave;
                    break;
                }
                btLeave.Text = $"{Lang.Leave} ({i})";
                await Task.Delay(1000);
            }

            if (!_Block) this.Close();
        }

        private void btAlive_Click(object sender, EventArgs e)
        {
            _Block = true;

        }


        #region graph
        public void BeginLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";
            Log.Text += message;
        }

        public void EndLine(string message = null)
        {
           // Log.Text += text;
            Log.Text += message + Environment.NewLine;

        }

        public void WriteLine(string message = null, bool prefix = true)
        {
            if (prefix && ShowPrefix) message = $"[{Prefix}] {message}";
            Log.Text += message + Environment.NewLine;

            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }
        #endregion
    }
}
