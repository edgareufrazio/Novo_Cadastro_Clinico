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
            // Verifica se o clique foi em uma linha válida (evita erros ao clicar no cabeçalho)
            if (e.RowIndex >= 0)
            {
                // Pega a linha atual selecionada
                DataGridViewRow linha = dataGridView.Rows[e.RowIndex];

                // Preenche os campos da tela com os valores da linha clicada
                txb_nome.Text = linha.Cells["Nome_F"].Value?.ToString();
                txb_email.Text = linha.Cells["Email_func"].Value?.ToString();
                cmbDepartamento.Text = linha.Cells["Area"].Value?.ToString();
            }
        }
    }
}