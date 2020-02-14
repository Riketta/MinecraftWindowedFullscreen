using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftWindowedFullscreen
{
    class Utils
    {
        public static Process GetMinecraftProcess()
        {
            Process[] processes = Process.GetProcesses();
            var minecraft = processes.First(p => p.ProcessName.StartsWith("java") && p.MainWindowTitle.StartsWith("Minecraft"));

            return minecraft;
        }

        public static void SetWindowFullscreen(IntPtr hWnd)
        {
            var rect = Screen.FromHandle(hWnd).Bounds;
            Win32.SetWindowPos(hWnd, hWnd, rect.X, rect.Y, rect.Width, rect.Height, Win32.SWP_SHOWWINDOW | Win32.SWP_FRAMECHANGED);
        }

        public static void MinimizeWindow(IntPtr hWnd)
        {
            Win32.ShowWindow(hWnd, Win32.SW_MINIMIZE);
        }

        public static void MaximizeWindow(IntPtr hWnd)
        {
            Win32.ShowWindow(hWnd, Win32.SW_MAXIMIZE);
        }

        public static void SetWindowStyleOff(IntPtr hWnd, int nIndex, long dwStylesToOff)
        {
            IntPtr windowStyles = GetWindowStyles(hWnd, nIndex);
            Win32.SetWindowLongPtr(hWnd, nIndex, ((windowStyles.ToInt64() | dwStylesToOff) ^ dwStylesToOff));
        }

        public static IntPtr GetWindowStyles(IntPtr hWnd, int nIndex)
        {
            return Win32.GetWindowLongPtr(hWnd, nIndex);
        }
    }
}
