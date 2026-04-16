using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ovading.cont
{
  class fun1
  {
    public delegate void tout(string text);

    public static void Gross(string text)
    {
      Console.WriteLine(text.ToUpper());
    }

    public static void Klein(string text)
    {
      Console.WriteLine(text.ToLower());
    }

    public static void run()
    {
      tout d = Gross;
      d("Hallo Delegate 1.");
    }
  }
}
