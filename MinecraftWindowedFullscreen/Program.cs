using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftWindowedFullscreen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Looking for Minecraft");
            IntPtr hWnd = Utils.GetMinecraftProcess().MainWindowHandle;

            Console.WriteLine("Applying window changes");
            long stylesToOff = Win32.WS_BORDER | Win32.WS_BORDER | Win32.WS_DLGFRAME | Win32.WS_SYSMENU | Win32.WS_MINIMIZEBOX | Win32.WS_MAXIMIZEBOX | Win32.WS_THICKFRAME;
            Utils.SetWindowStyleOff(hWnd, Win32.GWL_STYLE, stylesToOff);
            Utils.SetWindowFullscreen(hWnd);

            Console.WriteLine("ReMaximizing window");
            Utils.MinimizeWindow(hWnd);
            Utils.MaximizeWindow(hWnd);

            Console.WriteLine("All actions done!");
        }
    }
}
