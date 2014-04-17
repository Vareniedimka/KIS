using System;

namespace ClassLib
{
    public class TovarnPlan : Zapis
    {
        public int ID_plana { get; set; }
        public int ID_zakaza { get; set; }
        public string KlientName { get; set; }

        public int ID_klienta { get; set; }
        public string NameIdDcE { get; set; }
        public int ID_DCE { get; set; }
        public int ID_prodazhi { get; set; }

        public int ID_producta { get; set; }

        public string Naimenovanie_produkta { get; set; }

        public DateTime Data_proizv { get; set; }



        public int Kolichestvo { get; set; }

        public string Prioritet { get; set; }
        public double Cena_detaly { get; set; }

        public float Obhaya_stoimos { get; set; }



        public string get(string s)
        {
            switch (s)
            {
                case "Имя Клиента": return KlientName;
                case "Наименование деталей": return NameIdDcE ;
                case "Наименование продука": return Naimenovanie_produkta;
                case "Количество": return Kolichestvo.ToString();
                case "Цена деталей": return Cena_detaly.ToString();
                case "Общая стоимость": return Obhaya_stoimos.ToString() ;
                case "Приоритет": return Prioritet;
                case "Дата производство": return Data_proizv.ToString();

                default: return "";
            }
        }
    }
}
