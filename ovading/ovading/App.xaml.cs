using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ovading.intf;
using ovading.serv;
using ovading.viewmod;

namespace ovading
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
      Iintf1 service = new intf1_impl1();
      I2 service2 = new i2();

      // 2. ViewModel mit Service verdrahten
      var vm = new MainVM(service);
      var vm2 = new i2VM(service2);

      // 3. ViewModel mit Daten füllen
      vm.Laden();
      vm2.Laden();

      // 4. Hauptfenster erzeugen und ViewModel übergeben
      var window = new MainWindow();
      window.DataContext = vm;
      window.DataContext = vm2;
      window.Show();
    }
  }
}
