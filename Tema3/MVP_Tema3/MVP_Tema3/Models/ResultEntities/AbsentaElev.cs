using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.ResultEntities
{
    class AbsentaElev
    {
        private string data;
        private string denumireMaterie;


        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

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
    }
}
