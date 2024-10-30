<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="PERFILES_SA.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" OnClick="Nuevo_Click" CssClass="btn btn-sm btn-success" Text="Agregar" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GVDepartamento" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creacion"/>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdDepartamento")%>'
                                OnClick="Editar_Click" CssClass="btn btn-sm btn-primary">
                                Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("IdDepartamento")%>'
                                OnClick="Eliminar_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Desea Inhabilitarlo?')">
                                Inhabilitar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
