﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaAssicurazioni_Week7_MariaDeStefano.Models
{
    public class Furto:Polizza
    {
        public int PercentualeCopertura { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Percentuale: {PercentualeCopertura}";
        }

    }
}
