using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ova1.I;
using ova1.fun;

namespace ova1
{
  /// <summary>
  /// Interaktionslogik für "App.xaml"
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      // 1. Implementierung erzeugen
      I1 iserv1 = new ifun1();

      // 2. 

      var window = new MainWindow();
      window.DataContext = iserv1;
      window.Show();
    }
  }
}
