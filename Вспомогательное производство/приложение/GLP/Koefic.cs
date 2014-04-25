using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLP;

namespace GLP
{
    public class Koefic
    {
        public List<string> kranList = new List<string>();

        double[,] bMal;

        public void generateKoef()
        {
            var n = MaterialDao.GetAll().Count;
            var m = kranList.Count;

            bMal = new double[n,m];
        }
    }
}
