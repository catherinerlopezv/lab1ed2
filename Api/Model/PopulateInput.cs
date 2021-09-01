using System;
using System.Collections.Generic;

namespace Api.Model {
    public class PopulateInput {
        public List<int> elementos { get; set; }

        public PopulateInput () {
            elementos = new List<int>();
        }

        public override string ToString()
        {
            String datos = "";
            foreach (var item in elementos) {
                datos = datos + ", " + item;
            }
            return datos;
        }
    }
}