using PERFILES_SA.Controllers;
using PERFILES_SA.DATA;
using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PERFILES_SA
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        EmpleadoController empleadosController = new EmpleadoController();
        DepartamentoController departamentoController = new DepartamentoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDepartamentos();
            }
        }

        private void CargarDepartamentos()
        {
            List<Departamento> departamentos = departamentoController.lista();
            ddlDepartamento.DataSource = departamentos;
            ddlDepartamento.DataTextField = "Nombre";
            ddlDepartamento.DataValueField = "IdDepartamento";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Todos", ""));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? idDepartamento = string.IsNullOrEmpty(ddlDepartamento.SelectedValue) ? (int?)null : Convert.ToInt32(ddlDepartamento.SelectedValue);
            bool? estado = string.IsNullOrEmpty(ddlEstado.SelectedValue) ? (bool?)null : Convert.ToBoolean(ddlEstado.SelectedValue);
            DateTime? fechaInicio = string.IsNullOrEmpty(txtFechaInicio.Text) ? (DateTime?)null : Convert.ToDateTime(txtFechaInicio.Text);
            DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Text) ? (DateTime?)null : Convert.ToDateTime(txtFechaFin.Text);

            List<Empleado> empleados = empleadosController.ObtenerReporteEmpleados(idDepartamento, estado, fechaInicio, fechaFin);
            gvReporteEmpleados.DataSource = empleados;
            gvReporteEmpleados.DataBind();
        }
    }
}