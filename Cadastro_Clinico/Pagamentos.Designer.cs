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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagamentos));
            this.grid_pagamentos = new System.Windows.Forms.DataGridView();
            this.tb_nome = new System.Windows.Forms.TextBox();
            this.bt_pesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_exibir = new System.Windows.Forms.Button();
            this.tb_divida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_deposito = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_pagar = new System.Windows.Forms.Button();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_pagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_pagamentos
            // 
            this.grid_pagamentos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_pagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_pagamentos.Location = new System.Drawing.Point(101, 121);
            this.grid_pagamentos.Margin = new System.Windows.Forms.Padding(4);
            this.grid_pagamentos.Name = "grid_pagamentos";
            this.grid_pagamentos.RowHeadersWidth = 51;
            this.grid_pagamentos.Size = new System.Drawing.Size(623, 326);
            this.grid_pagamentos.TabIndex = 0;
            // 
            // tb_nome
            // 
            this.tb_nome.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nome.Location = new System.Drawing.Point(790, 78);
            this.tb_nome.Margin = new System.Windows.Forms.Padding(4);
            this.tb_nome.Name = "tb_nome";
            this.tb_nome.Size = new System.Drawing.Size(287, 25);
            this.tb_nome.TabIndex = 1;
            // 
            // bt_pesquisar
            // 
            this.bt_pesquisar.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.8F, System.Drawing.FontStyle.Bold);
            this.bt_pesquisar.Location = new System.Drawing.Point(968, 110);
            this.bt_pesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_pesquisar.Name = "bt_pesquisar";
            this.bt_pesquisar.Size = new System.Drawing.Size(110, 30);
            this.bt_pesquisar.TabIndex = 2;
            this.bt_pesquisar.Text = "Pesquisar";
            this.bt_pesquisar.UseVisualStyleBackColor = true;
            this.bt_pesquisar.Click += new System.EventHandler(this.bt_pesquisar_Click);
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(785, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquisar por nome";
            // 
            // bt_exibir
            // 
            this.bt_exibir.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.8F, System.Drawing.FontStyle.Bold);
            this.bt_exibir.Location = new System.Drawing.Point(101, 456);
            this.bt_exibir.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exibir.Name = "bt_exibir";
            this.bt_exibir.Size = new System.Drawing.Size(151, 28);
            this.bt_exibir.TabIndex = 4;
            this.bt_exibir.Text = "Exibir Todos";
            this.bt_exibir.UseVisualStyleBackColor = true;
            this.bt_exibir.Click += new System.EventHandler(this.bt_exibir_Click);
            // 
            // tb_divida
            // 
            this.tb_divida.Location = new System.Drawing.Point(815, 279);
            this.tb_divida.Margin = new System.Windows.Forms.Padding(4);
            this.tb_divida.Name = "tb_divida";
            this.tb_divida.ReadOnly = true;
            this.tb_divida.Size = new System.Drawing.Size(132, 22);
            this.tb_divida.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(811, 259);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "À pagar";
            // 
            // tb_deposito
            // 
            this.tb_deposito.Location = new System.Drawing.Point(815, 355);
            this.tb_deposito.Margin = new System.Windows.Forms.Padding(4);
            this.tb_deposito.Name = "tb_deposito";
            this.tb_deposito.Size = new System.Drawing.Size(132, 22);
            this.tb_deposito.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(811, 336);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor pago";
            // 
            // bt_pagar
            // 
            this.bt_pagar.Font = new System.Drawing.Font("Segoe UI Variable Text", 9.8F, System.Drawing.FontStyle.Bold);
            this.bt_pagar.Location = new System.Drawing.Point(892, 385);
            this.bt_pagar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_pagar.Name = "bt_pagar";
            this.bt_pagar.Size = new System.Drawing.Size(127, 35);
            this.bt_pagar.TabIndex = 9;
            this.bt_pagar.Text = "Registrar pagamento";
            this.bt_pagar.UseVisualStyleBackColor = true;
            this.bt_pagar.Click += new System.EventHandler(this.bt_pagar_Click);
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(1001, 206);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(77, 22);
            this.tb_id.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(995, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "ID do Cliente";
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(109, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 50);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pagamentos";
            // 
            // Pagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1132, 529);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.bt_pagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_deposito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_divida);
            this.Controls.Add(this.bt_exibir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_pesquisar);
            this.Controls.Add(this.tb_nome);
            this.Controls.Add(this.grid_pagamentos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pagamentos";
            this.Text = "Pagamentos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pagamentos_FormClosed);
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
        private System.Windows.Forms.TextBox tb_deposito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_pagar;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}