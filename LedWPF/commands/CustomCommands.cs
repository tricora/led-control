using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LedWPF.commands
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection() {
                new KeyGesture(Key.Q, ModifierKeys.Control)
            });

        public static readonly RoutedUICommand StartHttpServer = new RoutedUICommand(
            "Start the HTTP server",
            "StartHttpServer",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R, ModifierKeys.Control)
            });

        public static readonly RoutedUICommand StopHttpServer = new RoutedUICommand(
            "Stop the HTTP server",
            "StopHttpServer",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            });
    }
}
