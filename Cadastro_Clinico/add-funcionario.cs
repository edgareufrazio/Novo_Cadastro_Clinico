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
            // Instancia a sua classe de conexão
            Connection conn = new Connection();

            // Obtém a SqlConnection
            using (SqlConnection con = conn.Conectar())
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    string sql = "INSERT INTO Funcionarios (Nome, Sobrenome, Email, Departamento) " +
                                 "VALUES (@Nome, @Sobrenome, @Email, @Departamento)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Passa os valores das caixas de texto protegendo contra SQL Injection
                        cmd.Parameters.AddWithValue("@Nome", txb_nome.Text);
                        cmd.Parameters.AddWithValue("@Sobrenome", txb_sobrenome.Text);
                        cmd.Parameters.AddWithValue("@Email", txb_email.Text);
                        cmd.Parameters.AddWithValue("@Departamento", cmbDepartamento.Text);

                        // Executa o comando no banco de dados
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Funcionário cadastrado no banco de dados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
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
            txb_sobrenome.Clear();
            txb_email.Clear();
            cmbDepartamento.SelectedIndex = -1;
            txb_nome.Focus();
        }
    }
}
