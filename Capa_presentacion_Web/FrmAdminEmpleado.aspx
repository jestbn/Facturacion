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
                    <asp:textbox runat="server" text="" id="txtNombre" cssclass="form-control" width="100%"></asp:textbox>
                </div>
                <div class="form-group">
                    <label>Documento</label>
                </div>
                <div class="form-group">
                    <asp:textbox runat="server" text="" id="TxtDocumento" cssclass="form-control"></asp:textbox>
                </div>
                <div class="form-group">
                    <label>Dirección</label>
                </div>
            </div>

            <div class="col-md-6">

                <div class="form-group">
                    <label>Teléfono</label>
                </div>
                <div class="form-group">
                    <asp:textbox runat="server" text="" id="txtTelefono" cssclass="form-control"></asp:textbox>
                </div>
                <div class="form-group">Email </div>
                <div class="form-group">
                    <asp:textbox runat="server" text="" id="txtEmail" cssclass="form-control"></asp:textbox>
                </div>
                <div class="form-group">
                    <asp:textbox runat="server" text="" id="txtRol" cssclass="form-control"></asp:textbox>
                </div>
                <div class="form-group">
                    <asp:textbox runat="server" text="" id="txtDatosAdicionales" cssclass="form-control"></asp:textbox>
                </div>

                <div class="form-group"></div>
                <div class="form-group"></div>
            </div>

        </div>

    </section>

    <section class="conten">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group" style="text-align: center">
                    <asp:button id="idActualizar" runat="server" text="Guardar" cssclass="btn btn-primary" width="100px" onclick="idActualizar_Click" />
                    <asp:button id="IdCancelar" runat="server" text="Retornar" cssclass="btn btn-danger" width="100px" onclick="IdCancelar_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
