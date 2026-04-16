using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ovading.intf;

namespace ovading.serv
{
  class i2 : I2
  {
    public int i { get; set; }
    public string s { get; set; }

    public i2()
    {
      Console.WriteLine(i);
    }
  }
}
