﻿using System;
using Newtonsoft.Json;

namespace mobile1.Modelos
{
    public class Producto
    {

        [JsonProperty ("Name")]
        public string Nombre { get; set; }

        [JsonProperty("Price")]
        public double Precio { get; set; }

        [JsonProperty("Quantity")]
        public double Cantidad { get; set; }
    
    

    }
}
