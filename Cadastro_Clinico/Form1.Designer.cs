namespace Cadastro_Clinico
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_entrar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btn_sair = new System.Windows.Forms.Button();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_senha = new System.Windows.Forms.Label();
            this.btnTeste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_entrar
            // 
            this.btn_entrar.Location = new System.Drawing.Point(283, 255);
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Size = new System.Drawing.Size(89, 23);
            this.btn_entrar.TabIndex = 0;
            this.btn_entrar.Text = "Entrar";
            this.btn_entrar.UseVisualStyleBackColor = true;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(283, 166);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(188, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(283, 218);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(188, 20);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // btn_sair
            // 
            this.btn_sair.Location = new System.Drawing.Point(382, 255);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(89, 23);
            this.btn_sair.TabIndex = 3;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = true;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(280, 150);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(43, 13);
            this.lbl_usuario.TabIndex = 4;
            this.lbl_usuario.Text = "Usuário";
            // 
            // lbl_senha
            // 
            this.lbl_senha.AutoSize = true;
            this.lbl_senha.Location = new System.Drawing.Point(280, 202);
            this.lbl_senha.Name = "lbl_senha";
            this.lbl_senha.Size = new System.Drawing.Size(38, 13);
            this.lbl_senha.TabIndex = 5;
            this.lbl_senha.Text = "Senha";
            // 
            // btnTeste
            // 
            this.btnTeste.Location = new System.Drawing.Point(562, 398);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(158, 23);
            this.btnTeste.TabIndex = 6;
            this.btnTeste.Text = "teste conexão";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.btnTeste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTeste);
            this.Controls.Add(this.lbl_senha);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btn_entrar);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_entrar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_senha;
        private System.Windows.Forms.Button btnTeste;
    }
}

