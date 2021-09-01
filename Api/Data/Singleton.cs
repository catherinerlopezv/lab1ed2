using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Data.ArbolB;

namespace Api.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public Arbol<int, int> miarbol { get; set; }
        
        private Singleton()
        {
            
            this.miarbol = new Arbol<int, int>(3);
            miarbol.Insertar(10, 0); // valor, puntero
            miarbol.Insertar(1, 1);
            miarbol.Insertar(7, 2);
            miarbol.Insertar(3, 3);
            miarbol.Insertar(5, 4);
            miarbol.Insertar(15, 5);
            miarbol.Insertar(12, 6);   
        }

        public static Singleton GetInstance
        {
            get
            {
                return _instance;
            }
        }
    }
}
