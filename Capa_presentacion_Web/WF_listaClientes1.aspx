<%@ Page Title="" Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="WF_listaClientes1.aspx.cs" Inherits="Capa_presentacion_Web.WF_listaClientes1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- AQUÍ COLOCAREMOS LOS ELEMENTOS PARA FITRAR Y MOSTRAR LOS CLIENTES -->
<h2>ADMINISTRACIÓN DE CLIENTES</h2>
<asp:Label ID="MessageLabel" runat="server" Text="Mensaje: "></asp:Label>
<BR/>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="collapse navbar-collapse" id="navbarColor03">
        <asp:TextBox ID="txtbuscar" runat="server" class="form-control mr-sm-2" Width="300px"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" class="btn btnsecondary my-2 my-sm-0" OnClick="btnbuscar_Click" />
        <asp:Button ID="btnNueva" runat="server" Text="NUEVO" class="btn btnsecondary my-2 my-sm-0" OnClick="btnNueva_Click" />
    </div>
</nav>
    <asp:GridView ID="dgClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="dgClientes_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="IdCliente" HeaderText="ID" />
            <asp:BoundField DataField="StrNombre" HeaderText="Nombre" />
            <asp:BoundField DataField="NumDocumento" HeaderText="Documento" />
            <asp:BoundField DataField="StrTelefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="StrEmail" HeaderText="Email" />
            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>