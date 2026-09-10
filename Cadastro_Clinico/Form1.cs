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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor,Preencha todos os campos");
                return;
            }

            if (ValidarLogin(usuario, senha))
            {
                MessageBox.Show("Login efetuado com sucesso");
                txtUsuario.Clear();
                txtSenha.Clear();
                add_funcionario frm = Application.OpenForms["add_funcionario"] as add_funcionario;
                if (frm == null)
                {

                    frm = new add_funcionario();
                    frm.Name = "add_funcionario";
                    frm.Show();
                }
                else
                {
                    frm.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos");
                txtUsuario.Clear();
                txtSenha.Clear();


            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            try
            {
                Connection conexao = new Connection();

                using (SqlConnection conn = conexao.Conectar())
                {
                    MessageBox.Show("Conexão realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão:\n" + ex.Message);
            }
        }


        private bool ValidarLogin(string usuario, string senha)
        {
            string query = @" SELECT COUNT(*) FROM Logar WHERE Usuario = @usuario AND Senha = @senha";
            Connection conexao = new Connection();
            try
            {
                using (SqlConnection conn = conexao.Conectar()) 
                using (SqlCommand cmd = new SqlCommand(query, conn)) 
                { cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar, 100).Value = senha;
                    int resultado = Convert.ToInt32(cmd.ExecuteScalar()); 
                    return resultado > 0;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar o banco de dados:\n" + ex.Message, "Erro de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false; }
        }

    }
}
    

