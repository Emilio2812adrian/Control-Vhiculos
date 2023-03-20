using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Vhiculos
{
    class Alquiler
    {
        string nit;
        string Placa;
        string FechaAlq;
        string FechaDev;
        int KilometrosRec;

        public string Nit { get => nit; set => nit = value; }
        public string Placa1 { get => Placa; set => Placa = value; }
        public string FechaAlq1 { get => FechaAlq; set => FechaAlq = value; }
        public string FechaDev1 { get => FechaDev; set => FechaDev = value; }
        public int KilometrosRec1 { get => KilometrosRec; set => KilometrosRec = value; }
    }
}
