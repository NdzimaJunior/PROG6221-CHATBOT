using System;
using System.Windows.Forms;

namespace POE_CHATBOT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // ← this launches your form
        }
    }
}