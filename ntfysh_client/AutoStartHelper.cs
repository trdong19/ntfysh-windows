using System;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ntfysh_client
{
    public static class AutoStartHelper
    {
        private const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppName = "ntfysh_windows";

        public static bool IsAutoStartEnabled()
        {
            try
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey(RunKeyPath, false);
                return key?.GetValue(AppName) != null;
            }
            catch
            {
                return false;
            }
        }

        public static void SetAutoStart(bool enable)
        {
            try
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true);
                if (key == null) return;

                if (enable)
                {
                    string exePath = Assembly.GetExecutingAssembly().Location;
                    // For single-file publish, Location may point to a temp directory
                    // Use Environment.ProcessPath as fallback
                    if (string.IsNullOrEmpty(exePath) || exePath.EndsWith(".dll"))
                    {
                        exePath = Environment.ProcessPath ?? exePath;
                    }
                    key.SetValue(AppName, $"\"{exePath}\" -t");
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }
            }
            catch
            {
                // Silently fail - user may not have registry access
            }
        }
    }
}
