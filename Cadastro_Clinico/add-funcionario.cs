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
            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    // Adicionado a coluna CPF_func no INSERT
                    string sql = "INSERT INTO Funcionarios (Nome_F, Email_func, Area, CPF_func) " +
                                 "VALUES (@Nome, @Email, @Area, @CPF)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text);
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text);
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text);
                        cmd.Parameters.AddWithValue("@CPF", txb_cpf.Text); // Substitua pelo nome do seu campo de CPF

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Funcionário cadastrado no banco Projeto com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //txb_sobrenome.Clear();
            txb_email.Clear();
            cmbDepartamento.SelectedIndex = -1;
            txb_nome.Focus();
        }

        private void lbl_sobrenome_Click(object sender, EventArgs e)
        {

        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            // Valida se algum funcionário foi selecionado no DataGridView antes de tentar atualizar
            if (idFuncionarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid antes de tentar atualizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Connection conn = new Connection();

            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    // Comando SQL UPDATE apontando para o idFuncionarioSelecionado
                    string sql = "UPDATE Funcionarios " +
                                 "SET Nome_F = @Nome, Email_func = @Email, Area = @Area, CPF_func = @CPF " +
                                 "WHERE Funcionario_id = @ID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text);
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text);
                        cmd.Parameters.AddWithValue("@Area", cmbDepartamento.Text);
                        cmd.Parameters.AddWithValue("@CPF", txb_cpf.Text);
                        cmd.Parameters.AddWithValue("@ID", idFuncionarioSelecionado);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados do funcionário atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            idFuncionarioSelecionado = 0; // Reseta o ID selecionado
                            CarregarDadosGrid();          // Recarrega o grid com os dados novos
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                    // O SELECT * funciona independente dos nomes das colunas
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

                // Captura o ID da linha selecionada para saber quem atualizar depois
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
                    txb_cpf.Text = linha.Cells["CPF_func"].Value?.ToString();
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            // 1. Verifica se o usuário selecionou uma linha no DataGridView
            if (idFuncionarioSelecionado == 0)
            {
                MessageBox.Show("Selecione um funcionário no grid antes de tentar excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pergunta de confirmação de segurança antes de apagar do banco
            DialogResult resultado = MessageBox.Show(
                "Tem certeza de que deseja excluir este funcionário? Essa ação não pode ser desfeita.",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Se o usuário clicar em 'Não', cancela a operação
            if (resultado == DialogResult.No)
            {
                return;
            }

            // 3. Conexão e execução do comando DELETE
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
                            idFuncionarioSelecionado = 0; // Reseta o ID armazenado
                            CarregarDadosGrid();          // Recarrega o grid atualizado
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}