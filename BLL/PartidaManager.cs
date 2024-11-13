using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class PartidaManager
    {
        private readonly PartidaDataAccess partidaDataAccess = new PartidaDataAccess();

        public int IniciarPartida(int jugador1ID, int jugador2ID)
        {
            return partidaDataAccess.IniciarPartida(jugador1ID, jugador2ID, DateTime.Now);
        }

        public void FinalizarPartida(int partidaID, int ganadorID)
        {
            partidaDataAccess.FinalizarPartida(partidaID, ganadorID, DateTime.Now);
        }

        public int AlternarTurno(int turnoActual, int jugador1ID, int jugador2ID)
        {
            return turnoActual == jugador1ID ? jugador2ID : jugador1ID;
        }
    }
}
