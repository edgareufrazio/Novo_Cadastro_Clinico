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
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_testar_conexao_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            // Extrai apenas os dígitos numéricos do MaskedTextBox
            string cpfLimpo = new string(mtbx_cpf.Text.Where(char.IsDigit).ToArray());

            // 1. Validação de preenchimento e regra matemática do CPF
            if (!ValidarCPF(cpfLimpo))
            {
                MessageBox.Show("Por favor, informe um CPF válido com 11 dígitos.", "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbx_cpf.Focus();
                return; // Impede a gravação no banco
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
                        cmd.Parameters.AddWithValue("@CPF", cpfLimpo); // Envia o CPF tratado ao banco

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

            // Extrai apenas os dígitos numéricos do MaskedTextBox
            string cpfLimpo = new string(mtbx_cpf.Text.Where(char.IsDigit).ToArray());

            // Validação do CPF antes de atualizar
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

        /// <summary>
        /// Valida a estrutura e os dígitos verificadores do CPF segundo as regras da Receita Federal.
        /// </summary>
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
    }
}