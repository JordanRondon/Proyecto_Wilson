﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logUser
    {
        #region sigleton
        private static readonly logUser _instancia = new logUser();
        public static logUser Instancia
        {
            get
            {
                return logUser._instancia;
            }
        }
        #endregion singleton
        
        #region metodos
        public bool validarContrasenia(string name, string contra)
        {
            return datUser.Instancia.validarContrasenia(name, contra);
        }
        public int obtenerrol(string name)
        {
            return datUser.Instancia.obtenerrol(name);
        }
        public void registrarUsuario(EntUsuario user)
        {
            datUser.Instancia.registrarUsuario(user);
        }
        public void cambiarcontraseña(String correo,String contraseña)
        {
            datUser.Instancia.cambiarcontraseña(correo,contraseña);
        }
        public void EliminaEmpleado(EntUsuario user)
        {
            datUser.Instancia.EliminarUsuario(user);
        }
        public List<EntRol> ListarRoles()
        {
            return datUser.Instancia.ListarRoles();
        }
        public void suspenderUsuario(EntUsuario user)
        {
            datUser.Instancia.suspenderUsuario(user);
        }
        public void habilitarUsuario(EntUsuario user)
        {
            datUser.Instancia.habilitarUsuario(user);
        }
        public bool verificarEstadoUsuario(String username)
        {
            return datUser.Instancia.verificarEstadoUsuario(username);
        }
        public bool validarEstructuraCorreo(string correo) => datUser.Instancia.validarEstructuraCorreo(correo);

        public bool validarEstructuraContrasenia(string password) => datUser.Instancia.validarEstructuraContrasenia(password);

        #endregion metodos
    }
}
