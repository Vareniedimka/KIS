using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Kredit: Zapis
    {
       public int ID_kredita { get; set; }
       public int Summa { get; set; }
       public DateTime DataSdelki { get; set; }
       public string Data { get { return DataSdelki.ToString("dd.MM.yyyy H:mm:ss"); } }

       public string get(string s)
       {
           switch (s)
           {
               case "Сумма": return Summa.ToString();
               case "Дата": return Data;
               default: return "";
           }
       }
    }
}
