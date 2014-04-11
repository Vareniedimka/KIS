using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Detdlyarem   : ForFind
    {
        

        public string NaimenovanieDet { get; set; }
        
        public double Kolichestv {get;set;}
        public string get(string s)
        
        {
            switch (s){
                case "Название детали": return NaimenovanieDet;
                case "Количество":return Kolichestv.ToString();
                 default :return "";
            }
        }
    }
}
