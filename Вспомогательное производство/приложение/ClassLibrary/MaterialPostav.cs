using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class MaterialPostav:ForFind
    {
        public int IDMateriala { get; set; }
        public string MaterialName { get; set; }

        public int IDPostavhik { get; set; }
        public string PostavhikName { get; set; }
        
        public string get(string s)
        {
            switch (s)
            {
                case "Поставщик": return PostavhikName;
                case "Материал": return MaterialName;
                                
                default: return "";
            }
        }
    }
}
