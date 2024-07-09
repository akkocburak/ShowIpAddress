namespace ShowIpAddress
{
    using System;
    using System.Windows.Forms;

    namespace ShowIpAddress
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Form1 form = new Form1();
                Application.Run(); // Form olmadan çalýþtýr
            }
        }
    }
}