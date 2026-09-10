namespace Cadastro_Clinico
{
    partial class Adicionar_cliente
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
            this.mtb_dataAtendimento = new System.Windows.Forms.MaskedTextBox();
            this.mtb_cep = new System.Windows.Forms.MaskedTextBox();
            this.btn_addFuncionario = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.txb_valor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_endereço = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_dataNascimento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.mtb_cpf = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_horarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_nomeProfissional = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_agenda = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).BeginInit();
            this.SuspendLayout();
            // 
            // mtb_dataAtendimento
            // 
            this.mtb_dataAtendimento.Location = new System.Drawing.Point(18, 49);
            this.mtb_dataAtendimento.Mask = "00/00/0000";
            this.mtb_dataAtendimento.Name = "mtb_dataAtendimento";
            this.mtb_dataAtendimento.Size = new System.Drawing.Size(80, 20);
            this.mtb_dataAtendimento.TabIndex = 78;
            this.mtb_dataAtendimento.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_cep
            // 
            this.mtb_cep.Location = new System.Drawing.Point(18, 334);
            this.mtb_cep.Mask = "00000-00";
            this.mtb_cep.Name = "mtb_cep";
            this.mtb_cep.Size = new System.Drawing.Size(80, 20);
            this.mtb_cep.TabIndex = 77;
            // 
            // btn_addFuncionario
            // 
            this.btn_addFuncionario.Location = new System.Drawing.Point(261, 405);
            this.btn_addFuncionario.Name = "btn_addFuncionario";
            this.btn_addFuncionario.Size = new System.Drawing.Size(129, 23);
            this.btn_addFuncionario.TabIndex = 76;
            this.btn_addFuncionario.Text = "Adicionar funcionario";
            this.btn_addFuncionario.UseVisualStyleBackColor = true;
            // 
            // btn_excluir
            // 
            this.btn_excluir.Location = new System.Drawing.Point(180, 405);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_excluir.TabIndex = 75;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Location = new System.Drawing.Point(99, 405);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_atualizar.TabIndex = 74;
            this.btn_atualizar.Text = "Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(18, 405);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar.TabIndex = 73;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            // 
            // txb_valor
            // 
            this.txb_valor.Location = new System.Drawing.Point(18, 373);
            this.txb_valor.Name = "txb_valor";
            this.txb_valor.Size = new System.Drawing.Size(372, 20);
            this.txb_valor.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Valor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "CEP";
            // 
            // txb_endereço
            // 
            this.txb_endereço.Location = new System.Drawing.Point(15, 295);
            this.txb_endereço.Name = "txb_endereço";
            this.txb_endereço.Size = new System.Drawing.Size(375, 20);
            this.txb_endereço.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Endereço";
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(15, 252);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(375, 20);
            this.txb_email.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "E-mail";
            // 
            // txb_dataNascimento
            // 
            this.txb_dataNascimento.Location = new System.Drawing.Point(15, 213);
            this.txb_dataNascimento.Name = "txb_dataNascimento";
            this.txb_dataNascimento.Size = new System.Drawing.Size(375, 20);
            this.txb_dataNascimento.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Data de nascimento";
            // 
            // txb_nome
            // 
            this.txb_nome.Location = new System.Drawing.Point(15, 174);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(375, 20);
            this.txb_nome.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Nome";
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Location = new System.Drawing.Point(142, 130);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(75, 23);
            this.btn_pesquisar.TabIndex = 61;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            // 
            // mtb_cpf
            // 
            this.mtb_cpf.Location = new System.Drawing.Point(15, 132);
            this.mtb_cpf.Mask = "000.000.000-00";
            this.mtb_cpf.Name = "mtb_cpf";
            this.mtb_cpf.Size = new System.Drawing.Size(83, 20);
            this.mtb_cpf.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "CPF do cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Horários disponiveis";
            // 
            // cmb_horarios
            // 
            this.cmb_horarios.FormattingEnabled = true;
            this.cmb_horarios.Location = new System.Drawing.Point(214, 91);
            this.cmb_horarios.Name = "cmb_horarios";
            this.cmb_horarios.Size = new System.Drawing.Size(146, 21);
            this.cmb_horarios.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Data do atendimento";
            // 
            // cbx_nomeProfissional
            // 
            this.cbx_nomeProfissional.FormattingEnabled = true;
            this.cbx_nomeProfissional.Location = new System.Drawing.Point(15, 91);
            this.cbx_nomeProfissional.Name = "cbx_nomeProfissional";
            this.cbx_nomeProfissional.Size = new System.Drawing.Size(181, 21);
            this.cbx_nomeProfissional.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nome do profissional";
            // 
            // dgv_agenda
            // 
            this.dgv_agenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_agenda.Location = new System.Drawing.Point(390, 49);
            this.dgv_agenda.Name = "dgv_agenda";
            this.dgv_agenda.Size = new System.Drawing.Size(399, 379);
            this.dgv_agenda.TabIndex = 53;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(504, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker1.TabIndex = 52;
            // 
            // Adicionar_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mtb_dataAtendimento);
            this.Controls.Add(this.mtb_cep);
            this.Controls.Add(this.btn_addFuncionario);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.txb_valor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txb_endereço);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_dataNascimento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_nome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.mtb_cpf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_horarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_nomeProfissional);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_agenda);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Adicionar_cliente";
            this.Text = "Adicionar_cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtb_dataAtendimento;
        private System.Windows.Forms.MaskedTextBox mtb_cep;
        private System.Windows.Forms.Button btn_addFuncionario;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.TextBox txb_valor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_endereço;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_dataNascimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_nome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.MaskedTextBox mtb_cpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_horarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_nomeProfissional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_agenda;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}