using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class prodazhi : Zapis
    {
        public int ID_prodazhi { get; set; }
        public DateTime DataSdelki { get; set; }
        public int Nomer_raschetnogo_platesha { get; set; }
        public string Data { get { return DataSdelki.ToString("dd.MM.yyyy H:mm:ss"); } }
        public string Opisanie { get; set; }

        public string get(string s)
        {
            switch (s)
            {
                case "Дата": return DataSdelki.ToString();
                case "Номер расчетного платежа": return Nomer_raschetnogo_platesha.ToString();
                case "Описание": return Opisanie;
                default: return "";
            }
        }
    }
}
