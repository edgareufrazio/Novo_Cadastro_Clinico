using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public partial class add_funcionario : Form
    {
        private DataTable tabelaFuncionarios = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        private int idFuncionarioSelecionado = 0;

        public add_funcionario()
        {
            InitializeComponent();
            EstilizarGrid(); // <--- Chama a formatação visual do Grid assim que o formulário inicia
        }

        private void EstilizarGrid()
        {
            // 1. Limpeza de Borda e Fundo
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.GridColor = Color.FromArgb(240, 243, 246);

            // 2. Comportamento das Linhas e Seleção
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.RowTemplate.Height = 40;

            // Remove a seleção azul dos cabeçalhos das colunas
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Estilo das Linhas do Grid
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);

            // Seleção de Linha (Cinza Claro Moderno - sem o azul escuro)
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 232, 240);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // 3. Estilo do Cabeçalho (Topo)
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersHeight = 42;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // 4. Ajuste e Renderização
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ClearSelection(); // Evita que a primeira célula venha marcada de azul ao abrir
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Adicionar_cliente novaTela = new Adicionar_cliente();
            novaTela.Show();
            novaTela.Focus();
        }

        private void btn_testar_conexao_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            string cpfLimpo = new string(mtbx_cpf.Text.Where(char.IsDigit).ToArray());

            if (!ValidarCPF(cpfLimpo))
            {
                MessageBox.Show("Por favor, informe um CPF válido com 11 dígitos.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbx_cpf.Focus();
                return;
            }

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    string sql = "INSERT INTO Funcionarios (Nome_F, Email_func, Area, CPF_func) " +
                                 "VALUES (@Nome, @Email, @Area, @CPF)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text.Trim());
                        cmd.Parameters.AddWithValue("@CPF", cpfLimpo);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
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

        private void LimparCampos()
        {
            txb_nome.Clear();
            txb_email.Clear();
            cmbDepartamento.SelectedIndex = -1;
            mtbx_cpf.Clear();

            // Garante que o ID seja zerado para novos cadastros
            idFuncionarioSelecionado = 0;

            txb_nome.Focus();
        }

        private void lbl_sobrenome_Click(object sender, EventArgs e)
        {

        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            if (idFuncionarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid antes de tentar atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cpfLimpo = new string(mtbx_cpf.Text.Where(char.IsDigit).ToArray());

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
                    string sql = "UPDATE Funcionarios " +
                                 "SET Nome_F = @Nome, Email_func = @Email, Area = @Area, CPF_func = @CPF " +
                                 "WHERE Funcionario_id = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text.Trim());
                        cmd.Parameters.AddWithValue("@CPF", cpfLimpo);
                        cmd.Parameters.AddWithValue("@ID", idFuncionarioSelecionado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados do funcionário atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            idFuncionarioSelecionado = 0;
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

        private void tbx_pesquisa_func_TextChanged(object sender, EventArgs e)
        {
            if (bindingSource == null || bindingSource.DataSource == null)
                return;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbx_pesquisa_func_TextChanged(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregarDadosGrid()
        {
            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "SELECT * FROM Funcionarios";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            tabelaFuncionarios.Clear();
                            da.Fill(tabelaFuncionarios);

                            dataGridView.AutoGenerateColumns = true;
                            bindingSource.DataSource = tabelaFuncionarios;
                            dataGridView.DataSource = bindingSource;

                            // 1. Altera os nomes dos cabeçalhos
                            if (dataGridView.Columns.Contains("Funcionario_id"))
                                dataGridView.Columns["Funcionario_id"].HeaderText = "ID";

                            if (dataGridView.Columns.Contains("Nome_F"))
                                dataGridView.Columns["Nome_F"].HeaderText = "Nome Completo";

                            if (dataGridView.Columns.Contains("Email_func"))
                                dataGridView.Columns["Email_func"].HeaderText = "E-mail";

                            if (dataGridView.Columns.Contains("Area"))
                                dataGridView.Columns["Area"].HeaderText = "Departamento";

                            if (dataGridView.Columns.Contains("CPF_func"))
                                dataGridView.Columns["CPF_func"].HeaderText = "CPF";

                            // 2. Ajusta as larguras para não cortar o título "Departamento"
                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                            if (dataGridView.Columns.Contains("Funcionario_id"))
                                dataGridView.Columns["Funcionario_id"].Width = 40;

                            if (dataGridView.Columns.Contains("CPF_func"))
                                dataGridView.Columns["CPF_func"].Width = 110;

                            if (dataGridView.Columns.Contains("Area"))
                                dataGridView.Columns["Area"].Width = 130;

                            if (dataGridView.Columns.Contains("Nome_F"))
                                dataGridView.Columns["Nome_F"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                            if (dataGridView.Columns.Contains("Email_func"))
                                dataGridView.Columns["Email_func"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dataGridView.Rows[e.RowIndex];

                if (dataGridView.Columns.Contains("Funcionario_id") && linha.Cells["Funcionario_id"].Value != DBNull.Value)
                {
                    idFuncionarioSelecionado = Convert.ToInt32(linha.Cells["Funcionario_id"].Value);
                }

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

            if (resultado == DialogResult.No)
            {
                return;
            }

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    string sql = "DELETE FROM Funcionarios WHERE Funcionario_id = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", idFuncionarioSelecionado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            idFuncionarioSelecionado = 0;
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

        private void tbx_pesquisa_func_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (bindingSource == null || bindingSource.DataSource == null)
                    return;

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
        }

        private void tbx_pesquisa_func_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtbx_cpf_Click(object sender, EventArgs e)
        {
            if (mtbx_cpf.Text.Replace(".", "").Replace("-", "").Trim().Length == 0)
            {
                mtbx_cpf.SelectionStart = 0;
                mtbx_cpf.SelectionLength = 0;
            }
        }

        private void mtbx_cpf_Enter_1(object sender, EventArgs e)
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

            if (cpf.Length != 11)
                return false;

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

            int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }
    }
}