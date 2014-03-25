using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class OtpuskSoSklada:ForFind
    {

        public int IDOtpusk { get; set; }

        public int IDMateriala { get; set; }
        public string MaterialName { get; set; }
        
        public int Kolichestvo { get; set; }
        
        public DateTime DataOtgruzk { get; set; }

        public string DataOtgruzkString
        {
            get { return DataOtgruzk.ToString("dd.MM.yyyy H:mm:ss"); }
            set { DataOtgruzk = Convert.ToDateTime(value); }
        }

        public string get(string s)
        {
            switch (s)
            {
                case "Материал": return MaterialName;
                case "Количество": return Kolichestvo.ToString();
                case "Дата отгрузки": return DataOtgruzkString;
                default: return "";
            }
           
        }
    }
}
