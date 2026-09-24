using System;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_funcionario));
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.lbl_departamento = new System.Windows.Forms.Label();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_pesquisa_func = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.mtbx_cpf = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btn_tema = new RoundedButton();
            this.roundedButton3 = new RoundedButton();
            this.roundedButton2 = new RoundedButton();
            this.roundedButton1 = new RoundedButton();
            this.btnConfirmarNovo = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Items.AddRange(new object[] {
            "Terapeuta",
            "Psicólogo"});
            this.cmbDepartamento.Location = new System.Drawing.Point(129, 263);
            this.cmbDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(151, 25);
            this.cmbDepartamento.TabIndex = 4;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(71, 194);
            this.txb_email.Margin = new System.Windows.Forms.Padding(4);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(200, 25);
            this.txb_email.TabIndex = 2;
            // 
            // txb_nome
            // 
            this.txb_nome.Location = new System.Drawing.Point(139, 157);
            this.txb_nome.Margin = new System.Windows.Forms.Padding(4);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(200, 25);
            this.txb_nome.TabIndex = 1;
            // 
            // lbl_departamento
            // 
            this.lbl_departamento.AutoSize = true;
            this.lbl_departamento.BackColor = System.Drawing.Color.Transparent;
            this.lbl_departamento.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_departamento.Location = new System.Drawing.Point(16, 268);
            this.lbl_departamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_departamento.Name = "lbl_departamento";
            this.lbl_departamento.Size = new System.Drawing.Size(115, 20);
            this.lbl_departamento.TabIndex = 18;
            this.lbl_departamento.Text = "Departamento:";
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cpf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_cpf.Location = new System.Drawing.Point(16, 233);
            this.lbl_cpf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(39, 20);
            this.lbl_cpf.TabIndex = 17;
            this.lbl_cpf.Text = "CPF:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.BackColor = System.Drawing.Color.Transparent;
            this.lbl_email.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_email.Location = new System.Drawing.Point(16, 199);
            this.lbl_email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(57, 20);
            this.lbl_email.TabIndex = 16;
            this.lbl_email.Text = "E-mail:";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_nome.Location = new System.Drawing.Point(13, 162);
            this.lbl_nome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(126, 20);
            this.lbl_nome.TabIndex = 15;
            this.lbl_nome.Text = "Nome completo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Pesquisar funcionario:";
            // 
            // tbx_pesquisa_func
            // 
            this.tbx_pesquisa_func.BackColor = System.Drawing.Color.White;
            this.tbx_pesquisa_func.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbx_pesquisa_func.Location = new System.Drawing.Point(168, 93);
            this.tbx_pesquisa_func.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_pesquisa_func.Name = "tbx_pesquisa_func";
            this.tbx_pesquisa_func.Size = new System.Drawing.Size(320, 25);
            this.tbx_pesquisa_func.TabIndex = 5;
            this.tbx_pesquisa_func.TextChanged += new System.EventHandler(this.tbx_pesquisa_func_TextChanged_1);
            this.tbx_pesquisa_func.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_pesquisa_func_KeyDown);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.dataGridView.Location = new System.Drawing.Point(522, 70);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(427, 322);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // mtbx_cpf
            // 
            this.mtbx_cpf.Location = new System.Drawing.Point(55, 230);
            this.mtbx_cpf.Margin = new System.Windows.Forms.Padding(4);
            this.mtbx_cpf.Mask = "000.000.000-00";
            this.mtbx_cpf.Name = "mtbx_cpf";
            this.mtbx_cpf.Size = new System.Drawing.Size(116, 25);
            this.mtbx_cpf.TabIndex = 3;
            this.mtbx_cpf.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.mtbx_cpf.Click += new System.EventHandler(this.mtbx_cpf_Click);
            this.mtbx_cpf.Enter += new System.EventHandler(this.mtbx_cpf_Enter_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(379, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Preencha os dados abaixo para adicionar um novo funcionário.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 40);
            this.label3.TabIndex = 30;
            this.label3.Text = "Cadastrar Funcionário";
            // 
            // btn_tema
            // 
            this.btn_tema.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_tema.BorderRadius = 20;
            this.btn_tema.FlatAppearance.BorderSize = 0;
            this.btn_tema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tema.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tema.ForeColor = System.Drawing.Color.Black;
            this.btn_tema.Location = new System.Drawing.Point(921, 12);
            this.btn_tema.Name = "btn_tema";
            this.btn_tema.Size = new System.Drawing.Size(44, 37);
            this.btn_tema.TabIndex = 31;
            this.btn_tema.UseVisualStyleBackColor = false;
            this.btn_tema.Click += new System.EventHandler(this.btn_trocarTema_Click);
            // 
            // roundedButton3
            // 
            this.roundedButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.roundedButton3.BorderRadius = 20;
            this.roundedButton3.FlatAppearance.BorderSize = 0;
            this.roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.roundedButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.roundedButton3.Location = new System.Drawing.Point(615, 523);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.Size = new System.Drawing.Size(197, 50);
            this.roundedButton3.TabIndex = 9;
            this.roundedButton3.Text = "❌ Cancelar";
            this.roundedButton3.UseVisualStyleBackColor = false;
            this.roundedButton3.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(214)))), ((int)(((byte)(250)))));
            this.roundedButton2.BorderRadius = 20;
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.roundedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(165)))));
            this.roundedButton2.Location = new System.Drawing.Point(209, 523);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(197, 50);
            this.roundedButton2.TabIndex = 7;
            this.roundedButton2.Text = "🔄 Atualizar";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.roundedButton1.BorderRadius = 20;
            this.roundedButton1.FlatAppearance.BorderSize = 0;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.roundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(104)))), ((int)(((byte)(168)))));
            this.roundedButton1.Location = new System.Drawing.Point(412, 523);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(197, 50);
            this.roundedButton1.TabIndex = 8;
            this.roundedButton1.Text = "🗑️ Excluir";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // btnConfirmarNovo
            // 
            this.btnConfirmarNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(236)))));
            this.btnConfirmarNovo.BorderRadius = 20;
            this.btnConfirmarNovo.FlatAppearance.BorderSize = 0;
            this.btnConfirmarNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarNovo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarNovo.Location = new System.Drawing.Point(6, 523);
            this.btnConfirmarNovo.Name = "btnConfirmarNovo";
            this.btnConfirmarNovo.Size = new System.Drawing.Size(197, 50);
            this.btnConfirmarNovo.TabIndex = 6;
            this.btnConfirmarNovo.Text = "✅ Confirmar";
            this.btnConfirmarNovo.UseVisualStyleBackColor = false;
            this.btnConfirmarNovo.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // add_funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(967, 589);
            this.Controls.Add(this.btn_tema);
            this.Controls.Add(this.roundedButton3);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.btnConfirmarNovo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtbx_cpf);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tbx_pesquisa_func);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.txb_nome);
            this.Controls.Add(this.lbl_departamento);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_nome);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(100)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "add_funcionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "add_funcionario";
            this.Load += new System.EventHandler(this.add_funcionario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_tema_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mtbx_cpf_Enter_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tbx_pesquisa_func_TextChanged_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void add_funcionario_Load(object sender, EventArgs e)
        {
            CarregarDadosGrid();
            EstilizarGrid(); // <--- Chama o estilo quando a tela abre
            CarregarDadosGrid(); // Chama seu método normal de carregar os funcionários do banco


            //throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.TextBox txb_nome;
        private System.Windows.Forms.Label lbl_departamento;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_pesquisa_func;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MaskedTextBox mtbx_cpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundedButton btnConfirmarNovo;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton3;
        private RoundedButton btn_tema;
    }
}