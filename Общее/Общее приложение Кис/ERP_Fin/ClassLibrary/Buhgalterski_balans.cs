using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Buhgalterski_balans : Zapis
    {
        public int IDByc_balans { get; set; }
        public int Debit { get; set; }
        public int Kredit { get; set; }
        public int Balans { get; set; }

        public string get(string s)
        {
            switch (s)
            {
                case "Дебит": return Debit.ToString();
                case "Кредит": return Kredit.ToString();
                case "Баланс": return Balans.ToString();
                default: return "";
            }
        }
    }
}
