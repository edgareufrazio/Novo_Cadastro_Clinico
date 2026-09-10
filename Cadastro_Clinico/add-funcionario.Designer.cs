using System;

namespace Cadastro_Clinico
{
    partial class add_funcionario
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
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.txb_cpf = new System.Windows.Forms.TextBox();
            this.lbl_departamento = new System.Windows.Forms.Label();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btn_confirmar.Location = new System.Drawing.Point(12, 353);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(190, 85);
            this.btn_confirmar.TabIndex = 11;
            this.btn_confirmar.Text = "✅ Confirmar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btn_atualizar.Location = new System.Drawing.Point(410, 353);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(190, 85);
            this.btn_atualizar.TabIndex = 12;
            this.btn_atualizar.Text = "🔄 Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btn_cancelar.Location = new System.Drawing.Point(606, 353);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(190, 85);
            this.btn_cancelar.TabIndex = 13;
            this.btn_cancelar.Text = "❌ Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "Terapeuta",
            "Psicólogo"});
            this.cmbDepartamento.Location = new System.Drawing.Point(146, 156);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(130, 21);
            this.cmbDepartamento.TabIndex = 23;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(83, 104);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(172, 20);
            this.txb_email.TabIndex = 22;
            // 
            // txb_nome
            // 
            this.txb_nome.Location = new System.Drawing.Point(146, 78);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(172, 20);
            this.txb_nome.TabIndex = 20;
            // 
            // txb_cpf
            // 
            this.txb_cpf.Location = new System.Drawing.Point(64, 130);
            this.txb_cpf.Name = "txb_cpf";
            this.txb_cpf.Size = new System.Drawing.Size(172, 20);
            this.txb_cpf.TabIndex = 19;
            // 
            // lbl_departamento
            // 
            this.lbl_departamento.AutoSize = true;
            this.lbl_departamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbl_departamento.Location = new System.Drawing.Point(14, 155);
            this.lbl_departamento.Name = "lbl_departamento";
            this.lbl_departamento.Size = new System.Drawing.Size(128, 22);
            this.lbl_departamento.TabIndex = 18;
            this.lbl_departamento.Text = "Departamento:";
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbl_cpf.Location = new System.Drawing.Point(14, 128);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(51, 22);
            this.lbl_cpf.TabIndex = 17;
            this.lbl_cpf.Text = "CPF:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbl_email.Location = new System.Drawing.Point(14, 102);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(65, 22);
            this.lbl_email.TabIndex = 16;
            this.lbl_email.Text = "E-mail:";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbl_nome.Location = new System.Drawing.Point(12, 74);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(139, 22);
            this.lbl_nome.TabIndex = 15;
            this.lbl_nome.Text = "Nome completo:";
            // 
            // btn_excluir
            // 
            this.btn_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btn_excluir.Location = new System.Drawing.Point(208, 353);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(190, 85);
            this.btn_excluir.TabIndex = 24;
            this.btn_excluir.Text = "🗑️ Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Pesquisar funcionario:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 26;
            // 
            // add_funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.txb_nome);
            this.Controls.Add(this.txb_cpf);
            this.Controls.Add(this.lbl_departamento);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_confirmar);
            this.Name = "add_funcionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "add_funcionario";
            this.Load += new System.EventHandler(this.add_funcionario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void add_funcionario_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.TextBox txb_nome;
        private System.Windows.Forms.TextBox txb_cpf;
        private System.Windows.Forms.Label lbl_departamento;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}