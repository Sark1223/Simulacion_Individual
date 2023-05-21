using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestas_Restaurante
{
    public partial class frmNumeros : Form
    {
        public frmNumeros()
        {
            InitializeComponent();
        }
        ///Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Mover(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Clase semilla 
        Semilla g;
        List<Semilla> lista  = new List<Semilla>();

        public bool numerosGenerados = false;

        //Arreglo para guardar numeros
        public float[] Ri = new float[1050];

        public void GenerarObjeto()
        {
            g = new Semilla();
            g.X0 = float.Parse(txtSemilla.Text);
            g.a = float.Parse(txtA.Text);
            g.c = float.Parse(txtC.Text);
            g.m = float.Parse(txtM.Text);
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            //numeros.tablaResultados.Clear();
            tblPseudo.Rows.Clear();
            //numeros.tblPseudo.ClearSelection();
            lista.Clear();
            numerosGenerados = false;

            GenerarObjeto();
            

            //valor semilla de la que se basaran nuestros numeros
            float x0 = g.X0;
            int n = 0;

            for (int i = 0; i < 1050; i++)
            {
                //si es el primero numero generado entonces 
                if (i == 0)
                {
                    //contador inicia en 1
                    g.N = i + 1;
                    //se recibe nuestra semilla
                    g.Xn = g.X0;
                    //formula de nuestro metodo congruencial mixto
                    g.Res = (g.a * g.Xn) + g.c;
                    //obtenemos el modulo del resultado anterior
                    g.modulo = g.Res % g.m;
                    //lo dividimos entre nuestra constante m y le restamos 1 al resultado
                    g.Ri = g.modulo / g.m;

                    lista.Add(g);

                    //Agrega valores a las filas de la tabla
                    n = tblPseudo.Rows.Add();
                    tblPseudo.Rows[n].Cells[0].Value = n + 1;
                    tblPseudo.Rows[n].Cells[1].Value = lista[n].Ri;

                    Ri[i] = g.Ri;
                }
                else
                {
                    GenerarObjeto();
                    //contador inicia en 1
                    g.N = i + 1;
                    //se recibe nuestra semilla
                    g.Xn = lista[i - 1].modulo;
                    //formula de nuestro metodo congruencial mixto
                    g.Res = (g.a * g.Xn) + g.c;
                    //obtenemos el modulo del resultado anterior
                    g.modulo = g.Res % g.m;
                    //lo dividimos entre nuestra constante m y le restamos 1 al resultado
                    g.Ri = g.modulo / g.m;

                    lista.Add(g);

                    //Agrega valores a las filas de la tabla
                    n = tblPseudo.Rows.Add();
                    tblPseudo.Rows[n].Cells[0].Value = n + 1;
                    tblPseudo.Rows[n].Cells[1].Value = lista[n].Ri;

                    Ri[i] = g.Ri;
                }
            }

            numerosGenerados = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
