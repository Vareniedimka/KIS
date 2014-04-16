using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Oplata : Zapis
    {
       public int ID_oplati { get; set; }
       public DateTime DataSdelki { get; set; }
       public string Data { get { return DataSdelki.ToString("dd.MM.yyyy H:mm:ss"); } }
       public int Schet { get; set; }

       public string get(string s)
       {
           switch (s)
           {
               case "Дата": return Data;
               case "Счет": return Schet.ToString();
               default: return "";
           }
       }
    }
}
