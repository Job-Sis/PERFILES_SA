<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="PERFILES_SA.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="Agregar" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVEmpleado" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"/>
                    <asp:BoundField DataField="DPI" HeaderText="DPI"/>
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento"/>
                    <asp:BoundField DataField="Genero" HeaderText="Genero"/>
                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso"/>
                    <asp:BoundField DataField="Edad" HeaderText="Edad"/>
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion"/>
                    <asp:BoundField DataField="NIT" HeaderText="NIT"/>
                    <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento"/>


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado")%>'
                                OnClick="Editar_Click" CssClass="btn btn-sm btn-primary">
                                Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdEmpleado")%>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea eliminar?')">
                                Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
