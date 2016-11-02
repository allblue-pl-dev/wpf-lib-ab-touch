using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ABTouch
{
    public class ABTApp
    {

        static private Boolean Debug = false;

        static private System.Windows.Window Window = null;
        static private Grid View = null;


        static public void HideMouse(System.Windows.Window window)
        {
            Mouse.OverrideCursor = Cursors.None;
        }

        static public void Init(System.Windows.Window window, Grid view, Object main)
        {
#if DEBUG
            ABTApp.Debug = true;
#endif

            ABTApp.Window = window;
            ABTApp.View = view;

            // ABTApp.MakeFullScreen(window);
            if (!ABTApp.Debug)
                ABTApp.HideMouse(window);
        }

        static public void Init(System.Windows.Window window, Grid view, Object main,
                Boolean debug)
        {
            ABTApp.Init(window, view, main);
            ABTApp.Debug = debug;
        }

        static public void MakeFullScreen(System.Windows.Window window)
        {
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
        }

        static public void SetView(UserControl view)
        {
            ABTApp.View.Children.Clear();
            ABTApp.View.Children.Add(view);
        }

    }
}
