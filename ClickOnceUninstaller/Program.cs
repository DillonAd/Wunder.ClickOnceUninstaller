using System;

namespace Wunder.ClickOnceUninstaller
{
    class Program
    {

        static int Main(string[] args)
        {
            try
            {
                if (args.Length != 1 || string.IsNullOrEmpty(args[0]))
                {
                    Console.WriteLine("Usage:\nClickOnceUninstaller appName");
                    return 0;
                }

                var appName = args[0];

                var uninstallInfo = UninstallInfo.Find(appName);
                if (uninstallInfo == null)
                {
                    Console.WriteLine("Could not find application \"{0}\"", appName);
                    return 1;
                }

                Console.WriteLine("Uninstalling application \"{0}\"", appName);
                var uninstaller = new Uninstaller();
                uninstaller.Uninstall(uninstallInfo);

                Console.WriteLine("Uninstall complete");

                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 2;
            }
        }
    }
}
