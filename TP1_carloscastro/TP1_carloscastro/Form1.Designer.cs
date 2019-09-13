namespace TP1_carloscastro
{
    partial class Form1
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
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.btnOperar_Click = new System.Windows.Forms.Button();
            this.btnLimpiar_Click = new System.Windows.Forms.Button();
            this.btnCerrar_Click = new System.Windows.Forms.Button();
            this.btnConvertirADecimal_Click = new System.Windows.Forms.Button();
            this.btnConvertirABinario_Click = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero2
            // 
            this.txtNumero2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero2.Location = new System.Drawing.Point(256, 43);
            this.txtNumero2.Multiline = true;
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(116, 38);
            this.txtNumero2.TabIndex = 2;
            // 
            // txtNumero1
            // 
            this.txtNumero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero1.Location = new System.Drawing.Point(12, 43);
            this.txtNumero1.Multiline = true;
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(115, 38);
            this.txtNumero1.TabIndex = 0;
            // 
            // cmbOperador
            // 
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(149, 43);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbOperador.Size = new System.Drawing.Size(82, 21);
            this.cmbOperador.TabIndex = 1;
            // 
            // btnOperar_Click
            // 
            this.btnOperar_Click.Location = new System.Drawing.Point(12, 98);
            this.btnOperar_Click.Name = "btnOperar_Click";
            this.btnOperar_Click.Size = new System.Drawing.Size(116, 30);
            this.btnOperar_Click.TabIndex = 3;
            this.btnOperar_Click.Text = "Operar";
            this.btnOperar_Click.UseVisualStyleBackColor = true;
            this.btnOperar_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLimpiar_Click
            // 
            this.btnLimpiar_Click.Location = new System.Drawing.Point(134, 98);
            this.btnLimpiar_Click.Name = "btnLimpiar_Click";
            this.btnLimpiar_Click.Size = new System.Drawing.Size(116, 30);
            this.btnLimpiar_Click.TabIndex = 4;
            this.btnLimpiar_Click.Text = "Limpiar";
            this.btnLimpiar_Click.UseVisualStyleBackColor = true;
            this.btnLimpiar_Click.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCerrar_Click
            // 
            this.btnCerrar_Click.Location = new System.Drawing.Point(256, 98);
            this.btnCerrar_Click.Name = "btnCerrar_Click";
            this.btnCerrar_Click.Size = new System.Drawing.Size(116, 30);
            this.btnCerrar_Click.TabIndex = 5;
            this.btnCerrar_Click.Text = "Cerrar";
            this.btnCerrar_Click.UseVisualStyleBackColor = true;
            this.btnCerrar_Click.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnConvertirADecimal_Click
            // 
            this.btnConvertirADecimal_Click.Location = new System.Drawing.Point(202, 144);
            this.btnConvertirADecimal_Click.Name = "btnConvertirADecimal_Click";
            this.btnConvertirADecimal_Click.Size = new System.Drawing.Size(170, 41);
            this.btnConvertirADecimal_Click.TabIndex = 0;
            this.btnConvertirADecimal_Click.Text = "Convertir a Decimal";
            this.btnConvertirADecimal_Click.UseVisualStyleBackColor = true;
            this.btnConvertirADecimal_Click.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnConvertirABinario_Click
            // 
            this.btnConvertirABinario_Click.Location = new System.Drawing.Point(12, 144);
            this.btnConvertirABinario_Click.Name = "btnConvertirABinario_Click";
            this.btnConvertirABinario_Click.Size = new System.Drawing.Size(170, 41);
            this.btnConvertirABinario_Click.TabIndex = 7;
            this.btnConvertirABinario_Click.Text = "Convertir a Binario";
            this.btnConvertirABinario_Click.UseVisualStyleBackColor = true;
            this.btnConvertirABinario_Click.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(365, 9);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 24);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 206);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnConvertirABinario_Click);
            this.Controls.Add(this.btnConvertirADecimal_Click);
            this.Controls.Add(this.btnCerrar_Click);
            this.Controls.Add(this.btnLimpiar_Click);
            this.Controls.Add(this.btnOperar_Click);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.txtNumero2);
            this.Name = "Form1";
            this.Text = "Calculadora de Carlos Castro Del curso 2°A";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.Button btnOperar_Click;
        private System.Windows.Forms.Button btnLimpiar_Click;
        private System.Windows.Forms.Button btnCerrar_Click;
        private System.Windows.Forms.Button btnConvertirADecimal_Click;
        private System.Windows.Forms.Button btnConvertirABinario_Click;
        private System.Windows.Forms.Label lblResultado;
        public System.Windows.Forms.ComboBox cmbOperador;
    }
}

