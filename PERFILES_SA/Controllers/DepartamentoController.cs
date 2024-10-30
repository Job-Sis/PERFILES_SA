using PERFILES_SA.DATA;
using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PERFILES_SA.Controllers
{
    public class DepartamentoController
    {
        DepartamentoData departamentoData = new DepartamentoData();
        
        public List<Departamento> lista()
        {
            try
            {
                return departamentoData.LeerDepartamentos();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public Departamento Obtener(int idDepartamento)
        {
            try
            {
                return departamentoData.LeerDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Crear(Departamento entidad)
        {
            try
            {
                if(entidad == null)
                {
                    throw new OperationCanceledException("Departamento es necesario");
                }
                return departamentoData.CrearDepartamento(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Departamento entidad) 
        {
            try
            {
                var encontrado = departamentoData.LeerDepartamento(entidad.IdDepartamento);

                if(encontrado.IdDepartamento == null)
                    throw new OperationCanceledException("Departamento no existe");

                return departamentoData.ActualizarDepartamento(entidad);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idDepartamento)
        {
            try
            {
                var departamento = departamentoData.LeerDepartamento(idDepartamento);

                if(departamento.IdDepartamento == 0)
                {
                    throw new OperationCanceledException("Departamento no encontrado");
                }

                return departamentoData.EliminarDepartamento(idDepartamento);

            }catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}