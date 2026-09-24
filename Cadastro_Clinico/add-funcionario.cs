using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public partial class add_funcionario : Form
    {
        private readonly DataTable tabelaFuncionarios = new DataTable();
        private readonly BindingSource bindingSource = new BindingSource();
        private int idFuncionarioSelecionado = 0;
        private bool modoEscuro = false;
        private Image imagemFundoOriginal;

        public add_funcionario()
        {
            InitializeComponent();

            imagemFundoOriginal = this.BackgroundImage;
            EstilizarGrid();
        }

        #region SISTEMA DE TEMA E NAVEGAÇÃO

        private void btn_trocarTema_Click(object sender, EventArgs e)
        {
            modoEscuro = !modoEscuro;
            AplicarTema();
        }

        private void btn_abrirNovaTela_Click(object sender, EventArgs e)
        {
            Adicionar_cliente novaTela = new Adicionar_cliente();
            novaTela.Show();
        }

        public void AplicarTema()
        {
            // Função auxiliar interna para atualizar a imagem descartando a anterior sem vazar memória
            void AtualizarIconeBotao(Button btn, Image novaImagem)
            {
                if (btn != null)
                {
                    if (btn.Image != null)
                    {
                        btn.Image.Dispose(); // Libera a memória do ícone antigo
                    }
                    btn.Image = novaImagem;
                }
            }

            if (modoEscuro)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.FromArgb(30, 36, 45);

                // Atribui o ícone do SOL (indica troca para modo claro)
                AtualizarIconeBotao(btn_tema, GerarIconeSol());

                AtualizarCoresControles(this.Controls, Color.FromArgb(45, 52, 65), Color.White, Color.White);

                if (dataGridView != null)
                {
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.BackgroundColor = Color.FromArgb(45, 52, 65);
                    dataGridView.GridColor = Color.FromArgb(70, 80, 95);

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 30, 38);
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(45, 52, 65);
                    dataGridView.DefaultCellStyle.ForeColor = Color.White;
                    dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 100, 150);
                    dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
            else
            {
                this.BackgroundImage = imagemFundoOriginal;

                // Atribui o ícone da LUA (indica troca para modo escuro)
                AtualizarIconeBotao(btn_tema, GerarIconeLua());

                AtualizarCoresControles(this.Controls, Color.White, Color.FromArgb(30, 41, 59), Color.FromArgb(30, 41, 59));

                if (dataGridView != null)
                {
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.BackgroundColor = Color.White;
                    dataGridView.GridColor = Color.FromArgb(240, 243, 246);

                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);

                    dataGridView.DefaultCellStyle.BackColor = Color.White;
                    dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
                    dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 232, 240);
                    dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
                }
            }

            this.Refresh();
        }

        private void AtualizarCoresControles(Control.ControlCollection controles, Color fundoCampos, Color textoCampos, Color textoLabels)
        {
            foreach (Control c in controles)
            {
                if (c is Panel || c is GroupBox)
                {
                    c.BackColor = modoEscuro ? Color.FromArgb(45, 52, 65) : Color.Transparent;
                }

                if (c is TextBox || c is ComboBox || c is MaskedTextBox)
                {
                    c.BackColor = fundoCampos;
                    c.ForeColor = textoCampos;
                }
                else if (c is Label)
                {
                    c.ForeColor = textoLabels;
                    c.BackColor = Color.Transparent;
                }

                if (c.Controls.Count > 0)
                {
                    AtualizarCoresControles(c.Controls, fundoCampos, textoCampos, textoLabels);
                }
            }
        }

        #endregion

        #region GERADORES DE ÍCONES (SOL E LUA VIA CÓDIGO)

        #region GERADORES DE ÍCONES (SOL E LUA VIA CÓDIGO)

        private Bitmap GerarIconeSol()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent); // Limpa o fundo do bitmap

                using (Pen pen = new Pen(Color.FromArgb(255, 200, 0), 2))
                {
                    g.DrawLine(pen, 16, 2, 16, 6);   // Cima
                    g.DrawLine(pen, 16, 26, 16, 30); // Baixo
                    g.DrawLine(pen, 2, 16, 6, 16);   // Esquerda
                    g.DrawLine(pen, 26, 16, 30, 16); // Direita
                    g.DrawLine(pen, 6, 6, 9, 9);     // Diagonal sup-esq
                    g.DrawLine(pen, 26, 6, 23, 9);   // Diagonal sup-dir
                    g.DrawLine(pen, 6, 26, 9, 23);   // Diagonal inf-esq
                    g.DrawLine(pen, 26, 26, 23, 23); // Diagonal inf-dir
                }

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 200, 0)))
                {
                    g.FillEllipse(brush, 9, 9, 14, 14);
                }
            }
            return bmp;
        }

        private Bitmap GerarIconeLua()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent); // Limpa o fundo do bitmap

                // Desenha a lua recortando a região para transparência perfeita
                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    // Círculo principal da lua
                    path.AddEllipse(4, 4, 22, 22);

                    // Círculo de corte que cria o formato de crescente
                    using (System.Drawing.Drawing2D.GraphicsPath corte = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        corte.AddEllipse(10, 2, 20, 20);

                        // Subtrai o corte do caminho principal
                        Region regiaoLua = new Region(path);
                        regiaoLua.Exclude(corte);

                        using (SolidBrush brushLua = new SolidBrush(Color.FromArgb(70, 90, 120)))
                        {
                            g.FillRegion(brushLua, regiaoLua);
                        }
                    }
                }
            }
            return bmp;
        }

        #endregion

        #endregion

        #region ESTILIZAÇÃO DO GRID

        private void EstilizarGrid()
        {
            if (dataGridView == null) return;

            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.RowTemplate.Height = 40;

            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersHeight = 42;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AplicarTema();
            dataGridView.ClearSelection();
        }

        #endregion

        #region OPERAÇÕES DE BANCO DE DADOS (CRUD)

        private void CarregarDadosGrid()
        {
            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "SELECT * FROM Funcionarios";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        tabelaFuncionarios.Clear();
                        da.Fill(tabelaFuncionarios);

                        dataGridView.AutoGenerateColumns = true;
                        bindingSource.DataSource = tabelaFuncionarios;
                        dataGridView.DataSource = bindingSource;

                        ConfigurarCabecalhosGrid();
                    }
                }
            }
        }

        private void ConfigurarCabecalhosGrid()
        {
            if (dataGridView.Columns.Contains("Funcionario_id"))
            {
                dataGridView.Columns["Funcionario_id"].HeaderText = "ID";
                dataGridView.Columns["Funcionario_id"].Width = 40;
            }

            if (dataGridView.Columns.Contains("Nome_F"))
            {
                dataGridView.Columns["Nome_F"].HeaderText = "Nome Completo";
                dataGridView.Columns["Nome_F"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dataGridView.Columns.Contains("Email_func"))
            {
                dataGridView.Columns["Email_func"].HeaderText = "E-mail";
                dataGridView.Columns["Email_func"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dataGridView.Columns.Contains("Area"))
            {
                dataGridView.Columns["Area"].HeaderText = "Departamento";
                dataGridView.Columns["Area"].Width = 130;
            }

            if (dataGridView.Columns.Contains("CPF_func"))
            {
                dataGridView.Columns["CPF_func"].HeaderText = "CPF";
                dataGridView.Columns["CPF_func"].Width = 110;
            }
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string cpfLimpo = ObterCpfNumerico();

            if (!ValidarCPF(cpfLimpo))
            {
                MessageBox.Show("Por favor, informe um CPF válido com 11 dígitos.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbx_cpf.Focus();
                return;
            }

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "INSERT INTO Funcionarios (Nome_F, Email_func, Area, CPF_func) VALUES (@Nome, @Email, @Area, @CPF)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text.Trim());
                        cmd.Parameters.AddWithValue("@CPF", cpfLimpo);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            CarregarDadosGrid();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            if (idFuncionarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid antes de tentar atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cpfLimpo = ObterCpfNumerico();

            if (!ValidarCPF(cpfLimpo))
            {
                MessageBox.Show("Por favor, informe um CPF válido com 11 dígitos.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbx_cpf.Focus();
                return;
            }

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "UPDATE Funcionarios SET Nome_F = @Nome, Email_func = @Email, Area = @Area, CPF_func = @CPF WHERE Funcionario_id = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text.Trim());
                        cmd.Parameters.AddWithValue("@CPF", cpfLimpo);
                        cmd.Parameters.AddWithValue("@ID", idFuncionarioSelecionado);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Dados do funcionário atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            CarregarDadosGrid();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (idFuncionarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid antes de tentar excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Tem certeza de que deseja excluir este funcionário? Essa ação não pode ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No) return;

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "DELETE FROM Funcionarios WHERE Funcionario_id = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", idFuncionarioSelecionado);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            CarregarDadosGrid();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region EVENTOS E UTILITÁRIOS

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGridView.Rows[e.RowIndex];

                if (dataGridView.Columns.Contains("Funcionario_id") && linha.Cells["Funcionario_id"].Value != DBNull.Value)
                    idFuncionarioSelecionado = Convert.ToInt32(linha.Cells["Funcionario_id"].Value);

                if (dataGridView.Columns.Contains("Nome_F"))
                    txb_nome.Text = linha.Cells["Nome_F"].Value?.ToString();

                if (dataGridView.Columns.Contains("Email_func"))
                    txb_email.Text = linha.Cells["Email_func"].Value?.ToString();

                if (dataGridView.Columns.Contains("Area"))
                    cmbDepartamento.Text = linha.Cells["Area"].Value?.ToString();

                if (dataGridView.Columns.Contains("CPF_func"))
                    mtbx_cpf.Text = linha.Cells["CPF_func"].Value?.ToString();
            }
        }

        private void tbx_pesquisa_func_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroPesquisa();
        }

        private void tbx_pesquisa_func_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AplicarFiltroPesquisa();
            }
        }

        private void AplicarFiltroPesquisa()
        {
            if (bindingSource == null || bindingSource.DataSource == null) return;

            string termo = tbx_pesquisa_func.Text.Replace("'", "''").Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = string.Format("Nome_F LIKE '%{0}%' OR CPF_func LIKE '%{0}%'", termo);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txb_nome.Clear();
            txb_email.Clear();
            cmbDepartamento.SelectedIndex = -1;
            mtbx_cpf.Clear();

            idFuncionarioSelecionado = 0;
            txb_nome.Focus();
        }

        private string ObterCpfNumerico()
        {
            return new string(mtbx_cpf.Text.Where(char.IsDigit).ToArray());
        }

        private void mtbx_cpf_Click(object sender, EventArgs e)
        {
            if (ObterCpfNumerico().Length == 0)
            {
                mtbx_cpf.SelectionStart = 0;
                mtbx_cpf.SelectionLength = 0;
            }
        }

        private void mtbx_cpf_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                mtbx_cpf.SelectionStart = 0;
                mtbx_cpf.SelectionLength = 0;
            });
        }

        private bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11) return false;

            switch (cpf)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        #endregion
    }
}