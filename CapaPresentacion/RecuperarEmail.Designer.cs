namespace CapaPresentacion
{
    partial class RecuperarEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.contraseñalabel = new System.Windows.Forms.Label();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.confirmacionlabel = new System.Windows.Forms.Label();
            this.txt_confirmacion = new System.Windows.Forms.TextBox();
            this.btn_cambiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correo Electronico:";
            // 
            // contraseñalabel
            // 
            this.contraseñalabel.AutoSize = true;
            this.contraseñalabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.contraseñalabel.Location = new System.Drawing.Point(31, 93);
            this.contraseñalabel.Name = "contraseñalabel";
            this.contraseñalabel.Size = new System.Drawing.Size(102, 19);
            this.contraseñalabel.TabIndex = 1;
            this.contraseñalabel.Text = "Contraseña:";
            this.contraseñalabel.Visible = false;
            // 
            // btn_enviar
            // 
            this.btn_enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(163)))), ((int)(((byte)(7)))));
            this.btn_enviar.ForeColor = System.Drawing.Color.White;
            this.btn_enviar.Location = new System.Drawing.Point(305, 49);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(107, 35);
            this.btn_enviar.TabIndex = 2;
            this.btn_enviar.Text = "ENVIAR";
            this.btn_enviar.UseVisualStyleBackColor = false;
            this.btn_enviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_usuario
            // 
            this.txt_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_usuario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usuario.ForeColor = System.Drawing.Color.Silver;
            this.txt_usuario.Location = new System.Drawing.Point(34, 58);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(204, 26);
            this.txt_usuario.TabIndex = 3;
            this.txt_usuario.Text = "Ingrese su correo";
            this.txt_usuario.Enter += new System.EventHandler(this.txt_usuario_Enter);
            this.txt_usuario.Leave += new System.EventHandler(this.txt_usuario_Leave);
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.txt_contraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contraseña.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt_contraseña.ForeColor = System.Drawing.Color.Silver;
            this.txt_contraseña.Location = new System.Drawing.Point(34, 118);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.Size = new System.Drawing.Size(204, 26);
            this.txt_contraseña.TabIndex = 4;
            this.txt_contraseña.Text = "Contraseña";
            this.txt_contraseña.Visible = false;
            this.txt_contraseña.Enter += new System.EventHandler(this.txt_contraseña_Enter);
            this.txt_contraseña.Leave += new System.EventHandler(this.txt_contraseña_Leave);
            // 
            // confirmacionlabel
            // 
            this.confirmacionlabel.AutoSize = true;
            this.confirmacionlabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.confirmacionlabel.Location = new System.Drawing.Point(31, 149);
            this.confirmacionlabel.Name = "confirmacionlabel";
            this.confirmacionlabel.Size = new System.Drawing.Size(237, 19);
            this.confirmacionlabel.TabIndex = 5;
            this.confirmacionlabel.Text = "Confirmación de Contraseña:";
            this.confirmacionlabel.Visible = false;
            // 
            // txt_confirmacion
            // 
            this.txt_confirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.txt_confirmacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_confirmacion.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt_confirmacion.ForeColor = System.Drawing.Color.Silver;
            this.txt_confirmacion.Location = new System.Drawing.Point(34, 175);
            this.txt_confirmacion.Name = "txt_confirmacion";
            this.txt_confirmacion.Size = new System.Drawing.Size(204, 26);
            this.txt_confirmacion.TabIndex = 6;
            this.txt_confirmacion.Text = "Confirmación Contraseña";
            this.txt_confirmacion.Visible = false;
            this.txt_confirmacion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_confirmacion.Enter += new System.EventHandler(this.txt_confirmacion_Enter);
            this.txt_confirmacion.Leave += new System.EventHandler(this.txt_confirmacion_Leave);
            // 
            // btn_cambiar
            // 
            this.btn_cambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(163)))), ((int)(((byte)(7)))));
            this.btn_cambiar.ForeColor = System.Drawing.Color.White;
            this.btn_cambiar.Location = new System.Drawing.Point(305, 109);
            this.btn_cambiar.Name = "btn_cambiar";
            this.btn_cambiar.Size = new System.Drawing.Size(107, 35);
            this.btn_cambiar.TabIndex = 7;
            this.btn_cambiar.Text = "CAMBIAR";
            this.btn_cambiar.UseVisualStyleBackColor = false;
            this.btn_cambiar.Visible = false;
            this.btn_cambiar.Click += new System.EventHandler(this.btn_cambiar_Click);
            // 
            // RecuperarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(440, 226);
            this.Controls.Add(this.btn_cambiar);
            this.Controls.Add(this.txt_confirmacion);
            this.Controls.Add(this.confirmacionlabel);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.contraseñalabel);
            this.Controls.Add(this.label1);
            this.Name = "RecuperarEmail";
            this.Text = "RecuperarEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label contraseñalabel;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.Label confirmacionlabel;
        private System.Windows.Forms.TextBox txt_confirmacion;
        private System.Windows.Forms.Button btn_cambiar;
    }
}