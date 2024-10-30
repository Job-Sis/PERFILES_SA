using PERFILES_SA.DATA;
using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PERFILES_SA.Controllers
{
    public class EmpleadoController
    {
        EmpleadoData empleadoData = new EmpleadoData();

        public List<Empleado> Lista()
        {
            try
            {
                return empleadoData.LeerEmpleados();
            }catch (Exception ex)
            {
                throw ex;
            }
        } 

        public Empleado Obtener(int idEmpleado)
        {
            try
            {
                return empleadoData.LeerEmpleado(idEmpleado);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(Empleado entidad)
        {
            try
            {
                if(entidad == null)
                    throw new OperationCanceledException("Empleado es necesario");

                return empleadoData.CrearEmpleado(entidad);
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Editar(Empleado entidad)
        {
            try
            {
                var empleado = empleadoData.LeerEmpleado(entidad.IdEmpleado);

                if (empleado.IdEmpleado == null)
                    throw new OperationCanceledException("Empleado no existe");

                return empleadoData.ActualizarEmpleado(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(int idEmpleado)
        {
            try
            {
                var empleado = empleadoData.LeerEmpleado(idEmpleado);

                if (empleado.IdEmpleado == 0)
                    throw new OperationCanceledException("Empleado no encontrado");

                return empleadoData.EliminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> ObtenerReporteEmpleados(int? idDepartamento, bool? estado, DateTime? fechaIngresoInicio, DateTime? fechaIngresoFin)
        {
            try
            {
                // Llama al método de datos que ejecuta el procedimiento almacenado para el reporte
                return empleadoData.ObtenerReporteEmpleados(idDepartamento, estado, fechaIngresoInicio, fechaIngresoFin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}