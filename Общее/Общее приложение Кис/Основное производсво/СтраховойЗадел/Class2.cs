using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassBD
{
    public class Strahov_zadel
    {
        public string Naimenovanie_det { get; set; }
        public int Kolichestvo { get; set; }
        public DateTime Data_strahovogo_zadela { get; set; }
    }
    public class Meshcex_plan
    {
        public DateTime Data_nach_vip_plan_na_mesyc { get; set; }
        public DateTime Data_okonch_vip_plan_na_mesyc { get; set; }
        public int ID_DCE { get; set; }
        public string Naimenovanie_det { get; set; }
        public int Poryadok_vip_det { get; set; }
        public int Obhee_zaplan_kol { get; set; }
        public int Obhee_fact_kol { get; set; }
        public int Plan_det_den { get; set; }
        public int Fact_det_den { get; set; }
        public int Ostatok_sklad { get; set; }
        public int Neobh_vip { get; set; }
    }
    public class Plan_sbor_cexa
    {
        public DateTime Data_nach_vip_plan { get; set; }
        public DateTime Data_okonch_vip_plan { get; set; }
        public int Poryadok_vip_det { get; set; }
        public int Obhee_fact_kol { get; set; }
        public int Plan_det_den { get; set; }
        public int Fact_det_den { get; set; }
        public int ID_DCE { get; set; }
    }
    public class Plan_mehan_cexa
    {
        public DateTime Data_nach_vip_plan { get; set; }
        public DateTime Data_okonch_vip_plan { get; set; }
        public int Poryadok_vip_det { get; set; }
        public int Obhee_zaplan_kol { get; set; }
        public int Obhee_fact_kol { get; set; }
        public int Plan_det_den { get; set; }
        public int Fact_det_den { get; set; }
        public int Ostatok_sklad { get; set; }
        public int Neobh_vip { get; set; }
        public DateTime Data_strahovofgo_zadela { get; set; }
        public int ID_DCE { get; set; }
    }
    public class Operaciy_SZ
    {
        public int ID_operacii { get; set; }
        public int ID_marshrut { get; set; }
        public string Naimenovanie_operacii { get; set; }
        public int Time_schtucthn { get; set; }
        public int TimePZ { get; set; }
    }
    public class Otchet_o_vip_tov_plan
    {
        public DateTime Data_eshednevno { get; set; }
        public int Kolichestvo { get; set; }
        public int Nomer_izg_det { get; set; }
        public int ID_Izg_SE { get; set; }
    }
    public class Izg_SE
    {
        public int Nomer_izg_det { get; set; }
        public int ID_Izg_SE { get; set; }
        public int Invertatniy_nomer { get; set; }
        public DateTime Date_izg { get; set; }
        public string Viyavl_brak { get; set; }
        public int Nomer_partii { get; set; }
        public int Tabeln_nom { get; set; }
    }
    public class Smenno_sut_zad
    {
        public int Nomer_SSZ { get; set; }
        public int Tabeln_nomer { get; set; }
        public DateTime Data_nach_vip_plan { get; set; }
        public DateTime Data_okonch_vip_plan { get; set; }
        public int Cex { get; set; }
        public int ID_operacii { get; set; }
        public DateTime Date { get; set; }
        public int Smena { get; set; }
        public int Nomer_partii { get; set; }
        public int ID_DCE { get; set; }

    }

}
