using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Postavhik : ForFind
    {
        public int IDPostavhik {get;set;}

        public string Name { get; set; }
        public string Adres { get; set; }
        public string Phone { get; set; }
        public string NomerScheta { get; set; }

        public string get(string s)
        {
            switch (s){
                case "Наименование": return Name;
                case "Адрес": return Adres;
                case "Телефон": return Phone;
                case "Номер счета": return NomerScheta; 
                default :return "";
            }
        }
    }
}
