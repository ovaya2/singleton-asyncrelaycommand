using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ovading.intf;
using ovading.serv;

namespace ovading.viewmod
{
  class MainVM
  {
    private readonly Iintf1 _service;

    // Konstruktor bekommt die Implementierung von aussen (Dependency Injection)
    public MainVM(Iintf1 service)
    {
      _service = service;

      Iintf1 obj1 = new intf1_impl1();
      obj1.int1 = 22;
      obj1.str1 = "Holla";
    }

    public void Laden()
    {
      _service.int1 = 10;
      _service.str1 = "Geladen";
    }
  }
}
