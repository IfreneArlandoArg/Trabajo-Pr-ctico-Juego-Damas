using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{

    public class Partida
    {
        public int PartidaID { get; set; }
        public int Jugador1ID { get; set; }
        public int Jugador2ID { get; set; }
        public int? GanadorID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        
        public Partida(int partidaID, int jugador1ID, int jugador2ID, int? ganadorID, DateTime fechaInicio, DateTime? fechaFin = null)
        {
            PartidaID = partidaID;
            Jugador1ID = jugador1ID;
            Jugador2ID = jugador2ID;
            GanadorID = ganadorID;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }

}