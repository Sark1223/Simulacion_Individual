using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestas_Restaurante
{
    public partial class frmProblema : Form
    {
        public frmProblema()
        {
            InitializeComponent();
        }

        frmHistorial historial = new frmHistorial();
        frmPruebas pruebas = new frmPruebas();
        frmNumeros numeros = new frmNumeros();

        bool numerosGenerados = false;
        private void cmdGenerarNumeros_Click(object sender, EventArgs e)
        {
            if(numeros.ShowDialog() == DialogResult.OK)
            {
                cmdSimularEncuestas.Tag = "Habilitar";
                numerosGenerados = true;
            }
        }

        private void frmProblema_Load(object sender, EventArgs e)
        {
            cmdSimularEncuestas.Tag = "Inabilitar";
        }

        private void cmdSimularEncuestas_Click(object sender, EventArgs e)
        {
            if(cmdSimularEncuestas.Tag.ToString() == "Inabilitar")
            {
                MessageBox.Show("Primero debe de generar los numeros pseudo-aleatorios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //Resolver Problema
            }
        }

        private void cmdVerPruebas_Click(object sender, EventArgs e)
        {
            if (!numerosGenerados)
            {
                MessageBox.Show("Primero debe de generar los numeros pseudo-aleatorios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //Mostrar Pruebas
                pruebas.ShowDialog();
            }
        }

        private void cmdHistorial_Click(object sender, EventArgs e)
        {
            historial.ShowDialog();
        }
    }
}
