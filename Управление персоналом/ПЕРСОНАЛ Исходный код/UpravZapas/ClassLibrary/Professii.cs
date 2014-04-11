using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Professii : ForFind
    {
        public int ID_professii{ get; set; }

        public string Naimenovanie { get; set; }
        public string Razryad_rabochego { get; set; }
        
        public int Stavka_v_chas {get;set;}     

        public string get(string s)
        {
            switch (s){
               case "Наименование": return Naimenovanie;
              case "Ставка в час":return Stavka_v_chas.ToString();
              case "Разряд": return Razryad_rabochego;
                default :return "";
            }
        }
    }
}
