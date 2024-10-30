using PERFILES_SA.Controllers;
using PERFILES_SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PERFILES_SA
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        EmpleadoController empleadoController = new EmpleadoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }

        private void MostrarEmpleados()
        {
            List<Empleado> lista = empleadoController.Lista();

            GVEmpleado.DataSource = lista;
            GVEmpleado.DataBind();
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/FormEmpleado.aspx?idEmpleado=0");
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument;
            Response.Redirect($"~/Views/FormEmpleado.aspx?idEmpleado={idEmpleado}");
        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument;

            bool respuesta = empleadoController.Eliminar(Convert.ToInt32(idEmpleado));

            if (respuesta)
                MostrarEmpleados();
        }
    }
}