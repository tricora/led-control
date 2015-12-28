using LedHttpServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LedWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpServer server;

        public MainWindow()
        {
            server = new HttpServer(9000);
            InitializeComponent();
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StartHttpServerCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !server.IsRunning;
        }

        private void StartHttpServerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            server.Start();
        }

        private void StopHttpServerCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = server.IsRunning;
        }

        private void StopHttpServerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            server.Stop();
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MainWindow1.Hide();
        }
    }
}
