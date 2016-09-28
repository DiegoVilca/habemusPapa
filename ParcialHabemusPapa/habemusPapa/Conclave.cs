using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habemusPapa
{
    public class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;


        #region constructores

        static Conclave()
        {
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Now;
        }

        private Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
        }

        private Conclave(int cantidadCardenales) 
        {
            
        }

        public Conclave(int cantidadCardenales, string lugarEleccion) :this(cantidadCardenales)
        {
            this._lugarEleccion = lugarEleccion;
        }

        

        #endregion constructores


        #region metodos

        

        private bool HayLugar()
        {
            if (this._cardenales.Count < this._cantMaxCardenales)
                return true;
            return false;
        }

        public string Mostrar()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Lugar de votacion: "+this._lugarEleccion);
            sb.AppendLine("Fecha de cotacion: "+fechaVotacion);
            sb.AppendLine("Cantidad de veces que se voto: " + cantidadVotaciones);

            if (this._habemusPapa)
            {
                sb.AppendLine("HABEMUS PAPA");
            }
            else
                sb.AppendLine("NO HABEMUS PAPA");

            return sb.ToString();
                 
        }

        private string MostrarCardenales()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Cardenal item in this._cardenales)
            {
                sb.AppendLine(Cardenal.Mostrar(item));
            }

            return sb.ToString();
        }

        public void VotarPapa(Conclave conclave)
        {
            Random votoRandom = new Random();

            int indicePapal = votoRandom.Next(0, this._cantMaxCardenales);

            for (int i = 0; i < conclave._cardenales.Count; i++)
            {
                if (i == indicePapal)
                {
                    conclave._cardenales.ElementAt(i);
                }
	
            }
        }

        private void ContarVotos(Conclave conclave)
        {

        }

        #endregion metodos



        #region sobrecargas y conversiones


        public static explicit operator bool(Conclave con)
        {
            return con._habemusPapa;
        }

        public static implicit operator Conclave(int cantidadCardenales)
        {
            return new Conclave(cantidadCardenales);
        }

        public static bool operator ==(Conclave con, Cardenal c)
        {
            foreach (Cardenal item in con._cardenales)
            {
                if (item == c)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Conclave con, Cardenal c)
        {
            return !(con == c);
        }

        public static Conclave operator +(Conclave con, Cardenal c)
        {
            if(con == c && con.HayLugar())
            {
                con._cardenales.Add(c);

            }

            return con;
        }



        #endregion sobrecargas y conversiones


    }
}
