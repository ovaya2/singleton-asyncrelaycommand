using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Singleton__asyncRelayCommands.ViewModels;

namespace Singleton__asyncRelayCommands
{
  /// <summary>
  /// Interaktionslogik für "App.xaml"
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      MainWindow = new MainWindow()
      {
        DataContext = new LoginViewModel()
      };

      //MainWindow.Show();

      base.OnStartup(e);
    }
  }
}
