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
    public partial class Adicionar_cliente : Form
    {
        public Adicionar_cliente()
        {
            InitializeComponent();
        }

        private void Adicionar_cliente_Load(object sender, EventArgs e)
        {
            AtualizarTelaPorData();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTelaPorData();
        }

        private void CarregarConsultasPorData(DateTime data)
        {
            // Consulta SQL ajustada com o nome real da tabela (Consultas) e coluna (Data_hora)
            // Usamos CAST(Data_hora AS DATE) para comparar apenas a data, ignorando o horário
            string sql = @"SELECT
    c.Nome_C AS[Nome do Cliente],
    f.Nome_F AS[Profissional],
    FORMAT(con.Data_hora, 'HH:mm') AS[Horário]
FROM Consultas con
INNER JOIN Clientes c ON con.Cliente_id = c.Cliente_id
INNER JOIN Funcionarios f ON con.Funcionario_id = f.Funcionario_id
WHERE CAST(con.Data_hora AS DATE) = @DataConsulta
ORDER BY con.Data_hora ASC";

            // NOTA: Substitua 'Conexao.ObterConexao()' pela classe/método de conexão do seu projeto
            Connection conexao = new Connection();
            using (conexao.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao.Conectar()))
                {
                    comando.Parameters.Add("@DataConsulta", SqlDbType.Date).Value = data;

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabela = new DataTable();

                    adaptador.Fill(tabela);

                    // Exibe o resultado no DataGridView (dgvConsultas)
                    dgv_agenda.DataSource = tabela;
                }
            }
        }
        private void AtualizarTelaPorData()
        {
            // Pega apenas a data (sem a hora) do DateTimePicker
            DateTime dataSelecionada = dateTimePicker1.Value.Date;

            // Coloca a data formatada no TextBox Data
            mtb_dataAtendimento.Text = dataSelecionada.ToString("dd/MM/yyyy");

            // Busca as consultas daquela data e preenche o DataGridView
            CarregarConsultasPorData(dataSelecionada);
        }

        //trocando de tela para add_funcionario
        private void tsm_addFuncionario_Click(object sender, EventArgs e)
        {
            add_funcionario novaTela = new add_funcionario();

            
            novaTela.Show();

            
            this.Hide();
        }


        //trocando de tela para add_cliente
        private void tsm_addCliente_Click(object sender, EventArgs e)
        {
            Adicionar_cliente novaTela = new Adicionar_cliente();
            novaTela.Focus();
            this.Hide();
        }

    }
}
