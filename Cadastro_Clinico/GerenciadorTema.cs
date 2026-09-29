using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Clinico
{
    public static class GerenciadorTema
    {
        // Evento disparado quando o tema muda
        public static event Action OnTemaAlterado;

        // Propriedade para controlar se o tema escuro está ativo
        public static bool IsTemaEscuro { get; private set; } = false;

        // Alterna o tema e notifica as telas
        public static void AlternarTema()
        {
            IsTemaEscuro = !IsTemaEscuro;
            OnTemaAlterado?.Invoke(); // Notifica todas as telas inscritas
        }

        // Método auxiliar para aplicar as cores em qualquer Form
        public static void AplicarTema(Form form)
        {
            if (IsTemaEscuro)
            {
                // Cores do Tema Escuro
                form.BackColor = Color.FromArgb(45, 45, 48);
                form.ForeColor = Color.White;
                AplicarCoresControles(form.Controls, Color.FromArgb(30, 30, 30), Color.White);
            }
            else
            {
                // Cores do Tema Claro
                form.BackColor = SystemColors.Control;
                form.ForeColor = Color.Black;
                AplicarCoresControles(form.Controls, Color.White, Color.Black);
            }
        }

        // Aplica as cores de forma recursiva em todos os controles do formulário
        private static void AplicarCoresControles(Control.ControlCollection controles, Color backColor, Color foreColor)
        {
            foreach (Control c in controles)
            {
                if (c is Panel || c is GroupBox || c is TabControl)
                {
                    c.BackColor = backColor;
                    c.ForeColor = foreColor;
                    AplicarCoresControles(c.Controls, backColor, foreColor); // Recursivo
                }
                else if (c is TextBox || c is MaskedTextBox || c is ComboBox || c is ListBox)
                {
                    c.BackColor = IsTemaEscuro ? Color.FromArgb(60, 60, 60) : Color.White;
                    c.ForeColor = foreColor;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = IsTemaEscuro ? Color.FromArgb(45, 45, 48) : Color.White;
                    dgv.DefaultCellStyle.BackColor = IsTemaEscuro ? Color.FromArgb(60, 60, 60) : Color.White;
                    dgv.DefaultCellStyle.ForeColor = foreColor;
                }
                else if (c is Label || c is CheckBox || c is RadioButton)
                {
                    c.ForeColor = foreColor;
                }
            }
        }
    }
}