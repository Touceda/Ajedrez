namespace AjedrezWindowsForms
{
    partial class Menu
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
            this.btbNewGame = new System.Windows.Forms.Button();
            this.btbContinuarPartida = new System.Windows.Forms.Button();
            this.btbVerPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(282, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Juego del Ajedrez";
            // 
            // btbNewGame
            // 
            this.btbNewGame.Location = new System.Drawing.Point(154, 106);
            this.btbNewGame.Name = "btbNewGame";
            this.btbNewGame.Size = new System.Drawing.Size(466, 78);
            this.btbNewGame.TabIndex = 1;
            this.btbNewGame.Text = "Nueva Partida";
            this.btbNewGame.UseVisualStyleBackColor = true;
            this.btbNewGame.Click += new System.EventHandler(this.btbNewGame_Click);
            // 
            // btbContinuarPartida
            // 
            this.btbContinuarPartida.Location = new System.Drawing.Point(154, 214);
            this.btbContinuarPartida.Name = "btbContinuarPartida";
            this.btbContinuarPartida.Size = new System.Drawing.Size(466, 78);
            this.btbContinuarPartida.TabIndex = 2;
            this.btbContinuarPartida.Text = "Continuar Partida";
            this.btbContinuarPartida.UseVisualStyleBackColor = true;
            this.btbContinuarPartida.Click += new System.EventHandler(this.btbContinuarPartida_Click);
            // 
            // btbVerPartida
            // 
            this.btbVerPartida.Location = new System.Drawing.Point(154, 324);
            this.btbVerPartida.Name = "btbVerPartida";
            this.btbVerPartida.Size = new System.Drawing.Size(466, 78);
            this.btbVerPartida.TabIndex = 3;
            this.btbVerPartida.Text = "Revisar Partida";
            this.btbVerPartida.UseVisualStyleBackColor = true;
            this.btbVerPartida.Click += new System.EventHandler(this.btbVerPartida_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btbVerPartida);
            this.Controls.Add(this.btbContinuarPartida);
            this.Controls.Add(this.btbNewGame);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btbNewGame;
        private Button btbContinuarPartida;
        private Button btbVerPartida;
    }
}