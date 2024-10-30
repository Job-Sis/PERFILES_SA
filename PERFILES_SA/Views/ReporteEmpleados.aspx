<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteEmpleados.aspx.cs" Inherits="PERFILES_SA.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="lblTitulo" runat="server" Text="Reporte de Empleados" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Departamento</label>
        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select" />
    </div>

    <div class="mb-3">
        <label class="form-label">Estado</label>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
            <asp:ListItem Text="Todos" Value="" />
            <asp:ListItem Text="Habilitado" Value="true" />
            <asp:ListItem Text="Deshabilitado" Value="false" />
        </asp:DropDownList>
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha de Ingreso (Desde)</label>
        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha de Ingreso (Hasta)</label>
        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />

    <asp:GridView ID="gvReporteEmpleados" runat="server" AutoGenerateColumns="False" CssClass="table mt-3">
        <Columns>
            <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
            <asp:BoundField DataField="DPI" HeaderText="DPI" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" />
            <asp:BoundField DataField="Genero" HeaderText="Género" />
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="NIT" HeaderText="NIT" />
            <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento" />
            <asp:BoundField DataField="Departamento.Estado" HeaderText="Estado" DataFormatString="{0:Estado}" />
        </Columns>
    </asp:GridView>
</asp:Content>
