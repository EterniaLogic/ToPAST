namespace ToP_Tools
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TMAIN());
            //Application.Run(new help.RepBug());
        }
    }
    
}

