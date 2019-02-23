namespace Facturacion
{
    partial class FRM_MDI_PRINCIPAL
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MDI_PRINCIPAL));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.adminTablasToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Archivo";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // adminTablasToolStripMenuItem
            // 
            this.adminTablasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminClientesToolStripMenuItem,
            this.adminProductosToolStripMenuItem,
            this.adminEmpleadosToolStripMenuItem});
            this.adminTablasToolStripMenuItem.Name = "adminTablasToolStripMenuItem";
            this.adminTablasToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.adminTablasToolStripMenuItem.Text = "A&dmin Tablas";
            // 
            // adminClientesToolStripMenuItem
            // 
            this.adminClientesToolStripMenuItem.Name = "adminClientesToolStripMenuItem";
            this.adminClientesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.adminClientesToolStripMenuItem.Text = "Admin Clientes";
            this.adminClientesToolStripMenuItem.Click += new System.EventHandler(this.AdminClientesToolStripMenuItem_Click);
            // 
            // adminProductosToolStripMenuItem
            // 
            this.adminProductosToolStripMenuItem.Name = "adminProductosToolStripMenuItem";
            this.adminProductosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.adminProductosToolStripMenuItem.Text = "Admin Productos";
            this.adminProductosToolStripMenuItem.Click += new System.EventHandler(this.AdminProductosToolStripMenuItem_Click);
            // 
            // adminEmpleadosToolStripMenuItem
            // 
            this.adminEmpleadosToolStripMenuItem.Name = "adminEmpleadosToolStripMenuItem";
            this.adminEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.adminEmpleadosToolStripMenuItem.Text = "Admin Empleados";
            this.adminEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.adminEmpleadosToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            this.seguridadToolStripMenuItem.Click += new System.EventHandler(this.SeguridadToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // FRM_MDI_PRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FRM_MDI_PRINCIPAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminTablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}



