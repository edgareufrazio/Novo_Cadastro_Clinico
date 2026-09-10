namespace Cadastro_Clinico
{
    partial class Pagamentos
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
            this.grid_pagamentos = new System.Windows.Forms.DataGridView();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.bt_pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_exibir = new System.Windows.Forms.Button();
            this.tb_divida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_pagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_pagamentos
            // 
            this.grid_pagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_pagamentos.Location = new System.Drawing.Point(62, 77);
            this.grid_pagamentos.Name = "grid_pagamentos";
            this.grid_pagamentos.Size = new System.Drawing.Size(363, 265);
            this.grid_pagamentos.TabIndex = 0;
            // 
            // tb_nome
            // 
            this.tb_nome.Location = new System.Drawing.Point(515, 119);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(216, 20);
            this.tb_nome.TabIndex = 1;
            // 
            // bt_pesquisar
            // 
            this.bt_pesquisar.Location = new System.Drawing.Point(656, 145);
            this.bt_pesquisar.Name = "bt_pesquisar";
            this.bt_pesquisar.Size = new System.Drawing.Size(75, 23);
            this.bt_pesquisar.TabIndex = 2;
            this.bt_pesquisar.Text = "Pesquisar";
            this.bt_pesquisar.UseVisualStyleBackColor = true;
            this.bt_pesquisar.Click += new System.EventHandler(this.bt_pesquisar_Click);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar por nome";
            // 
            // bt_exibir
            // 
            this.bt_exibir.Location = new System.Drawing.Point(62, 349);
            this.bt_exibir.Name = "bt_exibir";
            this.bt_exibir.Size = new System.Drawing.Size(75, 23);
            this.bt_exibir.TabIndex = 4;
            this.bt_exibir.Text = "Exibir Todos";
            this.bt_exibir.UseVisualStyleBackColor = true;
            this.bt_exibir.Click += new System.EventHandler(this.bt_exibir_Click);
            // 
            // tb_divida
            // 
            this.tb_divida.Location = new System.Drawing.Point(506, 260);
            this.tb_divida.Name = "tb_divida";
            this.tb_divida.Size = new System.Drawing.Size(100, 20);
            this.tb_divida.TabIndex = 5;
            this.tb_divida.TextChanged += new System.EventHandler(this.tb_divida_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "À pagar";
            // 
            // Pagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_divida);
            this.Controls.Add(this.bt_exibir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_pesquisar);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.grid_pagamentos);
            this.Name = "Pagamentos";
            this.Text = "Pagamentos";
            this.Load += new System.EventHandler(this.Pagamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_pagamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_pagamentos;
        private System.Windows.Forms.TextBox tb_nome;
        private System.Windows.Forms.Button bt_pesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_exibir;
        private System.Windows.Forms.TextBox tb_divida;
        private System.Windows.Forms.Label label2;
    }
}