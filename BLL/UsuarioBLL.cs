﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDataAccess DataAccees = new UsuarioDataAccess();
        public void RegistrarUsuario(Jugador jugador)
        {
            DataAccees.RegistrarUsuario(jugador);
        }

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            return DataAccees.ValidarCredenciales(nombreUsuario, contraseña);
        }

        public Jugador GetUsuario(Jugador jugador) 
        { 
           return DataAccees.GetUsuario(jugador);
        }

        public Jugador GetUsuario(int UsuarioID)
        {
            return DataAccees.GetUsuario(UsuarioID);
        }
    }
}