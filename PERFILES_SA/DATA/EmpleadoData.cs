using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PERFILES_SA.DATA
{
    public class EmpleadoData
    {
        public List<Empleado> LeerEmpleados()
        {
            var empleados = new List<Empleado>();

            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_LeerEmpleados", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado
                        {
                            IdEmpleado = (int)reader["IdEmpleado"],
                            Nombres = reader["Nombres"].ToString(),
                            DPI = reader["DPI"].ToString(),
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            Genero = Convert.ToChar(reader["Genero"]),
                            FechaIngreso = (DateTime)reader["FechaIngreso"],
                            Edad = (int)reader["Edad"],
                            Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : null,
                            NIT = reader["NIT"] != DBNull.Value ? reader["NIT"].ToString() : null,
                            Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                                Nombre = reader["Nombre"].ToString()
                            }
                        });
                    }
                }
            }
            return empleados;
        }

        public Empleado LeerEmpleado(int idEmpleado)
        {
            Empleado empleado = null;

            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_LeerEmpleado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        empleado = new Empleado
                        {
                            IdEmpleado = (int)reader["IdEmpleado"],
                            Nombres = reader["Nombres"].ToString(),
                            DPI = reader["DPI"].ToString(),
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            Genero = Convert.ToChar(reader["Genero"]),
                            FechaIngreso = (DateTime)reader["FechaIngreso"],
                            Edad = (int)reader["Edad"],
                            Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : null,
                            NIT = reader["NIT"] != DBNull.Value ? reader["NIT"].ToString() : null,
                            Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                                Nombre = reader["Nombre"].ToString()
                            }
                        };
                    }
                }
            }
            return empleado;
        }

        public bool CrearEmpleado(Empleado empleado)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_CrearEmpleado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                command.Parameters.AddWithValue("@DPI", empleado.DPI);
                command.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                command.Parameters.AddWithValue("@Genero", empleado.Genero);
                command.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", empleado.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NIT", empleado.NIT ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IdDepartamento", empleado.Departamento.IdDepartamento);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool ActualizarEmpleado(Empleado empleado)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_ActualizarEmpleado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                command.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                command.Parameters.AddWithValue("@DPI", empleado.DPI);
                command.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                command.Parameters.AddWithValue("@Genero", empleado.Genero);
                command.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);
                command.Parameters.AddWithValue("@Direccion", empleado.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NIT", empleado.NIT ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@IdDepartamento", empleado.Departamento.IdDepartamento);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool EliminarEmpleado(int idEmpleado)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_EliminarEmpleado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public List<Empleado> ObtenerReporteEmpleados(int? idDepartamento, bool? estado, DateTime? fechaIngresoInicio, DateTime? fechaIngresoFin)
        {
            var empleados = new List<Empleado>();

            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_ReporteEmpleados", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Parámetros opcionales para el filtro
                command.Parameters.AddWithValue("@IdDepartamento", (object)idDepartamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaIngresoInicio", (object)fechaIngresoInicio ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaIngresoFin", (object)fechaIngresoFin ?? DBNull.Value);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado
                        {
                            IdEmpleado = (int)reader["IdEmpleado"],
                            Nombres = reader["Nombres"].ToString(),
                            DPI = reader["DPI"].ToString(),
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            Edad = (int)reader["Edad"],
                            Genero = Convert.ToChar(reader["Genero"]),
                            FechaIngreso = (DateTime)reader["FechaIngreso"],
                            Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : null,
                            NIT = reader["NIT"] != DBNull.Value ? reader["NIT"].ToString() : null,
                            Departamento = new Departamento
                            {
                                IdDepartamento = idDepartamento.HasValue ? idDepartamento.Value : 0,
                                Nombre = reader["Departamento"].ToString(),
                                Estado = (bool)reader["EstadoDepartamento"]
                            }
                        });
                    }
                }
            }
            return empleados;
        }

    }
}