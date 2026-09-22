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

        private void LimparCampos()
        {
            txb_nome.Clear();
            mtb_cpf.Clear();
            txb_email.Clear();
            txb_endereço.Clear();
            mtb_cep.Clear();
            mtb_valor.Clear();
            cbx_nomeProfissional.SelectedIndex = -1;
            cbx_horarios.DataSource = null;
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
                    cbx_nomeProfissional.DisplayMember = "Nome_F";       
                    cbx_nomeProfissional.ValueMember = "Funcionario_id"; 

                    cbx_nomeProfissional.DataSource = tabela;
                    cbx_nomeProfissional.SelectedIndex = -1;             
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

            // Turno da Tarde: 12:00 às 16:30
            TimeSpan horaInicioTarde = new TimeSpan(12, 0, 0);
            TimeSpan horaFimTarde = new TimeSpan(16, 30, 0);

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
            if ( cbx_nomeProfissional.SelectedIndex == -1 ||
                 cbx_nomeProfissional.SelectedValue == null)
            {
                cbx_horarios.DataSource = null;
                return;
            }

            DataRowView dvr = cbx_nomeProfissional.SelectedItem as DataRowView;
            if(dvr == null)
            {
                cbx_horarios.DataSource = null;
                return;
            }


            int idFuncionario = Convert.ToInt32(dvr["Funcionario_id"]);
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
                    horariosLivresFormatados.Add(h.ToString(@"hh\:mm"));
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

                    // Exibe o resultado no DataGridView 
                    dgv_agenda.DataSource = tabela;
                    //ocultando o ID da consultando para o usuario porém mantendo o dado para uso interno
                    if (dgv_agenda.Columns["ID Consulta"] != null)
                    {
                        dgv_agenda.Columns["ID Consulta"].Visible = false;
                    }
                }
            }
        }

        private void SalvarCliente()
        {
          
         // 1. Validação de campos simples e de máscaras completas
            if (string.IsNullOrWhiteSpace(txb_nome.Text) ||
                string.IsNullOrWhiteSpace(txb_email.Text) ||
                string.IsNullOrWhiteSpace(txb_endereço.Text) ||
                string.IsNullOrWhiteSpace(mtb_valor.Text) ||
                !mtb_cpf.MaskCompleted ||
                !mtb_dataAtendimento.MaskCompleted ||
                !mtb_cep.MaskCompleted ||
                cbx_nomeProfissional.SelectedIndex == -1 ||
                cbx_horarios.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios e selecione o Profissional e o Horário.",
                                "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Montagem da Data + Hora para a Consulta
            DateTime dataAtendimento;
            if (!DateTime.TryParseExact(mtb_dataAtendimento.Text, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dataAtendimento))
            {
                MessageBox.Show("Data de atendimento inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan horaSelecionada = TimeSpan.Parse(cbx_horarios.SelectedItem.ToString());
            DateTime dataHoraFinal = dataAtendimento.Date.Add(horaSelecionada);

            // 3. Conversão do Valor para decimal
            decimal valorConsulta;
            if (!decimal.TryParse(mtb_valor.Text.Replace("R$", "").Trim(), out valorConsulta))
            {
                MessageBox.Show("Informe um valor válido para a consulta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFuncionario = Convert.ToInt32(cbx_nomeProfissional.SelectedValue);

            try
            {
                Connection conexao = new Connection();
                using (SqlConnection con = conexao.Conectar())
                {
                    // A. Verifica se o Cliente já existe pelo CPF; se não existir, insere e retorna o Cliente_id
                    string sqlCliente = @"
                IF NOT EXISTS (SELECT 1 FROM Clientes WHERE CPF = @CPF)
                BEGIN
                    INSERT INTO Clientes (Nome_C, CPF, Email, Endereco, CEP) 
                    VALUES (@Nome, @CPF, @Email, @Endereco, @CEP);
                    SELECT SCOPE_IDENTITY();
                END
                ELSE
                BEGIN
                    SELECT Cliente_id FROM Clientes WHERE CPF = @CPF;
                END";

                    int idCliente = 0;
                    using (SqlCommand cmdCliente = new SqlCommand(sqlCliente, con))
                    {
                        cmdCliente.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@CPF", mtb_cpf.Text);
                        cmdCliente.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Endereco", txb_endereço.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@CEP", mtb_cep.Text);

                        object resultado = cmdCliente.ExecuteScalar();
                        idCliente = Convert.ToInt32(resultado);
                    }

                    // B. Cadastra a Consulta
                    string sqlConsulta = @"
                INSERT INTO Consultas (Cliente_id, Funcionario_id, Data_hora, Valor)
                VALUES (@ClienteId, @FuncionarioId, @DataHora, @Valor)";

                    using (SqlCommand cmdConsulta = new SqlCommand(sqlConsulta, con))
                    {
                        cmdConsulta.Parameters.AddWithValue("@ClienteId", idCliente);
                        cmdConsulta.Parameters.AddWithValue("@FuncionarioId", idFuncionario);
                        cmdConsulta.Parameters.AddWithValue("@DataHora", dataHoraFinal);
                        cmdConsulta.Parameters.AddWithValue("@Valor", valorConsulta);

                        cmdConsulta.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Agendamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Limpeza e Atualização dos dados na tela
                LimparCampos();
                AtualizarTelaPorData();
                CarregarHorariosDisponiveis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar agendamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void PesquisarClientePorCPF()
        {
            if (!mtb_cpf.MaskCompleted)
            {
                MessageBox.Show("Por favor, digite um CPF completo para realizar a pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtb_cpf.Focus();
                return;
            }

            string sql = "SELECT Nome_C, Email, Endereco, CEP FROM Clientes WHERE CPF = @CPF";

            try
            {
                Connection conexao = new Connection();
                using (SqlConnection con = conexao.Conectar())
                {
                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.AddWithValue("@CPF", mtb_cpf.Text);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txb_nome.Text = reader["Nome_C"].ToString();
                                txb_email.Text = reader["Email"].ToString();
                                txb_endereço.Text = reader["Endereco"].ToString();
                                mtb_cep.Text = reader["CEP"].ToString();

                                MessageBox.Show("Cliente encontrado! Os dados foram preenchidos.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Nenhum cliente foi encontrado com o CPF informado.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarConsulta()
        {
            if (idConsultaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma consulta na tabela abaixo para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbx_nomeProfissional.SelectedIndex == -1 || cbx_horarios.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o profissional e o novo horário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dataAtendimento;
            if (!DateTime.TryParseExact(mtb_dataAtendimento.Text, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dataAtendimento))
            {
                MessageBox.Show("Data de atendimento inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan horaSelecionada = TimeSpan.Parse(cbx_horarios.SelectedItem.ToString());
            DateTime dataHoraFinal = dataAtendimento.Date.Add(horaSelecionada);

            decimal valorConsulta;
            if (!decimal.TryParse(mtb_valor.Text.Replace("R$", "").Trim(), out valorConsulta))
            {
                MessageBox.Show("Informe um valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFuncionario = Convert.ToInt32(cbx_nomeProfissional.SelectedValue);

            try
            {
                string sql = @"UPDATE Consultas 
                       SET Funcionario_id = @FuncionarioId, 
                           Data_hora = @DataHora, 
                           Valor = @Valor 
                       WHERE Consulta_id = @ConsultaId";

                Connection conexao = new Connection();
                using (SqlConnection con = conexao.Conectar())
                {
                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.AddWithValue("@FuncionarioId", idFuncionario);
                        comando.Parameters.AddWithValue("@DataHora", dataHoraFinal);
                        comando.Parameters.AddWithValue("@Valor", valorConsulta);
                        comando.Parameters.AddWithValue("@ConsultaId", idConsultaSelecionada);

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Consulta atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                idConsultaSelecionada = 0;
                AtualizarTelaPorData();
                CarregarHorariosDisponiveis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExcluirConsulta()
        {
            if (dgv_agenda.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma consulta na tabela para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idConsulta = Convert.ToInt32(dgv_agenda.CurrentRow.Cells["ID Consulta"].Value);

            DialogResult confirmacao = MessageBox.Show("Deseja realmente excluir esta consulta? O cadastro do cliente será mantido.",
                                                       "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM Consultas WHERE Consulta_id = @ConsultaId";

                    Connection conexao = new Connection();
                    using (SqlConnection con = conexao.Conectar())
                    {
                        using (SqlCommand comando = new SqlCommand(sql, con))
                        {
                            comando.Parameters.AddWithValue("@ConsultaId", idConsulta);
                            comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Consulta excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    idConsultaSelecionada = 0;
                    AtualizarTelaPorData();
                    CarregarHorariosDisponiveis();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //-------------------Fim dos métodos-------------------

        private int idConsultaSelecionada = 0;
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

        private void cbx_nomeProfissional_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarHorariosDisponiveis();
        }

        private void btn_deslogar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 telalogin = new Form1();
            telalogin.Show();
            telalogin.Focus();
        }
        // Evento Leave do MaskedTextBox para validar a data digitada
        private void mtb_dataAtendimento_Leave(object sender, EventArgs e)
        {
            
            if (mtb_dataAtendimento.MaskCompleted)
            {
                DateTime dataDigitada;

                
                if (DateTime.TryParseExact(mtb_dataAtendimento.Text, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out dataDigitada))
                {
                    
                    if (dateTimePicker1.Value.Date != dataDigitada.Date)
                    {
                        
                        dateTimePicker1.Value = dataDigitada;
                    }
                }
                else
                {
                    MessageBox.Show("Data inválida. Por favor, digite uma data válida no formato DD/MM/AAAA.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mtb_dataAtendimento.Focus();
                }
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            SalvarCliente();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            PesquisarClientePorCPF();
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            AtualizarConsulta();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            ExcluirConsulta();
        }
    }
}
