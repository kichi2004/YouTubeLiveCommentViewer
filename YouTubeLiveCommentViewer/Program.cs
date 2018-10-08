using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YouTubeLiveCommentViewer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("--reset"))
                Properties.Settings.Default.Reset();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
