﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.ResultEntities
{
    class MedieMaterie
    {
        private string denumireMaterie;
        private double medie;

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

        public double Medie
        {
            get
            {
                return medie;
            }
            set
            {
                medie = value;
            }
        }
    }
}
