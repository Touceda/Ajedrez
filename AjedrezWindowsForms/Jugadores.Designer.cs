namespace AjedrezWindowsForms
{
    partial class Jugadores
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
            this.txtBlanco = new System.Windows.Forms.TextBox();
            this.txtNegro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.Se = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBlanco
            // 
            this.txtBlanco.Location = new System.Drawing.Point(252, 82);
            this.txtBlanco.Name = "txtBlanco";
            this.txtBlanco.Size = new System.Drawing.Size(270, 23);
            this.txtBlanco.TabIndex = 0;
            // 
            // txtNegro
            // 
            this.txtNegro.Location = new System.Drawing.Point(252, 145);
            this.txtNegro.Name = "txtNegro";
            this.txtNegro.Size = new System.Drawing.Size(270, 23);
            this.txtNegro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Jugador Blanco";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(584, 87);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre Jugador Negro";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(105, 243);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 5;
            // 
            // Se
            // 
            this.Se.AutoSize = true;
            this.Se.Location = new System.Drawing.Point(203, 9);
            this.Se.Name = "Se";
            this.Se.Size = new System.Drawing.Size(204, 15);
            this.Se.TabIndex = 6;
            this.Se.Text = "Seleccionar Nombre de los Jugadores";
            // 
            // Jugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 391);
            this.Controls.Add(this.Se);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNegro);
            this.Controls.Add(this.txtBlanco);
            this.Name = "Jugadores";
            this.Text = "Jugadores";
            this.Load += new System.EventHandler(this.Jugadores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBlanco;
        private TextBox txtNegro;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label lblError;
        private Label Se;
    }
}