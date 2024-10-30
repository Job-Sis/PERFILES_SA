using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using PERFILES_SA.Controllers;
using PERFILES_SA.Models;

namespace PERFILES_SA
{
    public partial class Contact : Page
    {
        private static int idDepartamento = 0;
        DepartamentoController departamentoController = new DepartamentoController();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["idDepartamento"] != null)
                {
                    idDepartamento = Convert.ToInt32(Request.QueryString["idDepartamento"].ToString());

                    if (idDepartamento != 0)
                    {
                        lblTitulo.Text = "Editar Departamento";
                        btnSubmit.Text = "Actualizar";

                        // Mostrar el div de Fecha de Creación en modo edición
                        divFechaCreacion.Visible = true;

                        Departamento departamento = departamentoController.Obtener(idDepartamento);
                        txtNombre.Text = departamento.Nombre;
                        // Seleccionar el RadioButton de acuerdo al valor de Estado
                        if (departamento.Estado)
                            rbtnEstadoTrue.Checked = true;
                        else
                            rbtnEstadoFalse.Checked = true;
                        lblFechaCreacion.Text = Convert.ToDateTime(departamento.FechaCreacion, new CultureInfo("es-PE")).ToString("yyyy-MM-dd");
                    } 
                    else
                    {
                        lblTitulo.Text = "Nuevo Empleado";
                        btnSubmit.Text = "Guardar";

                        // Ocultar el div de Fecha de Creación en modo creación
                        divFechaCreacion.Visible = false;

                        rbtnEstadoTrue.Checked = true;
                        lblFechaCreacion.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }
                else
                    Response.Redirect("~/Views/Departamentos.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validación de que el campo Nombre no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El nombre es obligatorio')", true);
                return;
            }

            bool estadoSeleccionado = rbtnEstadoTrue.Checked;

            Departamento entidad = new Departamento()

            {
                IdDepartamento = idDepartamento,
                Nombre = txtNombre.Text,
                Estado = estadoSeleccionado,
                FechaCreacion = DateTime.Parse(lblFechaCreacion.Text)
            };

            bool respuesta;

            if (idDepartamento != 0)
                respuesta = departamentoController.Editar(entidad);
            else
                respuesta = departamentoController.Crear(entidad);

            if (respuesta)
                Response.Redirect("~/Views/Departamentos.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);
        }
    }
}