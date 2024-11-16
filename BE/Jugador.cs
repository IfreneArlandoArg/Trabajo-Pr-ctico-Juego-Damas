using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    
    public class Jugador
    {
        public int JugadorID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        
        public Jugador(string jugadorID, string nombreUsuario, string contraseña)
        {
            JugadorID = int.Parse(jugadorID);
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }

        public Jugador( string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }

    }

}
