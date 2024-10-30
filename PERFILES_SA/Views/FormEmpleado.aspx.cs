using PERFILES_SA.Controllers;
using PERFILES_SA.DATA;
using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PERFILES_SA
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        private static int idEmpleado = 0;
        EmpleadoController empleadoController = new EmpleadoController();
        DepartamentoController departamentoController = new DepartamentoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idEmpleado"] != null)
                {
                    idEmpleado = Convert.ToInt32(Request.QueryString["idEmpleado"]);

                    if (idEmpleado != 0)
                    {
                        lblTitulo.Text = "Editar Empleado";
                        btnSubmit.Text = "Actualizar";

                        Empleado empleado = empleadoController.Obtener(idEmpleado);
                        txtNombre.Text = empleado.Nombres;
                        txtDPI.Text = empleado.DPI;
                        txtFechaNacimiento.Text = Convert.ToDateTime(empleado.FechaNacimiento).ToString("yyyy-MM-dd");
                        ddlGenero.SelectedValue = empleado.Genero.ToString();
                        txtFechaIngreso.Text = Convert.ToDateTime(empleado.FechaIngreso).ToString("yyyy-MM-dd");
                        txtFechaIngreso.ReadOnly = true; // Deshabilitar la edición de FechaIngreso en modo edición
                        txtDireccion.Text = empleado.Direccion;
                        txtNIT.Text = empleado.NIT;
                        CargarDepartamentos(empleado.Departamento.IdDepartamento.ToString());
                    }
                    else
                    {
                        lblTitulo.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Guardar";
                        CargarDepartamentos();
                    }
                }
                else
                    Response.Redirect("~/Views/Departamentos.aspx");
            }
        }

        private void CargarDepartamentos(string idDepartamento = "")
        {
            List<Departamento> lista = departamentoController.lista();

            ddlDepartamento.DataTextField = "Nombre";
            ddlDepartamento.DataValueField = "IdDepartamento";

            ddlDepartamento.DataSource = lista;
            ddlDepartamento.DataBind();

            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione...", ""));

            if (!string.IsNullOrEmpty(idDepartamento))
            {
                ddlDepartamento.SelectedValue = idDepartamento;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Empleado entidad = new Empleado()
            {
                IdEmpleado = idEmpleado,
                Nombres = txtNombre.Text,
                DPI = txtDPI.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Genero = Convert.ToChar(ddlGenero.SelectedValue),
                FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text), // Fecha de ingreso no cambia si está en modo edición
                Direccion = txtDireccion.Text,
                NIT = txtNIT.Text,
                Departamento = new Departamento() { IdDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue) }
            };

            bool respuesta;

            if (idEmpleado != 0)
                respuesta = empleadoController.Editar(entidad);
            else
                respuesta = empleadoController.Crear(entidad);

            if (respuesta)
                Response.Redirect("~/Views/Empleado.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operación')", true);
        }
        protected void cvFechaNacimiento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaNacimiento;
            if (DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                args.IsValid = fechaNacimiento < DateTime.Now;
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}
