using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Zapas : ForFind
    {
        public int IDMateriala {get;set;}
        public string MaterialName { get; set; }

        public int Kolichestvo { get; set; }

        public string get(string s)
        {
            switch (s){
                case "Матерьял": return MaterialName;
                case "Количество": return Kolichestvo.ToString();
                default :return "";
            }
        }
    }
}
