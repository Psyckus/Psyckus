using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<usuario> Listar()
        {
            List<usuario> lista = new List<usuario>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select u.idUsuario, u.identificacion, u.nombre, u.apellido,");
                    sb.AppendLine("u.email,  u.clave, u.Reestablecer, r.idRol, r.nombre[Rol],");
                    sb.AppendLine("i.idTipoIdentificacion, i.nombre[Tipo] , u.activo ");
                    sb.AppendLine("from usuario u");
                    sb.AppendLine("inner join rol r on r.idRol = u.idRol");
                    sb.AppendLine("inner join tipoIdentificacion i on i.idTipoIdentificacion = u.tipoIdentificacion");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                identificacion = Convert.ToInt32(dr["identificacion"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                email = dr["email"].ToString(),
                                clave = dr["clave"].ToString(),
                                Reestablecer = Convert.ToBoolean(dr["Reestablecer"]),
                                orol = new rol {idRol = Convert.ToInt32(dr["idRol"]), nombre = dr["Rol"].ToString()},
                                otipoIdentificacion = new tipoIdentificacion { idTipoIdentificacion = Convert.ToInt32(dr["idTipoIdentificacion"]), nombre = dr["Tipo"].ToString() },
                                activo = Convert.ToBoolean(dr["activo"])


                            });
                        }
                    }


                }
            }
            catch (Exception)
            {
                lista = new List<usuario>();
            }
            return lista;

        }
        public bool CambiarClave(int idusuario, string nuevaclave, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update usuario set clave = @nuevaclave, Reestablecer = 0 where idusuario = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", idusuario);
                    cmd.Parameters.AddWithValue("@nuevaclave", nuevaclave);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;


                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;

            }
            return resultado;
        }
        public bool ReestablecerClave(int idusuario, string clave, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update usuario set clave = @clave, Reestablecer = 1 where idusuario = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", idusuario);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;

            }
            return resultado;
        }

    }
}
