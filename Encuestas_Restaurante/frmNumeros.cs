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
                Realizar_PruebaPoker();
                ImprimirPoker();
                if (no_pruebas == 3)
                {
                    MessageBox.Show("No. pruebas superadas: 3/3 \r\nLos números generados se encuentran distribuidos uniformemente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (no_pruebas == 2)
                {
                    MessageBox.Show("No. pruebas superadas: 2/3 \r\nLos números generados no son del todo confiables para realizar los experimentos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (no_pruebas == 1)
                {
                    MessageBox.Show("No. pruebas superadas: 1/3 \r\nLos números generados no estan distribuidos uniformemente, " +
                        "pueden generar resultados no confiables.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("No. pruebas superadas: 0/3 \r\nNo se recomienda utilizar estos números para realizar los experimentos.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        string[] res = new string[1050];
        int AD, AE, OP, TE, FE;
        int TodosDiferentes = 0, UnPar = 0, DosPares = 0, TresIguales = 0
        , TresPar = 0, CuatroIguales = 0, TodosIguales = 0;

        public void Realizar_PruebaPoker()
        {
            TodosDiferentes = 0; UnPar = 0; DosPares = 0; TresIguales = 0; TresPar = 0; CuatroIguales = 0; TodosIguales = 0;
            AD = 0; AE = 0; OP = 0; TE = 0; FE = 0;
            int m = 0;
            //Ciclo para recorrer numeros aleatorios
            for (int numActual = 0; numActual < Ri.Length; numActual++)
            {
                int poss = 0;
                string num = Ri[numActual].ToString("N5");

                //Esto divide las palabras con el split recorriendo carácter por carácter
                num.Split(new char[] { ' ' });

                //Areglo de caracteres
                char[] n = new char[7];

                //Este bucle recorrera el string que contiene el numero
                foreach (char caracter in num)
                {
                    n[poss] = caracter;
                    poss++;
                }

                //Indicadores de si el numero ya fue analizado o no
                bool uno = false, dos = false, tres = false, cuatro = false;
                //Ciclo para recorrer Arreglo del numero separado en caracteres
                for (int i = 2; i < n.Length; i++)
                {
                    int Cont = 0;

                    if (i == 2)
                    {
                        if (n[i] == n[3] && uno == false)
                        {
                            Cont++;
                            uno = true;
                        }
                        if (n[i] == n[4] && dos == false)
                        {
                            Cont++;
                            dos = true;
                        }
                        if (n[i] == n[5] && tres == false)
                        {
                            Cont++;
                            tres = true;
                        }
                        if (n[i] == n[6] && cuatro == false)
                        {
                            Cont++;
                            cuatro = true;
                        }
                    }
                    if (i == 3)
                    {
                        if (n[i] == n[4] && dos == false)
                        {
                            Cont++;
                            dos = true;
                        }
                        if (n[i] == n[5] && tres == false)
                        {
                            Cont++;
                            tres = true;
                        }
                        if (n[i] == n[6] && cuatro == false)
                        {
                            Cont++;
                            cuatro = true;
                        }
                    }
                    if (i == 4)
                    {
                        if (n[i] == n[5] && tres == false)
                        {
                            Cont++;
                            tres = true;
                        }
                        if (n[i] == n[6] && cuatro == false)
                        {
                            Cont++;
                            cuatro = true;
                        }
                    }
                    if (i == 5)
                    {
                        if (n[i] == n[6] && cuatro == false)
                        {
                            Cont++;
                            cuatro = true;
                        }
                    }
                    if (Cont == 0)
                    {
                        AD++;
                    }
                    if (Cont == 1)
                    {
                        //un par
                        OP++;
                    }
                    if (Cont == 2)
                    {
                        //una tercia
                        TE++;
                    }
                    if (Cont == 3)
                    {
                        FE++;
                    }
                    if (Cont == 4)
                    {
                        //Todos iguales
                        res[numActual] = " Todos iguales"; //AE
                        AE++;
                        TodosIguales++;
                        break;
                    }
                }
                //m = tblPseudo.Rows.Add();
                
                if (AD == 5)
                {
                    res[numActual] = " Todos Diferentes";
                    TodosDiferentes++;
                }
                if (OP == 1 && TE == 0)
                {
                    res[numActual] = " Un Par";
                    UnPar++;
                }
                if (OP == 2)
                {
                    res[numActual] = " Dos Pares";
                    DosPares++;
                }
                if (OP == 1 && TE == 1)
                {
                    res[numActual] = " Tres Iguales y Un Par";
                    TresPar++;
                }
                if (TE == 1 && OP == 0)
                {
                    res[numActual] = " Tres Iguales";
                    TresIguales++;
                }
                if (FE >= 1)
                {
                    res[numActual] = " Cuatro iguales"; //FE
                    CuatroIguales++;
                }

                AD = 0;
                OP = 0;
                TE = 0;
                FE = 0;
                AE = 0;
                m++;
            }
        }

        public void ImprimirPoker()
        {
            float[] FE = new float[7];
            int[] FO = new int[7];
            double[] Xi = new double[7];
            float result = 0;
            double[] Pevetno = { 0.30240, 0.50400, 0.10800, 0.07200, 0.00900, 0.00450, 0.00010 };


            FO[0] = TodosDiferentes;
            FE[0] = 0.30240F * 1050F;
            result = FO[0] - FE[0];
            Xi[0] = (Math.Pow(result, 2) / FE[0]);
            pruebas.txtTDfo.Text = "" + FO[0];
            pruebas.txtTDpe.Text = "" + Pevetno[0];
            pruebas.txtTDfe.Text = "" + FE[0];
            pruebas.txtXi1.Text = "" + Xi[0].ToString("N5");

            FO[1] = UnPar;
            FE[1] = 0.50400F * 1050F;
            result = FO[1] - FE[1];
            Xi[1] = (Math.Pow(result, 2) / FE[1]);
            pruebas.txtUPfo.Text = "" + FO[1];
            pruebas.txtUPpe.Text = "" + Pevetno[1];
            pruebas.txtUPfe.Text = "" + FE[1];
            pruebas.txtXi2.Text = "" + Xi[1].ToString("N5");

            FO[2] = DosPares;
            FE[2] = 0.10800F * 1050F;
            result = FO[2] - FE[2];
            Xi[2] = (Math.Pow(result, 2) / FE[2]);
            pruebas.txtDPfo.Text = "" + FO[2];
            pruebas.txtDPpe.Text = "" + Pevetno[2];
            pruebas.txtDPfe.Text = "" + FE[2];
            pruebas.txtXi3.Text = "" + Xi[2].ToString("N5");

            FO[3] = TresIguales;
            FE[3] = 0.07200F * 1050F;
            result = FO[3] - FE[3];
            Xi[3] = (Math.Pow(result, 2) / FE[3]);
            pruebas.txtTIfo.Text = "" + FO[3];
            pruebas.txtTIpe.Text = "" + Pevetno[3];
            pruebas.txtTIfe.Text = "" + FE[3];
            pruebas.txtXi4.Text = "" + Xi[3].ToString("N5");

            FO[4] = TresPar;
            FE[4] = 0.00900F * 1050F;
            result = FO[4] - FE[4];
            Xi[4] = (Math.Pow(result, 2) / FE[4]);
            pruebas.txtTIPfo.Text = "" + FO[4];
            pruebas.txtTIPpe.Text = "" + Pevetno[4];
            pruebas.txtTIPfe.Text = "" + FE[4];
            pruebas.txtXi5.Text = "" + Xi[4].ToString("N5");

            FO[5] = CuatroIguales;
            FE[5] = 0.00450F * 1050F;
            result = FO[5] - FE[5];
            Xi[5] = (Math.Pow(result, 2) / FE[5]);
            pruebas.txtCIfo.Text = "" + FO[5];
            pruebas.txtCIpe.Text = "" + Pevetno[5];
            pruebas.txtCIfe.Text = "" + FE[5];
            pruebas.txtXi6.Text = "" + Xi[5].ToString("N5");

            FO[6] = TodosIguales;
            FE[6] = 0.00010F * 1050F;
            result = FO[6] - FE[6];
            Xi[6] = (Math.Pow(result, 2) / FE[6]);
            pruebas.txtTDIfo.Text = "" + FO[6];
            pruebas.txtTDIpe.Text = "" + Pevetno[6];
            pruebas.txtTDIfe.Text = "" + FE[6];
            pruebas.txtXi7.Text = "" + Xi[6].ToString("N5");

            pruebas.lblResultFo.Text = "" + (FO[6] + FO[5] + FO[4] + FO[3] + FO[2] + FO[1] + FO[0]);
            pruebas.lblresultPe.Text = "" + (Pevetno[6] + Pevetno[5] + Pevetno[4] + Pevetno[3] + Pevetno[2] + Pevetno[1] + Pevetno[0]);
            pruebas.lblResultFe.Text = "" + (FE[6] + FE[5] + FE[4] + FE[3] + FE[2] + FE[1] + FE[0]);
            pruebas.lblResultXi.Text = "" + (Xi[6] + Xi[5] + Xi[4] + Xi[3] + Xi[2] + Xi[1] + Xi[0]).ToString("N5");

            if (rb10.Checked == true)
            {
                pruebas.lblSigPok.Text = "" + 10.6446F;
            }
            else if (rb5.Checked == true)
            {
                pruebas.lblSigPok.Text = "" + 12.5916F;
            }

            float Zo = float.Parse(pruebas.lblResultXi.Text);
            float Za = float.Parse(pruebas.lblSigPok.Text);
            if (Zo <= Za)
            {
                pruebas.lblResPoker.Text = "La prueba ha sido acreditada";
                no_pruebas++;
            }
            else
            {
                pruebas.lblResPoker.Text = "La prueba NO ha sido acreditada";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
