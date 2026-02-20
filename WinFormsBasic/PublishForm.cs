using System;
using System.Windows.Forms;

namespace NotificationApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}