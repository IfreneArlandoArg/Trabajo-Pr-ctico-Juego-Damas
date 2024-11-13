using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BitacoraDataAccess
    {
        private readonly string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = DamasDB;";

        public void RegistrarEvento(int usuarioID, string tipoEvento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRegistrarEvento", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                cmd.Parameters.AddWithValue("@TipoEvento", tipoEvento);
                cmd.Parameters.AddWithValue("@FechaHora", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}