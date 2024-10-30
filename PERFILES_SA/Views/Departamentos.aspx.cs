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
    public partial class About : Page
    {
        DepartamentoController departamentoController = new DepartamentoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDepartamentos();
        }

        private void MostrarDepartamentos()
        {
            List<Departamento> lista = departamentoController.lista();

            GVDepartamento.DataSource = lista;
            GVDepartamento.DataBind();
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/FormDepartamentos.aspx?idDepartamento=0");
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idDepartamento = btn.CommandArgument;
            Response.Redirect($"~/Views/FormDepartamentos.aspx?idDepartamento={idDepartamento}");
        }
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idDepartamento = btn.CommandArgument;

            bool respuesta = departamentoController.Eliminar(Convert.ToInt32(idDepartamento));

            if (respuesta)
                MostrarDepartamentos();
        }

    }
}