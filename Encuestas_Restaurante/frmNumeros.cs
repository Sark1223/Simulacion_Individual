using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        frmPruebas pruebas = new frmPruebas();

        public bool numerosGenerados = false;

        //Arreglo para guardar numeros
        public float[] Ri = new float[1050];

        private void frmNumeros_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Los valores que se muestran en la pantalla son los que se recomiendan para el ejercicio, pero pueden ser modificados", "ATENCION");
            rb5.Checked = true;
        }

        public void ObtenerObjetoPruebas(frmPruebas pruebas)
        {
            this.pruebas = pruebas;
        }

        private bool ValoresVacios()
        {
            string valoresVacios = "";
            int no_vacios = 0;
            //VERIFICACION DE VALORES VACIOS
            {
                //Informacion personal
                if (txtSemilla.Text == "")
                {
                    valoresVacios += "Semilla, ";
                    no_vacios++;
                }
                if (txtA.Text == "")
                {
                    valoresVacios += "a,";
                    no_vacios++;
                }
                if (txtC.Text == "")
                {
                    valoresVacios += "c,";
                    no_vacios++;
                }
                if (txtM.Text == "")
                {
                    valoresVacios += "m,";
                    no_vacios++;
                }

            }
            if (no_vacios > 0)
            {
                MessageBox.Show("No puede dejar información en blanco \r\n\r\n" +
                                "No. de valores vacios: " + no_vacios + "\r\n" +
                                "Valores vacios: " + valoresVacios, "ERROR AL INGRESAR VALORES");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GenerarObjeto()
        {
            if (!ValoresVacios())
            {
                g = new Semilla();
                g.X0 = float.Parse(txtSemilla.Text);
                g.a = float.Parse(txtA.Text);
                g.c = float.Parse(txtC.Text);
                g.m = float.Parse(txtM.Text);
            }
            
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            no_pruebas = 0;
            //numeros.tablaResultados.Clear();
            tblPseudo.Rows.Clear();
            //numeros.tblPseudo.ClearSelection();
            lista.Clear();
            numerosGenerados = false;

            if (rb10.Checked == true)
            {
                Za = 1.645F;
                Z2 = 6.2514F;
            }
            else if (rb5.Checked == true)
            {
                Za = 1.96F;
                Z2 = 7.8147F;
            }


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

            if (numerosGenerados)
            {
                Realizar_PruebaPromedios();
                Realizar_PruebaFrecuencia();

                if(no_pruebas == 2)
                {
                    MessageBox.Show("No. pruebas superadas: 2 \r\nLos números generados se encuentran distribuidos uniformemente.","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else if(no_pruebas == 1)
                {
                    MessageBox.Show("No. pruebas superadas: 1 \r\nLos números generados no estan distribuidos uniformemente, " +
                        "pueden generar resultados no confiables.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("No. pruebas superadas: 0 \r\nNo se recomienda utilizar estos números para realizar los experimentos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //PRUEBAS ---------------------------------------------------------------------------
        public void Realizar_PruebaPromedios()
        {
            float promedio = 0;
            double Zo;

            for (int i = 0; i < lista.Count; i++)
            {
                promedio += lista[i].Ri;
            }

            //Primera formula
            pruebas.lblRi.Text = promedio.ToString();
            pruebas.lbln.Text = lista.Count.ToString();
            pruebas.lbln.Location = new Point((pruebas.lblRi.Right - pruebas.lblRi.Width / 2) - (pruebas.lbln.Width / 2), 75);
            pruebas.pnFormula.Size = new Size(pruebas.lblRi.Width, 1);

            promedio = (promedio / lista.Count);

            pruebas.lblResPromedio.Text = " = " + promedio.ToString();
            pruebas.lblResPromedio.Location = new Point(pruebas.lblRi.Location.X + pruebas.lblRi.Width, 66);

            //Segunda formula
            pruebas.lblZoSuperior.Text = $"({promedio} - 0.50) · √({lista.Count})";
            pruebas.pnZo.Size = new Size(pruebas.lblZoSuperior.Width, 1);
            pruebas.lblZoInferior.Location = new Point((pruebas.lblZoSuperior.Right - pruebas.lblZoSuperior.Width / 2) - (pruebas.lblZoInferior.Width / 2), 133);

            Zo = (((promedio - 0.50F) * Math.Sqrt(lista.Count)) / Math.Sqrt(1F / 12F));

            if (Zo < 0) { Zo *= -1; }

            pruebas.lblZoRes1.Text = $"= {Zo:N5}";
            pruebas.lblZoRes1.Location = new Point(pruebas.lblZoSuperior.Location.X + pruebas.lblZoSuperior.Width, 121);


            if (Zo <= Za)
            {
                pruebas.lblSigPromedios.Text = $"Significancia\r\nZa = {Za}";
                //opciones.txtMesajeDatos.Text = "Los numeros que se generaron se encuentran distribuidos uniformemente.";
                no_pruebas++;
                pruebas.lblResProme.Text = "La prueba a sido acreditada";
            }
            else
            {
                //opciones.txtMesajeDatos.Text = "Los numeros que se generaron pueden generar resultados ambiguos.";
                pruebas.lblResProme.Text = "Los números pseudo-aleaorios han fracasado la prueba";
            }

            pruebas.lblResProme.Location = new Point((pruebas.Width / 2) - pruebas.lblResProme.Width / 2, 164);
        }

        float Za, Z2;
        int no_pruebas;
        public void Realizar_PruebaFrecuencia()
        {
            int N1 = 0, N2 = 0, N3 = 0, N4 = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Ri >= 0 && lista[i].Ri < 0.25)
                {
                    N1++;

                }
                else if (lista[i].Ri >= 0.25 && lista[i].Ri < 0.50)
                {
                    N2++;
                }
                else if (lista[i].Ri >= 0.50 && lista[i].Ri < 0.75)
                {
                    N3++;
                }
                else if (lista[i].Ri >= 0.75 && lista[i].Ri <= 1.00)
                {
                    N4++;
                }
            }

            //VALORES DE TABLA
            pruebas.txtFO1.Text = N1.ToString();
            pruebas.txtFO2.Text = N2.ToString();
            pruebas.txtFO3.Text = N3.ToString();
            pruebas.txtFO4.Text = N4.ToString();

            float FE = lista.Count / 4F;

            pruebas.txtFE1.Text = FE.ToString();
            pruebas.txtFE2.Text = FE.ToString();
            pruebas.txtFE3.Text = FE.ToString();
            pruebas.txtFE4.Text = FE.ToString();

            //DATOS DE PRUEBA
            pruebas.lblNo_valores.Text = lista.Count.ToString();
            pruebas.lblNo_grupos.Text = "n = 4";

            pruebas.lblNo_valores.Text = "N = " + lista.Count.ToString();
            pruebas.pnformulaFe.Size = new Size(pruebas.lblNformula.Width, 1);
            pruebas.lblgruposFormula.Location = new Point((pruebas.lblNformula.Right - pruebas.lblNformula.Width / 2) - (pruebas.lblgruposFormula.Width / 2), 360);

            double Xo = (Math.Pow(N1 - FE, 2) / FE) + (Math.Pow(N2 - FE, 2) / FE) +
                (Math.Pow(N3 - FE, 2) / FE) + (Math.Pow(N4 - FE, 2) / FE);

            pruebas.lblZoRes2.Text = $"= {Xo:N5}";

            if (Xo <= Z2)
            {
                pruebas.lblSigFrecuencia.Text = $"Significancia\r\nZa = {Z2}";
                //opciones.txtMesajeDatos.Text = "Los numeros que se generaron se encuentran distribuidos uniformemente.";
                no_pruebas++;
                pruebas.lblResFrecuencia.Text = "La prueba a sido acreditada";
            }
            else
            {
                //opciones.txtMesajeDatos.Text = "Los numeros que se generaron pueden generar resultados ambiguos.";
                pruebas.lblResFrecuencia.Text = "Los números pseudo-aleaorios han fracasado la prueba";
            }

            pruebas.lblResFrecuencia.Location = new Point((pruebas.Width / 2) - pruebas.lblResFrecuencia.Width / 2, 545);
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
