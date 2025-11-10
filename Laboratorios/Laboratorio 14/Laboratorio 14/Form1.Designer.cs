namespace Laboratorio_14
{
    partial class frmProductos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            tsbNuevo = new Button();
            tsbEliminar = new Button();
            tsbCancelar = new Button();
            tsbGuardar = new Button();
            label1 = new Label();
            tstId = new TextBox();
            tsbBuscar = new Button();
            imageList1 = new ImageList(components);
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSalir = new Button();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            SuspendLayout();
            // 
            // tsbNuevo
            // 
            tsbNuevo.BackColor = SystemColors.ButtonHighlight;
            tsbNuevo.BackgroundImage = Properties.Resources.nuevo;
            tsbNuevo.BackgroundImageLayout = ImageLayout.Stretch;
            tsbNuevo.FlatStyle = FlatStyle.Flat;
            tsbNuevo.ForeColor = SystemColors.ButtonHighlight;
            tsbNuevo.Location = new Point(12, 1);
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(35, 33);
            tsbNuevo.TabIndex = 1;
            tsbNuevo.UseVisualStyleBackColor = false;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbEliminar
            // 
            tsbEliminar.BackColor = SystemColors.ButtonHighlight;
            tsbEliminar.BackgroundImage = (Image)resources.GetObject("tsbEliminar.BackgroundImage");
            tsbEliminar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbEliminar.FlatStyle = FlatStyle.Flat;
            tsbEliminar.ForeColor = SystemColors.ButtonHighlight;
            tsbEliminar.Location = new Point(120, 1);
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(35, 33);
            tsbEliminar.TabIndex = 2;
            tsbEliminar.UseVisualStyleBackColor = false;
            tsbEliminar.Click += tsbEliminar_Click;
            // 
            // tsbCancelar
            // 
            tsbCancelar.BackColor = SystemColors.ButtonHighlight;
            tsbCancelar.BackgroundImage = (Image)resources.GetObject("tsbCancelar.BackgroundImage");
            tsbCancelar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbCancelar.FlatStyle = FlatStyle.Flat;
            tsbCancelar.ForeColor = SystemColors.ButtonHighlight;
            tsbCancelar.Location = new Point(84, 1);
            tsbCancelar.Name = "tsbCancelar";
            tsbCancelar.Size = new Size(35, 33);
            tsbCancelar.TabIndex = 3;
            tsbCancelar.UseVisualStyleBackColor = false;
            tsbCancelar.Click += tsbCancelar_Click;
            // 
            // tsbGuardar
            // 
            tsbGuardar.BackColor = SystemColors.ButtonHighlight;
            tsbGuardar.BackgroundImage = (Image)resources.GetObject("tsbGuardar.BackgroundImage");
            tsbGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbGuardar.FlatStyle = FlatStyle.Flat;
            tsbGuardar.ForeColor = SystemColors.ButtonHighlight;
            tsbGuardar.Location = new Point(48, 1);
            tsbGuardar.Name = "tsbGuardar";
            tsbGuardar.Size = new Size(35, 33);
            tsbGuardar.TabIndex = 4;
            tsbGuardar.UseVisualStyleBackColor = false;
            tsbGuardar.Click += tsbGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 10);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 5;
            label1.Text = "Buscar por id:";
            // 
            // tstId
            // 
            tstId.BackColor = SystemColors.Window;
            tstId.BorderStyle = BorderStyle.None;
            tstId.ForeColor = SystemColors.MenuText;
            tstId.Location = new Point(243, 11);
            tstId.Name = "tstId";
            tstId.Size = new Size(100, 16);
            tstId.TabIndex = 6;
            // 
            // tsbBuscar
            // 
            tsbBuscar.BackColor = SystemColors.Control;
            tsbBuscar.BackgroundImage = (Image)resources.GetObject("tsbBuscar.BackgroundImage");
            tsbBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbBuscar.FlatStyle = FlatStyle.Flat;
            tsbBuscar.ForeColor = SystemColors.ButtonHighlight;
            tsbBuscar.Location = new Point(344, 7);
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(25, 23);
            tsbBuscar.TabIndex = 7;
            tsbBuscar.UseVisualStyleBackColor = false;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 89);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 8;
            label2.Text = "Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 149);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 10;
            label3.Text = "Precio: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 89);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "Nombre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(181, 149);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 14;
            label5.Text = "Stock: ";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(48, 238);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(48, 107);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 16;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(181, 107);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(283, 23);
            txtNombre.TabIndex = 17;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(48, 167);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 18;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(181, 167);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 19;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 315);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(btnSalir);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tsbBuscar);
            Controls.Add(tstId);
            Controls.Add(label1);
            Controls.Add(tsbGuardar);
            Controls.Add(tsbCancelar);
            Controls.Add(tsbEliminar);
            Controls.Add(tsbNuevo);
            Name = "frmProductos";
            Text = "Formulario de Productos";
            Load += frmProductos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected Button tsbNuevo;
        protected Button tsbEliminar;
        protected Button tsbCancelar;
        protected Button tsbGuardar;
        private Label label1;
        private TextBox tstId;
        protected Button tsbBuscar;
        private ImageList imageList1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox A;
        private Button btnSalir;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtStock;
    }
}
