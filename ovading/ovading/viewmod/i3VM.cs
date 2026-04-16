using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ovading.intf;

namespace ovading.viewmod
{
  class i3VM
  {
    private readonly I3 _service;

    public i3VM(I3 service)
    {
      _service = service;

      _service.i = 1212;
      _service.s = "ssss";
    }

    public void Drucken()
    {
      Console.WriteLine("\nDrucken() in i3VM()");
      Console.WriteLine(_service.i);
    }
  }
}
