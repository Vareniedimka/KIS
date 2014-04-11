using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Zarplatnay_vedom:ForFind
    {

        public int Tabeln_nom { get; set; }
        public string FIO { get; set; }
        public int Zarabotn_Plata { get; set; }
        public int Raschet_zarabotn_platy { get; set; }
        
        public string get(string s)
        {
            switch (s)
            {
                case "ФИО": return FIO;
                case "Табельный номер": return Tabeln_nom.ToString();
                case "Заработная плата": return Zarabotn_Plata.ToString();
                case "Расчет заработной платы": return Raschet_zarabotn_platy.ToString();
                default: return "";
            }
           
        }
    }
}
