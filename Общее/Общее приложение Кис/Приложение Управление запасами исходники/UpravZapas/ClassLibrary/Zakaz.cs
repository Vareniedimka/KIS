using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Zakaz : ForFind
    {
        public int IDZakaza {get;set;}

        public int IDMateriala {get;set;}
        public string MaterialName { get; set; }
        
        public int Kolichestvo {get;set;}
        
        public DateTime? DataOform {get;set;}
        public DateTime? DataVipolneni { get; set; }
        
        public double Stoimost {get;set;}
        
        public string Status {get;set;}
        
        public int IDPostavhika {get;set;}
        public string PostavhikName { get; set; }

        public string DataOformString
        {
            get { return DataOform.Value.ToString("dd.MM.yyyy H:mm:ss"); }
        }

        public string DataVipolnString
        {
            get { return DataVipolneni==null?null:DataVipolneni.Value.ToString("dd.MM.yyyy H:mm:ss"); }
        }

        public string get(string s)
        {
            switch (s)
            {
                case "Материал": return MaterialName;
                case "Количество": return Kolichestvo.ToString();
                case "Дата оформления": return DataOformString.ToString();
                case "Дата закрытия": return DataVipolnString.ToString();
                case "Стоимость": return Stoimost.ToString();
                case "Статус": return Status;
                case "Поставщик": return PostavhikName;
                default: return "";
            }
        }
    }
}
