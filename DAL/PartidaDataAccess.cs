using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PartidaDataAccess
    {
        private readonly string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = DamasDB;";

        public int IniciarPartida(int jugador1ID, int jugador2ID, DateTime fechaInicio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spIniciarPartida", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Jugador1ID", jugador1ID);
                cmd.Parameters.AddWithValue("@Jugador2ID", jugador2ID);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()); // Retorna el ID de la partida iniciada
            }
        }

        public void FinalizarPartida(int partidaID, int ganadorID, DateTime fechaFin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spFinalizarPartida", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartidaID", partidaID);
                cmd.Parameters.AddWithValue("@GanadorID", ganadorID);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                conn.Open();
                cmd.ExecuteNonQuery(); // Ejecuta la actualización de la partida
            }
        }
    }
}