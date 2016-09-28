using System;
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

        public int getCantidadVostosRecibidos()
        {
            return this._cantVotosRecibidos;
        }


        public string ObtenerNombreYNombrePapal()
        {
            return ("El cardenal " + this._nombre + " se llamara " + this._nombrePapal);
        }



        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nacionalidad: " + this._nacionalildad);
            sb.AppendLine("Votos Recibidos: " + this._cantVotosRecibidos);
            sb.AppendLine(ObtenerNombreYNombrePapal());

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
            return c1._nombre == c2._nombre;
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
