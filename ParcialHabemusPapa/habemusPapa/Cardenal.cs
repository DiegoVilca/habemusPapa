﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habemusPapa
{
    public class Cardenal
    {
        private int _cantVotosRecibidos;
        private ENacionalidades _nacionalildad;
        private string _nombre;
        private string _nombrePapal;


        #region Constructores

        private Cardenal()
        {
            this._cantVotosRecibidos = 0;
        }

        public Cardenal(string nombre, string nombrePapal) :this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;

        }

        public Cardenal(string nombre, string nombrePapal, ENacionalidades nacionalidad) :this (nombre, nombrePapal)
        {
            this._nacionalildad = nacionalidad;
        }


        #endregion Constructores


        #region Metodos

        public int getCantidadVotosRecibidos()
        {
            return this._cantVotosRecibidos;
        }


        public string ObtenerNombreYNombrePapal()
        {
            return ("El cardenal " + this._nombre + " se llamará \"papa " + this._nombrePapal + "\" ");  //Comando comillas \"
        }



        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine(ObtenerNombreYNombrePapal());
            sb.AppendLine("Nacionalidad: " + this._nacionalildad);
            sb.AppendLine("Votos Recibidos: " + this._cantVotosRecibidos);
            

            return sb.ToString();
            
        }


        public static string Mostrar(Cardenal c)
        {
            return c.Mostrar();
        }

        

        #endregion Metodos


        #region Sobrecargas


        public static bool operator ==(Cardenal c1, Cardenal c2)
        {
            return (c1._nombre == c2._nombre && c1._nombrePapal == c2._nombrePapal && c1._nacionalildad == c2._nacionalildad);
        }

        public static bool operator !=(Cardenal c1, Cardenal c2)
        {
            return !(c1 == c2);
        }

        public static Cardenal operator ++(Cardenal c)
        {
            c._cantVotosRecibidos++;

            return c;
        }

        

        #endregion Sobrecargas


    }
}
