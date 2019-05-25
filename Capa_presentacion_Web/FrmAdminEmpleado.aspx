<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="FrmAdminEmpleado.aspx.cs" Inherits="Capa_presentacion_Web.FrmAdminEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h2>DATOS BÁSICOS</h2>
        <hr />
    </section>
    <section class="conten">
        <div class="row">
            <div class="col-md-6">

                <div class="form-group">
                    <label>Nombre</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtNombre" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Documento</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="TxtDocumento" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Dirección</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6">

                <div class="form-group">
                    <label>Teléfono</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">Email </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Rol</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtRol" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Datos Adicionales</label>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" Text="" ID="txtDatosAdicionales" CssClass="form-control"></asp:TextBox>
                </div>

            </div>

        </div>

    </section>

    <section class="conten">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group" style="text-align: center">
                    <asp:Button ID="idActualizar" runat="server" Text="Guardar" CssClass="btn btn-primary" Width="100px" OnClick="idActualizar_Click" />
                    <asp:Button ID="IdCancelar" runat="server" Text="Retornar" CssClass="btn btn-danger" Width="100px" OnClick="IdCancelar_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
