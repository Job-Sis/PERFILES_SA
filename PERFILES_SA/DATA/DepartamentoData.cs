using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PERFILES_SA.DATA
{
    public class DepartamentoData
    {
        // Método para obtener todos los departamentos
        public List<Departamento> LeerDepartamentos()
        {
            var departamentos = new List<Departamento>();

            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_LeerDepartamentos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departamentos.Add(new Departamento
                        {
                            IdDepartamento = Convert.ToInt32(reader["IdDepartamento"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            Estado = (bool)reader["Estado"],
                            FechaCreacion = (DateTime)reader["FechaCreacion"]
                        });
                    }
                }
            }
            return departamentos;
        }

        // Método para obtener un departamento específico por ID
        public Departamento LeerDepartamento(int idDepartamento)
        {
            Departamento departamento = null;

            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_LeerDepartamento", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        departamento = new Departamento
                        {
                            IdDepartamento = (int)reader["IdDepartamento"],
                            Nombre = reader["Nombre"].ToString(),
                            Estado = (bool)reader["Estado"],
                            FechaCreacion = (DateTime)reader["FechaCreacion"]
                        };
                    }
                }
            }
            return departamento;
        }

        // Método para crear un nuevo departamento
        public bool CrearDepartamento(Departamento departamento)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_CrearDepartamento", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para actualizar un departamento existente
        public bool ActualizarDepartamento(Departamento departamento)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_ActualizarDepartamento", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdDepartamento", departamento.IdDepartamento);
                command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                command.Parameters.AddWithValue("@Estado", departamento.Estado);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Método para deshabilitar (eliminar lógicamente) un departamento
        public bool EliminarDepartamento(int idDepartamento)
        {
            using (SqlConnection connection = new SqlConnection(ConexionDB.cn))
            using (SqlCommand command = new SqlCommand("sp_EliminarDepartamento", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}