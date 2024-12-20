﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;


namespace DAL
{
    public class UsuarioDataAccess
    {
        private readonly string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = DamasDB;";

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spValidarCredenciales", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public void RegistrarUsuario(Jugador jugador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRegistrarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", jugador.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", jugador.Contraseña);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Jugador GetUsuario(Jugador jugador)
        {
            Jugador tempUser = jugador;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreUsuario", jugador.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", jugador.Contraseña);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tempUser = new Jugador(reader["UsuarioID"].ToString(), reader["NombreUsuario"].ToString(), reader["Contraseña"].ToString());
                }
            }

            return tempUser;
        }

        public Jugador GetUsuario(int UsusarioID)
        {
            Jugador tempUser = null;

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("spGetUsuarioByID", conn);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", UsusarioID);


                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tempUser = new Jugador(reader["UsuarioID"].ToString(), reader["NombreUsuario"].ToString(), reader["Contraseña"].ToString());
                }

            }

            return tempUser;
        }
    }
}
