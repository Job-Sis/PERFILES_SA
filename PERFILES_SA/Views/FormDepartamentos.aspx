<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDepartamentos.aspx.cs" Inherits="PERFILES_SA.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
            ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic" />
    </div>
    <div class="mb-3">
        <label class="form-label">Estado</label>
        <div>
            <asp:RadioButton ID="rbtnEstadoTrue" runat="server" GroupName="Estado" Text="Habilitado" />
            <asp:RadioButton ID="rbtnEstadoFalse" runat="server" GroupName="Estado" Text="Deshabilitado" />
        </div>
    </div>
    <div id="divFechaCreacion" runat="server" class="mb-3">
        <label class="form-label">Fecha de Creación</label>
        <asp:Label ID="lblFechaCreacion" runat="server" CssClass="form-control" />
    </div>

    
    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
    <asp:LinkButton runat="server" PostBackUrl="~/Views/Departamentos.aspx" CssClass="btn btn-sm btn-warning">Volver</asp:LinkButton>

</asp:Content>
