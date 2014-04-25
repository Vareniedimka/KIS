using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Material : ForFind
    {
        public int IDMateriala { get; set; }

        public string Name { get; set; }
        
        public double Cena {get;set;}
        
        public string EdinIzm { get; set; }

        public string get(string s)
        {
            switch (s){
                case "Название": return Name;
                case "Цена":return Cena.ToString();
                case "Единица измерения": return EdinIzm;
                default :return "";
            }
        }
    }
}
