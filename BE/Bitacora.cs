using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    
    public class Bitacora
    {
        public int EventoID { get; set; }
        public int UsuarioID { get; set; }
        public string TipoEvento { get; set; }
        public DateTime FechaHora { get; set; }

    

        
        public Bitacora(int eventoID, int usuarioID, string tipoEvento, DateTime fechaHora)
        {
            EventoID = eventoID;
            UsuarioID = usuarioID;
            TipoEvento = tipoEvento;
            FechaHora = fechaHora;
        }
    }

}