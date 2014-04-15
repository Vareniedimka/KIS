using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Uchet: Zapis
    {
       public int Summa { get; set; }

       public string get(string s)
       {
           switch (s)
           {
               case "Сумма": return Summa.ToString();

               default: return "";
           }
       }
    }
}
