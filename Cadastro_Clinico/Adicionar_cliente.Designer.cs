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
            this.components = new System.ComponentModel.Container();
            this.mtb_dataAtendimento = new System.Windows.Forms.MaskedTextBox();
            this.mtb_cep = new System.Windows.Forms.MaskedTextBox();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_endereço = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.mtb_cpf = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_horarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_nomeProfissional = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_agenda = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsm_addFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_deslogar = new System.Windows.Forms.Button();
            this.mtb_data_nascimento = new System.Windows.Forms.MaskedTextBox();
            this.mtb_valor = new System.Windows.Forms.MaskedTextBox();
            this.txb_numero = new System.Windows.Forms.TextBox();
            this.txb_complemento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtb_dataAtendimento
            // 
            this.mtb_dataAtendimento.Location = new System.Drawing.Point(15, 59);
            this.mtb_dataAtendimento.Mask = "00/00/0000";
            this.mtb_dataAtendimento.Name = "mtb_dataAtendimento";
            this.mtb_dataAtendimento.Size = new System.Drawing.Size(80, 20);
            this.mtb_dataAtendimento.TabIndex = 10;
            this.mtb_dataAtendimento.ValidatingType = typeof(System.DateTime);
            this.mtb_dataAtendimento.Leave += new System.EventHandler(this.mtb_dataAtendimento_Leave);
            // 
            // mtb_cep
            // 
            this.mtb_cep.Location = new System.Drawing.Point(15, 299);
            this.mtb_cep.Name = "mtb_cep";
            this.mtb_cep.Size = new System.Drawing.Size(80, 20);
            this.mtb_cep.TabIndex = 6;
            this.mtb_cep.Leave += new System.EventHandler(this.mtb_cep_Leave);
            // 
            // btn_excluir
            // 
            this.btn_excluir.Location = new System.Drawing.Point(177, 415);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_excluir.TabIndex = 15;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.Location = new System.Drawing.Point(96, 415);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_atualizar.TabIndex = 14;
            this.btn_atualizar.Text = "Atualizar";
            this.btn_atualizar.UseVisualStyleBackColor = true;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(15, 415);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(75, 23);
            this.btn_salvar.TabIndex = 13;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 367);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Valor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 70;
            this.label9.Text = "CEP";
            // 
            // txb_endereço
            // 
            this.txb_endereço.Location = new System.Drawing.Point(101, 299);
            this.txb_endereço.Name = "txb_endereço";
            this.txb_endereço.ReadOnly = true;
            this.txb_endereço.Size = new System.Drawing.Size(283, 20);
            this.txb_endereço.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Endereço";
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(12, 262);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(375, 20);
            this.txb_email.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "E-mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Data de nascimento";
            // 
            // txb_nome
            // 
            this.txb_nome.Location = new System.Drawing.Point(12, 184);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(375, 20);
            this.txb_nome.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Nome";
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Location = new System.Drawing.Point(139, 140);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(75, 23);
            this.btn_pesquisar.TabIndex = 2;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // mtb_cpf
            // 
            this.mtb_cpf.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtb_cpf.Location = new System.Drawing.Point(12, 142);
            this.mtb_cpf.Name = "mtb_cpf";
            this.mtb_cpf.Size = new System.Drawing.Size(83, 20);
            this.mtb_cpf.TabIndex = 1;
            this.mtb_cpf.Enter += new System.EventHandler(this.mtb_cpf_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "CPF do cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Horários disponiveis";
            // 
            // cbx_horarios
            // 
            this.cbx_horarios.FormattingEnabled = true;
            this.cbx_horarios.Location = new System.Drawing.Point(211, 101);
            this.cbx_horarios.Name = "cbx_horarios";
            this.cbx_horarios.Size = new System.Drawing.Size(146, 21);
            this.cbx_horarios.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Data do atendimento";
            // 
            // cbx_nomeProfissional
            // 
            this.cbx_nomeProfissional.FormattingEnabled = true;
            this.cbx_nomeProfissional.Location = new System.Drawing.Point(12, 101);
            this.cbx_nomeProfissional.Name = "cbx_nomeProfissional";
            this.cbx_nomeProfissional.Size = new System.Drawing.Size(181, 21);
            this.cbx_nomeProfissional.TabIndex = 11;
            this.cbx_nomeProfissional.SelectionChangeCommitted += new System.EventHandler(this.cbx_nomeProfissional_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nome do profissional";
            // 
            // dgv_agenda
            // 
            this.dgv_agenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_agenda.Location = new System.Drawing.Point(390, 59);
            this.dgv_agenda.Name = "dgv_agenda";
            this.dgv_agenda.ReadOnly = true;
            this.dgv_agenda.Size = new System.Drawing.Size(399, 369);
            this.dgv_agenda.TabIndex = 17;
            this.dgv_agenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_agenda_CellClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(494, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_addFuncionario});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 80;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsm_addFuncionario
            // 
            this.tsm_addFuncionario.Name = "tsm_addFuncionario";
            this.tsm_addFuncionario.Size = new System.Drawing.Size(136, 20);
            this.tsm_addFuncionario.Text = "Adicionar Funcionário";
            this.tsm_addFuncionario.Click += new System.EventHandler(this.tsm_addFuncionario_Click);
            // 
            // btn_deslogar
            // 
            this.btn_deslogar.Location = new System.Drawing.Point(258, 415);
            this.btn_deslogar.Name = "btn_deslogar";
            this.btn_deslogar.Size = new System.Drawing.Size(75, 23);
            this.btn_deslogar.TabIndex = 18;
            this.btn_deslogar.Text = "Deslogar";
            this.btn_deslogar.UseVisualStyleBackColor = true;
            this.btn_deslogar.Click += new System.EventHandler(this.btn_deslogar_Click);
            // 
            // mtb_data_nascimento
            // 
            this.mtb_data_nascimento.Location = new System.Drawing.Point(15, 223);
            this.mtb_data_nascimento.Mask = "00/00/0000";
            this.mtb_data_nascimento.Name = "mtb_data_nascimento";
            this.mtb_data_nascimento.Size = new System.Drawing.Size(80, 20);
            this.mtb_data_nascimento.TabIndex = 4;
            this.mtb_data_nascimento.ValidatingType = typeof(System.DateTime);
            // 
            // mtb_valor
            // 
            this.mtb_valor.Location = new System.Drawing.Point(13, 389);
            this.mtb_valor.Name = "mtb_valor";
            this.mtb_valor.Size = new System.Drawing.Size(80, 20);
            this.mtb_valor.TabIndex = 9;
            this.mtb_valor.TextChanged += new System.EventHandler(this.mtb_valor_TextChanged);
            // 
            // txb_numero
            // 
            this.txb_numero.Location = new System.Drawing.Point(15, 344);
            this.txb_numero.Name = "txb_numero";
            this.txb_numero.Size = new System.Drawing.Size(142, 20);
            this.txb_numero.TabIndex = 7;
            // 
            // txb_complemento
            // 
            this.txb_complemento.Location = new System.Drawing.Point(167, 344);
            this.txb_complemento.Name = "txb_complemento";
            this.txb_complemento.Size = new System.Drawing.Size(142, 20);
            this.txb_complemento.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 86;
            this.label11.Text = "Numero";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 87;
            this.label12.Text = "Complemento";
            // 
            // Adicionar_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txb_complemento);
            this.Controls.Add(this.txb_numero);
            this.Controls.Add(this.mtb_valor);
            this.Controls.Add(this.mtb_data_nascimento);
            this.Controls.Add(this.btn_deslogar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mtb_dataAtendimento);
            this.Controls.Add(this.mtb_cep);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txb_endereço);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_nome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.mtb_cpf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_horarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_nomeProfissional);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_agenda);
            this.Controls.Add(this.dateTimePicker1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Adicionar_cliente";
            this.Text = "Adicionar_cliente";
            this.Load += new System.EventHandler(this.Adicionar_cliente_Load);
            this.Leave += new System.EventHandler(this.Adicionar_cliente_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtb_dataAtendimento;
        private System.Windows.Forms.MaskedTextBox mtb_cep;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_endereço;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_nome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.MaskedTextBox mtb_cpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_horarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_nomeProfissional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_agenda;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsm_addFuncionario;
        private System.Windows.Forms.Button btn_deslogar;
        private System.Windows.Forms.MaskedTextBox mtb_data_nascimento;
        private System.Windows.Forms.MaskedTextBox mtb_valor;
        private System.Windows.Forms.TextBox txb_numero;
        private System.Windows.Forms.TextBox txb_complemento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}