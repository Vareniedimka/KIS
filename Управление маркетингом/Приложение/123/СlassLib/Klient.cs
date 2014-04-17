using System;

namespace ClassLib
{
    /// <summary>
    /// Класс Пациент
    /// </summary>
    public class Klient : Zapis
    {
        public int ID_klienta { get; set; }

        public string Name_klienta { get; set; }

        public string LS { get; set; }

        public string get(string s)
        {
            switch (s)
            {
                case "ФИО": return Name_klienta;
                case "Лицевой счет": return LS;
          
                default: return "";
            }
        }
    }
}
