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
using System.Net.Http;
using System.Text.Json;

namespace Cadastro_Clinico
{
    public partial class Adicionar_cliente : Form
    {
        public Adicionar_cliente()
        {
            InitializeComponent();
            
            mtb_valor.TextChanged += mtb_valor_TextChanged;
            mtb_valor.GotFocus += mtb_valor_GotFocus;
            mtb_valor.KeyPress += mtb_valor_KeyPress;

            // Define o valor inicial como zero formatado
            mtb_valor.Text = "R$ 0,00";
        }

        //------------Métodos-----------

        private void LimparCampos()
        {
            txb_nome.Clear();
            mtb_cpf.Clear();
            txb_email.Clear();
            mtb_dataAtendimento.Clear();
            txb_endereço.Clear();
            txb_complemento.Clear();
            txb_numero.Clear();
            mtb_cep.Clear();
            mtb_valor.Text = "R$ 0,00";
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
                string.IsNullOrWhiteSpace(txb_numero.Text) || // Validação do novo campo obrigatório de número
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
        IF NOT EXISTS (SELECT 1 FROM Clientes WHERE CPF_C = @CPF)
        BEGIN
            INSERT INTO Clientes (Nome_C, Nascimento, CPF_C, Email, Endereco, CEP) 
            VALUES (@Nome, @Nascimento, @CPF, @Email, @Endereco, @CEP);
            SELECT SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            SELECT Cliente_id FROM Clientes WHERE CPF_C = @CPF;
        END";

                    int idCliente = 0;
                    using (SqlCommand cmdCliente = new SqlCommand(sqlCliente, con))
                    {
                        // Concatena a rua/bairro, número e complemento em uma única string
                        string enderecoFormatado = MontarEnderecoCompleto();

                        cmdCliente.Parameters.AddWithValue("@Nome", txb_nome.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@CPF", mtb_cpf.Text);
                        cmdCliente.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Endereco", enderecoFormatado);
                        cmdCliente.Parameters.AddWithValue("@CEP", mtb_cep.Text);
                        cmdCliente.Parameters.AddWithValue("@Nascimento", mtb_data_nascimento.Text);
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

            string sql = "SELECT Nome_C, Email, Endereco, CEP, Nascimento FROM Clientes WHERE CPF_C = @CPF";

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
                                mtb_data_nascimento.Text = Convert.ToDateTime(reader["Nascimento"]).ToString("dd/MM/yyyy"); 
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
    int idConsultaSelecionada = Convert.ToInt32(dgv_agenda.CurrentRow.Cells["ID Consulta"].Value);
    if (idConsultaSelecionada == 0)
    {
        MessageBox.Show("Selecione uma consulta na tabela abaixo para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Validação dos dados do cliente e da consulta
    if (string.IsNullOrWhiteSpace(txb_email.Text) ||
        string.IsNullOrWhiteSpace(txb_endereço.Text) ||
        string.IsNullOrWhiteSpace(txb_numero.Text) ||
        !mtb_cep.MaskCompleted ||
        cbx_nomeProfissional.SelectedIndex == -1 || 
        cbx_horarios.SelectedIndex == -1)
    {
        MessageBox.Show("Preencha todos os campos obrigatórios (E-mail, CEP, Endereço, Número, Profissional e Horário).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        // SQL atualizado para alterar tanto os dados da Consulta quanto os dados do Cliente vinculado
        string sql = @"
            UPDATE Consultas 
            SET Funcionario_id = @FuncionarioId, 
                Data_hora = @DataHora, 
                Valor = @Valor 
            WHERE Consulta_id = @ConsultaId;

            UPDATE Clientes
            SET Email = @Email,
                Endereco = @Endereco,
                CEP = @CEP
            WHERE Cliente_id = (SELECT Cliente_id FROM Consultas WHERE Consulta_id = @ConsultaId);";

        Connection conexao = new Connection();
        using (SqlConnection con = conexao.Conectar())
        {
            using (SqlCommand comando = new SqlCommand(sql, con))
            {
                // Parâmetros da Consulta
                comando.Parameters.AddWithValue("@FuncionarioId", idFuncionario);
                comando.Parameters.AddWithValue("@DataHora", dataHoraFinal);
                comando.Parameters.AddWithValue("@Valor", valorConsulta);
                comando.Parameters.AddWithValue("@ConsultaId", idConsultaSelecionada);

                // Parâmetros do Cliente (com endereço concatenado)
                string enderecoFormatado = MontarEnderecoCompleto();
                comando.Parameters.AddWithValue("@Email", txb_email.Text.Trim());
                comando.Parameters.AddWithValue("@Endereco", enderecoFormatado);
                comando.Parameters.AddWithValue("@CEP", mtb_cep.Text);

                comando.ExecuteNonQuery();
            }
        }

        MessageBox.Show("Consulta e dados do cliente atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (dgv_agenda.CurrentRow == null || dgv_agenda.CurrentRow.Cells["ID Consulta"].Value == DBNull.Value)
            {
                MessageBox.Show("Selecione uma consulta na tabela abaixo para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idConsulta = Convert.ToInt32(dgv_agenda.CurrentRow.Cells["ID Consulta"].Value);

            DialogResult confirmacao = MessageBox.Show("Deseja realmente excluir esta consulta? O cadastro do cliente será mantido.",
                                                       "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private async Task BuscarCepAsync(string cep)
        {
            // Remove caracteres da máscara
            string cepLimpo = System.Text.RegularExpressions.Regex.Replace(cep, @"[^\d]", "");

            if (cepLimpo.Length != 8)
                return;

            string url = $"https://viacep.com.br/ws/{cepLimpo}/json/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var dadosEndereco = JsonSerializer.Deserialize<ViaCepResponse>(json);

                        if (dadosEndereco != null && !dadosEndereco.erro)
                        {
                            // Preenche a rua/bairro/cidade no campo de endereço
                            txb_endereço.Text = $"{dadosEndereco.logradouro}, {dadosEndereco.bairro} - {dadosEndereco.localidade}/{dadosEndereco.uf}";

                            // Move o foco direto para o campo do número
                            txb_numero.Focus();
                        }
                        else
                        {
                            MessageBox.Show("CEP não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar CEP: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MontarEnderecoCompleto()
        {
            string rua = txb_endereço.Text.Trim();
            string numero = txb_numero.Text.Trim();
            string complemento = txb_complemento.Text.Trim();

            if (!string.IsNullOrEmpty(complemento))
            {
                return $"{rua}, Nº {numero} - {complemento}";
            }

            return $"{rua}, Nº {numero}";

        }
        private void CarregarDetalhesConsulta(int consultaId)
        {
            
        {
            string sql = @"
        SELECT 
            c.Consulta_id,
            c.Data_hora,
            c.Valor,
            c.Funcionario_id,
            cli.Cliente_id,
            cli.Nome_C,
            cli.CPF_C,
            cli.Email,
            cli.Endereco,
            cli.CEP,
            cli.Nascimento
        FROM Consultas c
        INNER JOIN Clientes cli ON c.Cliente_id = cli.Cliente_id
        WHERE c.Consulta_id = @ConsultaId";

            try
            {
                Connection conexao = new Connection();
                using (SqlConnection con = conexao.Conectar())
                {
                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.AddWithValue("@ConsultaId", idConsultaSelecionada);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 1. Preenche Dados do Cliente
                                mtb_cpf.Text = reader["CPF_C"].ToString();
                                txb_nome.Text = reader["Nome_C"].ToString();
                                txb_email.Text = reader["Email"].ToString();
                                mtb_cep.Text = reader["CEP"].ToString();

                                // Trata o endereço completo se estiver salvo no formato "Rua, Nº 123 - Complemento"
                                string enderecoBanco = reader["Endereco"].ToString();
                                SepararEnderecoNosCampos(enderecoBanco);

                                if (reader["Nascimento"] != DBNull.Value)
                                {
                                    mtb_data_nascimento.Text = Convert.ToDateTime(reader["Nascimento"]).ToString("dd/MM/yyyy");
                                }

                                // 2. Preenche Dados da Consulta
                                if (reader["Data_hora"] != DBNull.Value)
                                {
                                    DateTime dataHora = Convert.ToDateTime(reader["Data_hora"]);
                                    mtb_dataAtendimento.Text = dataHora.ToString("dd/MM/yyyy");

                                    // Seleciona o horário no ComboBox se exatamento compatível com a string "HH:mm" ou "HH:mm:ss"
                                    string horaFormatada = dataHora.ToString(@"hh\:mm");
                                    cbx_horarios.SelectedItem = horaFormatada;
                                }

                                if (reader["Valor"] != DBNull.Value)
                                {
                                    decimal valor = Convert.ToDecimal(reader["Valor"]);
                                    mtb_valor.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
                                }

                                if (reader["Funcionario_id"] != DBNull.Value)
                                {
                                    cbx_nomeProfissional.SelectedValue = Convert.ToInt32(reader["Funcionario_id"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar detalhes da consulta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
        private void SepararEnderecoNosCampos(string enderecoCompleto)
        {
            txb_endereço.Text = enderecoCompleto;
            txb_numero.Clear();
            txb_complemento.Clear();

            if (string.IsNullOrWhiteSpace(enderecoCompleto))
                return;

            // Procura por ", Nº " para extrair número e complemento
            int indexNumero = enderecoCompleto.LastIndexOf(", Nº ");
            if (indexNumero != -1)
            {
                txb_endereço.Text = enderecoCompleto.Substring(0, indexNumero);
                string resto = enderecoCompleto.Substring(indexNumero + 5); // Pula ", Nº "

                string[] partesResto = resto.Split(new string[] { " - " }, StringSplitOptions.None);
                txb_numero.Text = partesResto[0];

                if (partesResto.Length > 1)
                {
                    txb_complemento.Text = partesResto[1];
                }
            }
        }

        //-------------------Fim dos métodos-------------------

        private int idConsultaSelecionada = 0;
        private void Adicionar_cliente_Load(object sender, EventArgs e)
        {
            AtualizarTelaPorData();
            CarregarProfissionais();
            dgv_agenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_agenda.MultiSelect = false;
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

        private async void mtb_cep_Leave(object sender, EventArgs e)
        {
            if(mtb_cep.MaskCompleted)
            {
                await BuscarCepAsync(mtb_cep.Text);
            }
        }

        private void dgv_agenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
            if (e.RowIndex >= 0 && dgv_agenda.Rows[e.RowIndex].Cells["ID Consulta"].Value != DBNull.Value)
            {
                int idConsulta = Convert.ToInt32(dgv_agenda.Rows[e.RowIndex].Cells["ID Consulta"].Value);

                // Atualiza a variável de controle da classe
                idConsultaSelecionada = idConsulta;

                // Executa a busca e preenche todos os campos na tela
                CarregarDetalhesConsulta(idConsulta);
            }
        
        }

        private void Adicionar_cliente_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtb_valor_TextChanged(object sender, EventArgs e)
        {
            
           // Remove temporariamente o evento para evitar um loop infinito ao alterar o .Text via código
            mtb_valor.TextChanged -= mtb_valor_TextChanged;

            // Extrai apenas os dígitos numéricos digitados
            string apenasNumeros = System.Text.RegularExpressions.Regex.Replace(mtb_valor.Text, @"[^\d]", "");

            if (string.IsNullOrEmpty(apenasNumeros))
            {
                apenasNumeros = "0";
            }

            // Converte para decimal considerando os 2 últimos dígitos como centavos (divisão por 100)
            decimal valorDecimal = Convert.ToDecimal(apenasNumeros) / 100;

            // Aplica a formatação oficial de moeda do Brasil (R$ 0,00 -> R$ 1,00 -> R$ 10,00 -> R$ 100,00)
            mtb_valor.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valorDecimal);

            // Garante que o cursor de digitação fique sempre ao final do texto
            mtb_valor.SelectionStart = mtb_valor.Text.Length;

            // Reativa o evento
            mtb_valor.TextChanged += mtb_valor_TextChanged;
        }

        private void mtb_valor_GotFocus(object sender, EventArgs e)
        {
            // Ao clicar ou dar TAB para entrar no campo, manda o cursor para o final
            mtb_valor.SelectionStart = mtb_valor.Text.Length;
        }

        private void mtb_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Impede a digitação de letras, pontos, vírgulas ou símbolos (aceita apenas números e Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    
    }
    public class ViaCepResponse
    {
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public bool erro { get; set; }
    }

}
