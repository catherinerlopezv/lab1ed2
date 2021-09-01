using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Api;
using Api.Data;
using Api.Data.ArbolB;
using Api.Model;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArbolController : ControllerBase
    {   

        [HttpGet]
        public Arbol<int,int> Get()
        {
            return Singleton.GetInstance.miarbol;
        }

        [HttpGet("{recorrido}")]
        public List<int> Get([FromRoute] string recorrido)
        {
            if (recorrido == "in") {
                return Singleton.GetInstance.miarbol.RecorrerIn();
            } else if (recorrido == "post") {
                return Singleton.GetInstance.miarbol.RecorrerPost();
            }
            else if(recorrido=="pre"){
                 /*Singleton.GetInstance.miarbol.Mostrar()*/ ;
            }
            return new List<int>();
        }

        [HttpDelete]
        public ActionResult Delete() {
            Singleton.GetInstance.miarbol = new Arbol<int, int>(3);
            return Ok("Arbol Limpiado");
        }

        [HttpPost]
        public ActionResult Post([FromBody] JsonElement jsonobj)
        {
            try
            {
                JsonElement json = jsonobj.GetProperty("orden");
                int grado = json.GetInt32();
                if (grado < 3)
                {
                    Console.Write("No se aceptan menores a Grado 3");
                    return StatusCode(500);
                }
                Singleton.GetInstance.miarbol = new Arbol<int, int>(grado);
                return Ok("Se inicializa árbol con grado " + grado);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [Route("populate")]
        [HttpPost]
        public ActionResult Populate([FromBody] PopulateInput input)
        {
            Console.WriteLine("Ingresa a populate");
            Console.Write(input.ToString());
            try
            {
                int idx;
                for (idx = 0; idx < input.elementos.Count; idx++) {
                    int elemento = input.elementos[idx];
                    Singleton.GetInstance.miarbol.Insertar(elemento, 0);
                }
                return Ok("Se agregaron " + idx + " elementos");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Route("populate/{id}")]
        [HttpDelete("{id}")]
        public ActionResult PopulateDelete([FromRoute] int id)
        {
            try
            {
                Datos<int,int> datoABorrar = Singleton.GetInstance.miarbol.Buscar(id);
                if (datoABorrar == null) {
                    return NotFound();
                }
                Singleton.GetInstance.miarbol.Borrar(datoABorrar.Dato);
                return Ok("Se eliminó elemento " + id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }

}
