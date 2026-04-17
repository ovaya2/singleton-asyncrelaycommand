using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ova1.I;

namespace ova1.fun
{
  class ifun1 : I1
  {
    public string s { get; set; }
    public int i { get; set; }

    public void if1I1()
    {
      Console.WriteLine("ifI1 aus I1.cs hier - 1");
    }

    public ifun1()
    {
      i = 191;
      Console.WriteLine(i);
    }
  }
}
