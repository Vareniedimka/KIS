using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Provodka : Zapis
    {
       public int ID_provodki { get; set; }
       public int ID_prodazhi { get; set; }
       public int ID_Pokupki { get; set; }
       public int ID_Oplaty { get; set; }
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
