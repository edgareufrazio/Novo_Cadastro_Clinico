using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public partial class Adicionar_usuario : Form
    {
        public Adicionar_usuario()
        {
            InitializeComponent();
        }

        private void Adicionar_usuario_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            string queryVerificar = @"
                SELECT COUNT(*)
                FROM Logar
                WHERE Usuario = @usuario";

            string queryCadastrar = @"
                INSERT INTO Logar (Usuario, Senha)
                VALUES (@usuario, @senha)";

            Connection conexao = new Connection();

            try
            {
                using (SqlConnection conn = conexao.Conectar())
                {
                   
                    using (SqlCommand cmdVerificar =
                           new SqlCommand(queryVerificar, conn))
                    {
                        cmdVerificar.Parameters.Add(
                            "@usuario",
                            SqlDbType.VarChar,
                            50
                        ).Value = usuario;

                        int existe = Convert.ToInt32(
                            cmdVerificar.ExecuteScalar()
                        );

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Esse usuário já está cadastrado."
                            );

                            return;
                        }
                    }

                   
                    using (SqlCommand cmdCadastrar =
                           new SqlCommand(queryCadastrar, conn))
                    {
                        cmdCadastrar.Parameters.Add(
                            "@usuario",
                            SqlDbType.VarChar,
                            50
                        ).Value = usuario;

                        cmdCadastrar.Parameters.Add(
                            "@senha",
                            SqlDbType.VarChar,
                            100
                        ).Value = senha;

                        cmdCadastrar.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Usuário cadastrado com sucesso!");
               

                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar usuário:\n\n" + ex.Message);
            }
        }
        private void CarregarUsuarios()
        {
            string query = @"SELECT Usuario, Senha FROM Logar ORDER BY Usuario";

            Connection conexao = new Connection();
            try
            {
                using (SqlConnection conn = conexao.Conectar())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabela = new DataTable();

                    da.Fill(tabela);

                    gridUsuarios.DataSource = tabela;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Erro ao carregar usuarios:\n\n" + ex.Message);
               
            }
        }

        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtUsuario.Text = gridUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                txtSenha.Text = gridUsuarios.Rows[e.RowIndex].Cells["Senha"].Value.ToString();
            }
        }
    }
}
