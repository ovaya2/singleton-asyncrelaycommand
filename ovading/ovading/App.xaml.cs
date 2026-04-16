using System.Windows;
using ovading.intf;
using ovading.serv;
using ovading.viewmod;
using ovading.cont;

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
      I3 service3 = new i3();

      // 2. ViewModel mit Service verdrahten
      var vm = new MainVM(service);
      var vm2 = new i2VM(service2);
      var vm3 = new i3VM(service3);

      // 3. ViewModel mit Daten füllen
      vm.Laden();
      vm2.Laden();
      vm2.Drucken();
      vm3.Drucken();

      fun1.run();
      fun2.run();

      // 4. Hauptfenster erzeugen und ViewModel übergeben
      var window = new MainWindow();
      window.DataContext = vm;
      window.DataContext = vm2;
      window.DataContext = vm3;
      window.Show();
    }
  }
}
