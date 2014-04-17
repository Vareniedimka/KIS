using System;

namespace СlassLib
{
     public class DCE
    {
        public int ID_DCE { get; set; }
        public string Naimenovanie { get; set; }
        public int Norma_rashoda { get; set; }
        public int ID_materiala { get; set; }
        /// <summary>
        /// Сборочная единица
        /// </summary>
        public int SE { get; set; }
        /// <summary>
        /// Покупное изделие
        /// </summary>
        public int PE { get; set; }
        public int Detal { get; set; }

    }
}
