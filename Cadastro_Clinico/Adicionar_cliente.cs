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
            string sql = @"
                SELECT 
                    Consulta_id,
                    Valor,
                    Data_hora,
                    Cliente_id,
                    Funcionario_id
                FROM Consultas
                WHERE CAST(Data_hora AS DATE) = @DataConsulta";

            // NOTA: Substitua 'Conexao.ObterConexao()' pela classe/método de conexão do seu projeto
            using (SqlConnection conexao = Connection.ObterConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
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


    }
}
