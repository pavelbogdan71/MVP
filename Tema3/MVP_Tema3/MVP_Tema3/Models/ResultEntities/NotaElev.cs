using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.ResultEntities
{
    class NotaElev
    {
        private string denumireMaterie;
        private double nota;

        public string DenumireMaterie
        {
            get
            {
                return denumireMaterie;
            }
            set
            {
                denumireMaterie = value;
            }
        }

        public double Nota
        {
            get
            {
                return nota;
            }
            set
            {
                nota = value;
            }
        }
    }
}
