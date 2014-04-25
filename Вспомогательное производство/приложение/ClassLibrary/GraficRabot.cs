using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class GraficRabot : ForFind
    {

        public string PlanProverkOborud { get; set; }

        public DateTime VnepanRem { get; set; }
        public char NaimenovanieDet { get; set; }

        public int InvertatniyNomer { get; set; }

        public DateTime DateNachRemont { get; set; }

        public DateTime DataOkonchRem { get; set; }
        public int Raschetn_koef { get; set; }


        public string get(string s)
        {
            switch (s)
            {
                case "План проверки": return PlanProverkOborud;
                case "Внеплановый ремонт": return VnepanRem.ToString();
                case "Наименование детали": return NaimenovanieDet.ToString();
                case "Инвентарный номер": return InvertatniyNomer.ToString();
                case "Дата начала ремонта": return DateNachRemont.ToString();
                case "Рассчет коэффицентов": return Raschetn_koef.ToString();
                case "Дата окончания ремонта": return DataOkonchRem.ToString();
                default: return "";
            }

        }
    }
}
    

