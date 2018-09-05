using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxTrace
{
    public class ITrace
    {
        public static List<IMessage> Listeners { get; } = new List<IMessage>();

        public static void AddListener(IMessage listener)
        {
            Listeners.Add(listener);
        }

        public static void RemoveListener(IMessage listener)
        {
            Listeners.Remove(listener);
        }

        /// <summary>
        /// Begin a line
        /// </summary>
        /// <param name="message"></param>
        public static void BeginLine(string message = null, bool prefix = true)
        {
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].BeginLine(message, prefix);
            }
        }

        /// <summary>
        /// End a line
        /// </summary>
        /// <param name="message"></param>
        public static void EndlLine(string message = null)
        {
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].EndLine(message);
            }
        }

        /// <summary>
        /// Write a Line
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message = null, bool prefix = true)
        {
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].WriteLine(message, prefix);
            }
        }

        public static void RemoveLast()
        {
            var lastListener = Listeners[Listeners.Count-1];
            lastListener = null;
            Listeners.RemoveAt(Listeners.Count-1);
        }
    }
}
