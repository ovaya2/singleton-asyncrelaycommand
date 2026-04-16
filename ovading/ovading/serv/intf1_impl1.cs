using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ovading.intf;

namespace ovading.serv
{
  class intf1_impl1 : Iintf1
  {
    public int int1 { get; set; }
    public string str1 { get; set; }

    public intf1_impl1()
    {
      str1 = "bbbba";
      Console.WriteLine(str1);
    }
  }
}
