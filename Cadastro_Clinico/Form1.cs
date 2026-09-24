using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            this.AcceptButton = btn_entrar;
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            string nivel = ObterNivelUsuario(usuario, senha);

            if (nivel == null)
            {
                MessageBox.Show("Usuário ou senha incorretos.");

                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();

                return;
            }

            
            if (nivel == "Administrador")
            {
                Adicionar_usuario frm =
                    Application.OpenForms["Adicionar_usuario"]
                    as Adicionar_usuario;

                if (frm == null)
                {
                    frm = new Adicionar_usuario();
                    frm.Name = "Adicionar_usuario";
                    frm.Show();
                }
                else
                {
                    frm.Show();
                    frm.BringToFront();
                   
                }

                txtUsuario.Clear();
                txtSenha.Clear();

                this.Hide();

                return;
            }

           
            if (nivel == "Usuario")
            {
                Adicionar_cliente frm =
                    Application.OpenForms["Adicionar_cliente"]
                    as Adicionar_cliente;

                if (frm == null)
                {
                    frm = new Adicionar_cliente();
                    frm.Name = "Adicionar_cliente";
                    frm.Show();
                }
                else
                {
                    frm.Show();
                    frm.BringToFront();
                }

                txtUsuario.Clear();
                txtSenha.Clear();

                this.Hide();

                return;
            }

            MessageBox.Show("Nível de acesso inválido.");
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




        private string ObterNivelUsuario(string usuario, string senha)
        {
            string query = @"select Nivel from Logar where Usuario = @usuario and Senha = @senha";
            Connection conexao = new Connection();

            try
            {
                using (SqlConnection conn = conexao.Conectar())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 64).Value = usuario;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar, 64).Value = senha;

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                        return resultado.ToString();

                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar o banco:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }
        }

          

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            this.Close();

        }
        public void LimparLogin()
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }

      
    }
}
    

