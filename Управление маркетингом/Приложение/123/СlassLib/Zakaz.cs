
namespace ClassLib
{
    /// <summary>
    /// Класс Врач
    /// </summary>
    public class Zakaz : Zapis
    {
        public int ID_zakaza {get;set;}

        public string ID_klienta {get;set;}
        public string ID_DCE { get; set; }

        public string KlientName { get; set; }
        public string NaimenovanieDCE { get; set; }
        public int Avans { get; set; }
        public string get(string s)
        {
            switch (s)
            {
                case "Название детали": return ID_DCE;
                case "Имя клиента": return ID_klienta;
                case "Аванс": return Avans.ToString();
            
                default: return "";
            }
        }
    }
}
