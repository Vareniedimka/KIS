using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLP
{
    public class TovarVSdelke:Zapis
    {
        public DateTime Data { get; set; }
        public string Tovar {get;set;}
        public int IDSdelki { get; set; }
        public int IDTovar { get; set; }
        public bool PriznakOptovoi { get; set; }
        public int Kolichestvo { get; set; }

        public string DataVid { get { return Data.ToString("dd.MM.yyyy H:mm:ss"); } }


        public string get(string s)
        {
            switch (s)
            {
                case "Товар": return Tovar;
                case "Оптовая продажа": return PriznakOptovoi.ToString();
                case "Дата сделки": return DataVid;
                case "Количество": return Kolichestvo.ToString();
                default: return "";
            }
           
        }
    }
}
