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

        //------------Métodos-----------
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
        //private void tsm_addCliente_Click(object sender, EventArgs e)
        //{
        //    Adicionar_cliente novaTela = new Adicionar_cliente();
        //    novaTela.Focus();
        //    this.Hide();
        //}

        //caregar profissionais no combobox
        private void CarregarProfissionais()
        {
            string sql = "SELECT Funcionario_id, Nome_F FROM Funcionarios ORDER BY Nome_F ASC";

            Connection conexao = new Connection();
            using (SqlConnection con = conexao.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);

                    // Oculta o ID do usuário exibindo apenas a coluna com o Nome:
                    cbx_nomeProfissional.DisplayMember = "Nome_F";       // Exibe APENAS o Nome para o usuário
                    cbx_nomeProfissional.ValueMember = "Funcionario_id"; // O ID fica oculto internamente

                    cbx_nomeProfissional.DataSource = tabela;
                    cbx_nomeProfissional.SelectedIndex = -1;             // Deixa o campo em branco inicialmente
                }
            }
        }
        //Caregar lista de horários no combobox
        private List<TimeSpan> GerarHorariosAtendimento()
        {
            List<TimeSpan> listaHorarios = new List<TimeSpan>();

            // Turno da Manhã: 08:00 às 11:00
            TimeSpan horaInicioManha = new TimeSpan(8, 0, 0);
            TimeSpan horaFimManha = new TimeSpan(11, 0, 0);

            for (TimeSpan h = horaInicioManha; h <= horaFimManha; h = h.Add(TimeSpan.FromMinutes(30)))
            {
                listaHorarios.Add(h);
            }

            // Turno da Tarde: 12:00 às 17:00
            TimeSpan horaInicioTarde = new TimeSpan(12, 0, 0);
            TimeSpan horaFimTarde = new TimeSpan(17, 0, 0);

            for (TimeSpan h = horaInicioTarde; h <= horaFimTarde; h = h.Add(TimeSpan.FromMinutes(30)))
            {
                listaHorarios.Add(h);
            }

            return listaHorarios;
        }
        //Atualizando a lista com os horários disponíveis no combobox

        private void CarregarHorariosDisponiveis()
        {
            // Verifica se há um profissional selecionado e se o ValueMember não é nulo
            if (cbx_nomeProfissional.SelectedValue == null || cbx_nomeProfissional.SelectedIndex == -1)
            {
                cbx_horarios.DataSource = null;
                return;
            }

            int idFuncionario;
            if (!int.TryParse(cbx_nomeProfissional.SelectedValue.ToString(), out idFuncionario))
            {
                return;
            }

            DateTime dataSelecionada = dateTimePicker1.Value.Date;

            // 1. Pega os horários já agendados para este profissional na data selecionada
            List<TimeSpan> horariosOcupados = new List<TimeSpan>();

            string sql = @"SELECT CAST(Data_hora AS TIME) AS Horario 
                  FROM Consultas 
                  WHERE Funcionario_id = @FuncionarioId 
                  AND CAST(Data_hora AS DATE) = @DataConsulta";

            Connection conexao = new Connection();
            using (SqlConnection con = conexao.Conectar())
            {
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@FuncionarioId", SqlDbType.Int).Value = idFuncionario;
                    comando.Parameters.Add("@DataConsulta", SqlDbType.Date).Value = dataSelecionada;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            horariosOcupados.Add((TimeSpan)reader["Horario"]);
                        }
                    }
                }
            }

            // 2. Pega todos os horários possíveis e remove os ocupados
            List<TimeSpan> todosHorarios = GerarHorariosAtendimento();
            List<string> horariosLivresFormatados = new List<string>();

            foreach (TimeSpan h in todosHorarios)
            {
                if (!horariosOcupados.Contains(h))
                {
                    horariosLivresFormatados.Add(h.ToString(@"HH\:mm"));
                }
            }

            // 3. Atualiza o ComboBox de horários
            cbx_horarios.DataSource = horariosLivresFormatados;
            cbx_horarios.SelectedIndex = -1; // Deixa sem escolha inicial
        }
        private void CarregarConsultasPorData(DateTime data)
        {

            //            string sql = @"SELECT
            //    c.Nome_C AS[Nome do Cliente],
            //    f.Nome_F AS[Profissional],
            //    FORMAT(con.Data_hora, 'HH:mm') AS[Horário]
            //FROM Consultas con
            //INNER JOIN Clientes c ON con.Cliente_id = c.Cliente_id
            //INNER JOIN Funcionarios f ON con.Funcionario_id = f.Funcionario_id
            //WHERE CAST(con.Data_hora AS DATE) = @DataConsulta
            //ORDER BY con.Data_hora ASC";

            string sql = @"SELECT 
    con.Consulta_id AS [ID Consulta],
    c.Nome_C AS [Nome do Cliente],
    f.Nome_F AS [Profissional],
    FORMAT(con.Data_hora, 'HH:mm') AS [Horário]
FROM Consultas con
INNER JOIN Clientes c ON con.Cliente_id = c.Cliente_id
INNER JOIN Funcionarios f ON con.Funcionario_id = f.Funcionario_id
WHERE CAST(con.Data_hora AS DATE) = @DataConsulta
ORDER BY con.Data_hora ASC";


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
                    //ocultando o ID da consultando para o usuario porém mantendo o dado para uso interno
                    if (dgv_agenda.Columns["ID Consulta"] != null)
                    {
                        dgv_agenda.Columns["ID Consulta"].Visible = false;
                    }
                }
            }
        }


        //-------------------Fim dos métodos-------------------
        private void Adicionar_cliente_Load(object sender, EventArgs e)
        {
            AtualizarTelaPorData();
            CarregarProfissionais();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTelaPorData();
            CarregarHorariosDisponiveis();

        }

        
            private void cbx_nomeProfissional_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarHorariosDisponiveis();
        }
        

        

        private void mtb_cpf_Enter(object sender, EventArgs e)
        {
           
            this.BeginInvoke((MethodInvoker)delegate
            {
                // Se o CPF ainda não foi totalmente preenchido, move o cursor para o início
                if (!mtb_cpf.MaskCompleted)
                {
                    mtb_cpf.SelectionStart = 0;
                    mtb_cpf.SelectionLength = 0;
                }
            });
        }
    
    }
}
