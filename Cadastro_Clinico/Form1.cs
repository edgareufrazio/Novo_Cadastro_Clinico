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
            
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            Connection conexao = new Connection();

            try
            {
                SqlConnection conn = conexao.Conectar();

                MessageBox.Show("Conexão realizada com sucesso!");

                conexao.Desconectar(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão:\n" + ex.Message);
            }
        }
    }
}
