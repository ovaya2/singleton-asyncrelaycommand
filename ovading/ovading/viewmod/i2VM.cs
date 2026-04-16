using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ovading.serv;
using ovading.intf;

namespace ovading.viewmod
{
  class i2VM
  {
    private readonly I2 _service;
    public i2VM(I2 service)
    {
      _service = service;
    }

    public void Laden()
    {
      _service.i = 777;
      _service.s = "I2 hier!";
    }
  }
}
