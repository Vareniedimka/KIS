using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Pokupki : Zapis
    {
       public int ID_Pokupki { get; set; }
       public int Nomer_raschetnogo_platesha { get; set; }
       public int Count { get; set; }
       //Триггер на оплату

       public string get(string s)
       {
           switch (s)
           {
               case "Наименование": return Nomer_raschetnogo_platesha.ToString();
               case "Стоимость": return Count.ToString();
              // case "Баланс": return Balans.ToString();
               default: return "";
           }
       }
    }
}
