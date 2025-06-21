namespace MyStickyNotes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            frmMain frmMain = new frmMain();
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg.StartsWith("--root="))
                    {
                        frmMain.RootFolder = arg.Substring(7);
                    }
                }
            }
            

            Application.Run(frmMain);
        }
    }
}