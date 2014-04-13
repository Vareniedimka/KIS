using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Stanok_na_proizv:ForFind
    {
        public string Invertatniy_nomer { get; set; }
        public double God_vipuska { get; set; }

        public string Model { get; set; }
        public string God_vvedeniya_v_expluat { get; set; }
        

        
        public string get(string s)
        {
            switch (s)
            {
                case "Инвентарный номер": return Invertatniy_nomer;
                case "Модель": return Model;
                case "Год введения в эксплуатацию": return God_vvedeniya_v_expluat;
                           
                default: return "";
            }
        }
    }
}
