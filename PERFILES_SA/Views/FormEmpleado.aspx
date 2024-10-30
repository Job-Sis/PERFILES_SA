<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormEmpleado.aspx.cs" Inherits="PERFILES_SA.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Nombres</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
            ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic" />
    </div>

    <div class="mb-3">
        <label class="form-label">DPI</label>
        <asp:TextBox ID="txtDPI" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDPI" runat="server" ControlToValidate="txtDPI"
            ErrorMessage="El DPI es obligatorio" CssClass="text-danger" Display="Dynamic" />
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha Nacimiento</label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
            ErrorMessage="La fecha de nacimiento es obligatoria" CssClass="text-danger" Display="Dynamic" />
        <asp:CustomValidator ID="cvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
            ErrorMessage="La fecha de nacimiento debe ser anterior a la fecha actual"
            CssClass="text-danger" Display="Dynamic" OnServerValidate="cvFechaNacimiento_ServerValidate" />

    </div>

    <div class="mb-3">
        <label class="form-label">Genero</label>
        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione..." Value="" />
            <asp:ListItem Text="Masculino" Value="M" />
            <asp:ListItem Text="Femenino" Value="F" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="ddlGenero"
            InitialValue="" ErrorMessage="El género es obligatorio" CssClass="text-danger" Display="Dynamic" />
    </div>

    <div class="mb-3">
        <label class="form-label">Fecha Ingreso</label>
        <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFechaIngreso" runat="server" ControlToValidate="txtFechaIngreso"
            ErrorMessage="La fecha de ingreso es obligatoria" CssClass="text-danger" Display="Dynamic" />
    </div>


    <div class="mb-3">
        <label class="form-label">Direccion</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">NIT</label>
        <asp:TextBox ID="txtNIT" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Departamento</label>
        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvDepartamento" runat="server" ControlToValidate="ddlDepartamento"
            InitialValue="" ErrorMessage="Debe seleccionar un departamento" CssClass="text-danger" Display="Dynamic" />
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
    <asp:LinkButton runat="server" PostBackUrl="~/Views/Empleado.aspx" CssClass="btn btn-sm btn-warning">Volver</asp:LinkButton>

</asp:Content>
