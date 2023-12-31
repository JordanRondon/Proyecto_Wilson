﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace CapaDatos
{
    public class datUser
    {
        #region sigleton
        private static readonly datUser _instancia = new datUser();
        public static datUser Instancia
        {
            get
            {
                return datUser._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<EntRol> ListarRoles()
        {
            SqlCommand cmd = null;
            List<EntRol> lista = new List<EntRol>();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("spListarRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntRol rol = new EntRol();
                    rol.idrol = Convert.ToInt32(dr["IdRol"]);
                    rol.rolname = Convert.ToString(dr["rolname"]);

                    lista.Add(rol);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        public bool validarContrasenia(string name, string contra)
        {
            SqlCommand cmd = null;
            bool validacion = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("buscarUser", cn);
                cmd.Parameters.AddWithValue("@user", name);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                EntUsuario user = new EntUsuario();
                user.username = dr["username"].ToString();
                user.contrasenia = dr["contraseña"].ToString();
                if (contra == user.contrasenia)
                {
                    validacion = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return validacion;
        }
        public int obtenerrol(string name)
        {
            SqlCommand cmd = null;
            int userrol;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton
                cmd = new SqlCommand("buscarUser", cn);
                cmd.Parameters.AddWithValue("@user", name);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                EntUsuario user = new EntUsuario();
                user.username = dr["username"].ToString();
                user.contrasenia = dr["contraseña"].ToString();
                user.rol = Convert.ToInt32(dr["IDRol"]);
                userrol = user.rol;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return userrol;
        }
        public Boolean registrarUsuario(EntUsuario user)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("pa_registrar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user.username);
                cmd.Parameters.AddWithValue("@contra", user.contrasenia);
                cmd.Parameters.AddWithValue("@dni", user.dni);
                cmd.Parameters.AddWithValue("@telefono", user.telefono);
                cmd.Parameters.AddWithValue("@apellidos", user.apellido);
                cmd.Parameters.AddWithValue("@nombres", user.nombres);
                cmd.Parameters.AddWithValue("@rol", user.rol);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        public Boolean cambiarcontraseña(string correo,string contraseña)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("pa_cambiar_contraseña", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        public Boolean EliminarUsuario(EntUsuario user)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("pa_eliminar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iduser", user.idusuario);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    delete = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return delete;
        }

        public bool validarEstructuraCorreo(string correo)
        {
            string patron = @"^[a-zA-Z0-9]+([._-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+(\.[a-zA-Z]{2,})+$";
            return Regex.IsMatch(correo, patron);
        }
      
        public Boolean suspenderUsuario(EntUsuario user)
        {

            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("pa_suspender_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user.username);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        public Boolean habilitarUsuario(EntUsuario user)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("pa_habilitar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user.username);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        public Boolean verificarEstadoUsuario(String usuario)
        {
            SqlCommand cmd = null;
            bool validacion = false;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("buscarUser", cn);
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                EntUsuario user = new EntUsuario();
                user.username = dr["username"].ToString();
                user.estado = Convert.ToInt32(dr["estado"]);
                if (user.estado==1)
                {
                    validacion = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return validacion;
        }

        public bool validarEstructuraContrasenia(string password)
        {
            string patron = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#\$%&]).{8,}$";
            return Regex.IsMatch(password, patron);
        }
        #endregion metodos
    }
}
