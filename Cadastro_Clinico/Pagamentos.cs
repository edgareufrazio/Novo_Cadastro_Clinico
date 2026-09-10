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
    public partial class Pagamentos : Form
    {
        public Pagamentos()
        {
            InitializeComponent();
        }

        private void Pagamentos_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            conn.Conectar();
            string query = "SELECT Nome_c as Nome, SUM(Valor) as Total FROM Consultas as co, Clientes as cl WHERE co.Cliente_Id = cl.Cliente_Id GROUP BY Nome_c";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid_pagamentos.DataSource = dt;
        }

        private void bt_pesquisar_Click(object sender, EventArgs e)
        {
            grid_pagamentos.DataSource = null;
            grid_pagamentos.Rows.Clear();
            Connection conn = new Connection();
            conn.Conectar();
            string nome;
            decimal valor;


            try
            {
                nome = tb_nome.Text;


                string query = "SELECT Nome_c as Nome, SUM(Valor) as Total FROM Consultas as co, Clientes as cl WHERE cl.Nome_c = @nome GROUP BY Nome_c";
                SqlCommand cmd = new SqlCommand(query, conn.Conectar());

                cmd.Parameters.AddWithValue("@nome", nome);
                

                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                grid_pagamentos.DataSource = dt;

                cmd.Parameters.AddWithValue("@valor",tb_divida.Text);
               using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        valor = reader.GetDecimal(1);
                        tb_divida.Text = valor.ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                
            }
        }

        private void bt_exibir_Click(object sender, EventArgs e)
        {
            grid_pagamentos.DataSource = null;
            grid_pagamentos.Rows.Clear();
            Connection conn = new Connection();
            conn.Conectar();
            string query = "SELECT Nome_c as Nome, SUM(Valor) as Total FROM Consultas as co, Clientes as cl WHERE co.Cliente_Id = cl.Cliente_Id GROUP BY Nome_c";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid_pagamentos.DataSource = dt;
        }

        private void tb_divida_TextChanged(object sender, EventArgs e)
        {
           
            
            
        }
    }
}
