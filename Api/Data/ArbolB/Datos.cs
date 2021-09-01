using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.ArbolB
{
    public class Datos<TK,TP>:IEquatable<Datos<TK,TP>>
    {
        public TK Dato { get; set; }
        public TP Apuntador { get; set; }
          public bool Equals(Datos<TK, TP> other)
        {
            return this.Dato.Equals(other.Dato) && this.Apuntador.Equals(other.Apuntador);
        }
    }
}
