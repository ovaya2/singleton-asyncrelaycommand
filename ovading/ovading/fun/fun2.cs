using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ovading.cont
{
  class fun2
  {
    public static void run()
    {
      // Delegate-Typ über Klassenname ansprechen
      fun1.tout d = text => Console.WriteLine(text + "!!!");
      d("Hallo Delegate 2");

      d = fun1.Gross; // ← kein Typ mehr — nur Zuweisung. `fun1.out d = ...` würde ein fehler "bereits definiert" ausgeben.
      d("Hallo Delegate 2");

    }
  }
}
