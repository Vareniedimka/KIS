using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassBD
{
    public class DSE
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
        public string Zhel { get; set; }
        public string material { get; set; }

    }

    public class MarshrytKarta
    {
        public int IdMarshrut { get; set; }
        public string Cex { get; set; }
        public int IdOperacii { get; set; }
        public int InvNom { get; set; }
        public int IdProf { get; set; }
        public double TimeSht { get; set; }
        public double TimePZ { get; set; }
        public int ID_DCE { get; set; }
        public string name { get; set; }
        public string model { get; set; }


    }
    public class NepPrem
    {
        public int IzdKuda { get; set; }
        public int IzdChto { get; set; }
        public int Kolichestvo { get; set; }
        public string Primichanie { get; set; }
        public int IDdse { get; set; }
        public string name_chto { get; set; }
        public string name_kuda { get; set; }
        


    }

    public class PolPrem
    {
        public int DSEKuda { get; set; }
        public int DSEChto { get; set; }
        public int Kolichestvo { get; set; }
        public int Ikuda { get; set; }
        public int Ichto { get; set; }
        public string name_chto { get; set; }
        public string name_kuda { get; set; }

    }

    public class Materialy
    {
        public string Name { get; set; }
        public int IDMateriala { get; set; }
    }

    public class InvN
    {
        public string model { get; set; }
        public int InvNom { get; set; }
    }

    public class Prof
    {
        public string name { get; set; }
        public int IdProf { get; set; }
    }
    public class Storonee
    {
        public static int IDDseMK { get; set; }
    }
}
