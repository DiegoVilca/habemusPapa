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
        private static Random votoRandom; //Puedo agregar cambios mientras no se cambie la funcionalidad del sistema
        



        #region constructores

        static Conclave() //El constructor static no acepta modificadores de acceso, es privado (ver diagrama de clases)
        {
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Now;

            votoRandom = new Random(); //Puedo agregar cambios mientras no se cambie la funcionalidad del sistema
        }

        public Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            this._cardenales = new List<Cardenal>();
        }

        private Conclave(int cantidadCardenales) :this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarEleccion) :this(cantidadCardenales)
        {
            
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

            sb.AppendLine("Lugar de la elección: "+this._lugarEleccion);
            sb.AppendLine("Fecha: "+fechaVotacion);
            sb.AppendLine("Cantidad de votaciones: " + cantidadVotaciones);

            if (this._habemusPapa)
            {
                sb.AppendLine("HABEMUS PAPA!!!!\n");
                sb.AppendLine(this._papa.ObtenerNombreYNombrePapal());
                
            }
            else
            {
                sb.AppendLine("NO HABEMUS PAPA!!!!");
                
                sb.AppendLine("\nCARDENALES\n");

                sb.AppendLine(MostrarCardenales());
            
            }
                


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

        public static void VotarPapa(Conclave conclave)
        {
            //Votacion por cardenal
            for (int i = 0; i < conclave._cardenales.Count; i++)
            {

                int indicePapal = Conclave.votoRandom.Next(0, conclave._cardenales.Count);
                //Asignacion del voto de cada cardenal
                for (int j = 0; j < conclave._cardenales.Count; j++)
                {
                    if (j == indicePapal)
                    {
                        conclave._cardenales[j]++;
                        break;
                    }

                }
            }
                
            
            //Resultado Votacion
            ContarVotos(conclave);

        }
            

        private static void ContarVotos(Conclave conclave)
        {

            for (int i = 0; i < conclave._cardenales.Count; i++)
            {
                if (i == 0) //Evito comparar a los cardenales con un papa en null
                {
                    conclave._papa = conclave._cardenales[i];
                    conclave._habemusPapa = true;
                    continue;
                }


                if (conclave._cardenales[i].getCantidadVotosRecibidos() > conclave._papa.getCantidadVotosRecibidos())
                {
                    conclave._papa = conclave._cardenales[i];
                    conclave._habemusPapa = true;
                }
            }
            
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
            if (con == c)
            {
                Console.WriteLine("El cardenal ya está en el Cónclave!!!");
            }

            if (con.HayLugar() == false)
            {
                Console.WriteLine("No hay más lugar!!!");
            }

            if (con != c && con.HayLugar())
            {
                con._cardenales.Add(c);

            }

            return con;
        }



        #endregion sobrecargas y conversiones


    }
}
