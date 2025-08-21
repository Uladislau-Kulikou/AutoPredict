using Autoprezzit_interface;
using System.Diagnostics;

namespace Autoprezzit_interface
{
    internal static class Program
    {
        static UIForm form = new UIForm();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(form);
        }

        public static void HandleCarData(string json)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string predictExe = Path.Combine(exeDir, "predict.exe");
            var psi = new ProcessStartInfo
            {
                FileName = predictExe,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);

            process.StandardInput.Write(json);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            form.displayResult(result.Trim());

        }

    }

    
}


