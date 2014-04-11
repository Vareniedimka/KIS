using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Rabociy:ForFind
    {
        public int Tabeln_nom { get; set; }
        public string FIO { get; set; }
        public string Naimenovanie { get; set; }
        public int IDProfesii { get; set; }
        public string Zareg_brak { get; set; }
        
        public string get(string s)
        {
            switch (s)
            {
                case "Табельный номер": return Tabeln_nom.ToString();
                case "ФИО": return FIO;
                case "Зарегестрированный брак": return Zareg_brak;
                case "Наименование": return Naimenovanie;
                default: return "";
            }
        }
    }
}
