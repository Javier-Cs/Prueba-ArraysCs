﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.interfaces
{
    internal interface IManejable
    {
        void Mover();
        void Detener();
        string TipoVehiculo { get; set; }
    }
}
