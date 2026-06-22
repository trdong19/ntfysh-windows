using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ntfysh_client.Notifications;

namespace ntfysh_client
{
    static class Program
    {
        private static readonly NotificationListener NotificationListener = new();
        public static SettingsModel Settings { get; set; } = null!;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            args = args.Select(a => a.ToLower()).ToArray();

            if (args.Contains("-h") || args.Contains("--help"))
            {
                MessageBox.Show("帮助：\n    -h\n    --help\n\n启动时最小化到托盘：\n    -t\n    --start-in-tray\n\n允许多个实例：\n    -m\n    --allow-multiple-instances", "帮助菜单", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool startInTray = args.Contains("-t") || args.Contains("--start-in-tray");
            bool allowMultipleInstances = args.Contains("-m") || args.Contains("--allow-multiple-instances");

            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()!.Location)).Length > 1)
            {
                if (!allowMultipleInstances)
                {
                    MessageBox.Show("另一个实例正在运行。\n\n如需启动多个实例，请使用 -m 或 --allow-multiple-instances 参数。\n\n当前实例将关闭。", "多实例提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(NotificationListener, startInTray));
        }
    }
}
