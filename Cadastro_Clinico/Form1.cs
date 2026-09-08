using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
