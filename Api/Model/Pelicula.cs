using System;


namespace Api.Model
{
    public class Pelicula

    {
         public string director { get => director; set => director = value; }
         public int estrellas { get => estrellas; set => estrellas = value; }
         public string genero { get => genero; set => genero = value; }
         public int anio { get => anio; set => anio = value; }
         public int raiting { get => raiting; set => raiting = value; }
         public string titulo { get => titulo; set => titulo = value; }


         public override string ToString()
         {
             return "{" + director + ", " + estrellas + ", " + genero + ", " + anio + ", " + raiting + ", " +titulo+ "}";
         }
        
       /* public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }*/
    }
}

