using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Encuestas_Restaurante
{
    public partial class frmProblema : Form
    {
        public frmProblema()
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

        private void frmProblema_Load(object sender, EventArgs e)
        {
            cmdSimularEncuestas.Tag = "Inabilitar";
        }

        frmHistorial historial = new frmHistorial();
        frmPruebas pruebas = new frmPruebas();
        frmNumeros numeros = new frmNumeros();

        //Arreglo para guardar numeros
        public float[] Ri = new float[1050];

        bool numerosGenerados = false;
        private void cmdGenerarNumeros_Click(object sender, EventArgs e)
        {
            numeros.numerosGenerados = false;
            numeros.ShowDialog();

            if (numeros.numerosGenerados)
            {
                cmdSimularEncuestas.Tag = "Habilitar";
                Ri = numeros.Ri;
                numerosGenerados = true;
            }
        }

        private string RecorrerMeseros(string[] arg)
        {
            int b = 0, m = 0, e = 0;

            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] == "Buena")
                {
                    b++;
                }
                if (arg[i] == "Mala")
                {
                    m++;
                }
                if (arg[i] == "Excelente")
                {
                    e++;
                }
            }

            int[] FO = { b, m, e };

            for (int x = 0; x < FO.Length; x++)
            {
                for (int indiceActual = 0; indiceActual < FO.Length - 1; indiceActual++)
                {
                    int indiceSiguienteElemento = indiceActual + 1;
                    // Si el actual es mayor que el que le sigue a la derecha...
                    if (FO[indiceActual] > FO[indiceSiguienteElemento])
                    {
                        int temporal = FO[indiceActual];
                        FO[indiceActual] = FO[indiceSiguienteElemento];
                        FO[indiceSiguienteElemento] = temporal;
                    }
                }
            }

            string masEncontrado = "";

            if (FO[2] == b)
            {
                masEncontrado = "Buena";
            }
            else if (FO[2] == m)
            {
                masEncontrado = "Mala";
            }
            else if (FO[2] == e)
            {
                masEncontrado = "Excelente";
            }

            return   masEncontrado;
            //txtC.Text += $"   - {sector} fue: " + masEncontrado + "\r\n";
        }
        private string RecorrerComida(string[] arg)
        {
            int b = 0, m = 0, e = 0;

            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] == "Fria")
                {
                    b++;
                }
                if (arg[i] == "Mal servida")
                {
                    m++;
                }
                if (arg[i] == "Excelente presentación")
                {
                    e++;
                }
            }

            int[] FO = { b, m, e };

            for (int x = 0; x < FO.Length; x++)
            {
                for (int indiceActual = 0; indiceActual < FO.Length - 1; indiceActual++)
                {
                    int indiceSiguienteElemento = indiceActual + 1;
                    // Si el actual es mayor que el que le sigue a la derecha...
                    if (FO[indiceActual] > FO[indiceSiguienteElemento])
                    {
                        int temporal = FO[indiceActual];
                        FO[indiceActual] = FO[indiceSiguienteElemento];
                        FO[indiceSiguienteElemento] = temporal;
                    }
                }
            }

            string masEncontrado = "";

            if (FO[2] == b)
            {
                masEncontrado = "Fria";
            }
            else if (FO[2] == m)
            {
                masEncontrado = "Mal servida";
            }
            else if (FO[2] == e)
            {
                masEncontrado = "Excelente presentación";
            }

            return masEncontrado;
            //txtC.Text += $"   - {sector} fue: " + masEncontrado + "\r\n";
        }
        private string RecorrerLimpieza(string[] arg)
        {
            int b = 0, m = 0, e = 0;

            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] == "Sucio")
                {
                    b++;
                }
                if (arg[i] == "Limpio")
                {
                    m++;
                }
                if (arg[i] == "Aceptable")
                {
                    e++;
                }
            }

            int[] FO = { b, m, e };

            for (int x = 0; x < FO.Length; x++)
            {
                for (int indiceActual = 0; indiceActual < FO.Length - 1; indiceActual++)
                {
                    int indiceSiguienteElemento = indiceActual + 1;
                    // Si el actual es mayor que el que le sigue a la derecha...
                    if (FO[indiceActual] > FO[indiceSiguienteElemento])
                    {
                        int temporal = FO[indiceActual];
                        FO[indiceActual] = FO[indiceSiguienteElemento];
                        FO[indiceSiguienteElemento] = temporal;
                    }
                }
            }

            string masEncontrado = "";

            if (FO[2] == b)
            {
                masEncontrado = "Sucio";
            }
            else if (FO[2] == m)
            {
                masEncontrado = "Limpio";
            }
            else if (FO[2] == e)
            {
                masEncontrado = "Aceptable";
            }

            return masEncontrado;
            //txtC.Text += $"   - {sector} fue: " + masEncontrado + "\r\n";
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
                if(Meseros && Comida && Limpieza)
                {
                    int dias = 0, numero = 0;
                    int renglon;
                    //Limpiar Tabla
                    dgvResultados.Rows.Clear();
                    do
                    {
                        //Agregra nuevo Renglon
                        renglon = dgvResultados.Rows.Add();

                        //Agregar dia al nuevo renglon
                        dgvResultados.Rows[renglon].Cells[0].Value = dias + 1;//Dia

                        string cliente = "", mesero = "", comida = "", limpieza = "";
                        string[] mes = new string[50], com = new string[50], lim = new string[50];

                        for (int i = 0; i <50; i++)
                        {
                            cliente += "Cliente "+ (i+1) +"\r\n";//Cliente

                            //Calificación al servicio del mesero
                            string a = Res_Meseros(Ri[numero]);
                            mesero += $"{Ri[numero]:N2} - {a}\r\n";
                            mes[i] = a;
                            numero++;

                            //Calificación a la comida
                            string b = Res_Comida(Ri[numero]);
                            comida += $"{Ri[numero]:N2} - {b}\r\n";
                            com[i] = b;
                            numero++;

                            //Calificacion a la limpieza
                            string c = Res_Limpieza(Ri[numero]);
                            limpieza += $"{Ri[numero]:N2} - {c}\r\n";
                            lim[i] = c;
                            numero++;
                        }

                        dgvResultados.Rows[renglon].Cells[1].Value = cliente;
                        dgvResultados.Rows[renglon].Cells[2].Value = mesero;
                        dgvResultados.Rows[renglon].Cells[3].Value = comida;
                        dgvResultados.Rows[renglon].Cells[4].Value = limpieza;

                        string w  = $"Las respuestas más obtenidas hacia\r\n" +
                            $"los meseros fue: {RecorrerMeseros(mes)}";


                        dias++;

                    } while (dias < 7);
                }
                else
                {
                    MessageBox.Show("Verifique que los datos de las probabilidades esten correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        float mesBuena, mesMala, mesExelente, comFria, comMal, comExcel, limSus, limLim, limAcep;
        private string Res_Meseros(float num)
        {
            if(num >= inter_meseros[0].lim_inferior && num<= inter_meseros[0].lim_superior)
            {
                mesBuena++;
                return inter_meseros[0].info;
            }
            else if (num >= inter_meseros[1].lim_inferior && num <= inter_meseros[1].lim_superior)
            {
                mesMala++;
                return inter_meseros[1].info;
            }
            else
            {
                mesExelente++;
                return inter_meseros[2].info;
            }
        }

        private string Res_Comida(float num)
        {
            if (num >= inter_comida[0].lim_inferior && num <= inter_comida[0].lim_superior)
            {
                comFria++;
                return inter_comida[0].info;
            }
            else if (num >= inter_comida[1].lim_inferior && num <= inter_comida[1].lim_superior)
            {
                comMal++;
                return inter_comida[1].info;
            }
            else
            {
                comExcel++;
                return inter_comida[2].info;
            }
        }

        private string Res_Limpieza(float num)
        {
            if (num >= inter_limpieza[0].lim_inferior && num <= inter_limpieza[0].lim_superior)
            {
                limSus++;
                return inter_limpieza[0].info;
            }
            else if (num >= inter_limpieza[1].lim_inferior && num <= inter_limpieza[1].lim_superior)
            {
                limLim++;
                return inter_limpieza[1].info;
            }
            else
            {
                limAcep++;
                return inter_limpieza[2].info;
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

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool validarMeseros, validarComida, validarLimpieza;

        ValidacionDeValores validacion = new ValidacionDeValores();
        Datos_Intervalos datos;
        List<Datos_Intervalos> inter_comida = new List<Datos_Intervalos>();
        List<Datos_Intervalos> inter_meseros = new List<Datos_Intervalos>();
        List<Datos_Intervalos> inter_limpieza = new List<Datos_Intervalos>();

        bool Meseros, Comida, Limpieza;
        
        public void LimitesComida()
        {
            //Datos del estado de la comida
            /*Fría
              Mal servida
              Exelente presentacion*/
            datos = new Datos_Intervalos();
            datos.info = "Fria";
            datos.proba = comidaF;
            datos.lim_inferior = 0F;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_comida.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Mal servida";
            datos.proba = comidaM;
            datos.lim_inferior = inter_comida[0].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_comida.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Excelente presentación";
            datos.proba = comidaE;
            datos.lim_inferior = inter_comida[1].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_comida.Add(datos);

        }

        public void LimitesMeseros()
        {
            //Datos del estado de la comida
            /*Buena
Mala
Excelente*/
            datos = new Datos_Intervalos();
            datos.info = "Buena";
            datos.proba = meserosB;
            datos.lim_inferior = 0F;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_meseros.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Mala";
            datos.proba = meserosM;
            datos.lim_inferior = inter_meseros[0].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_meseros.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Excelente";
            datos.proba = meserosE;
            datos.lim_inferior = inter_meseros[1].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_meseros.Add(datos);

        }

        public void LimitesLimpieza()
        {
            //Datos del estado de la comida
            datos = new Datos_Intervalos();
            datos.info = "Sucio";
            datos.proba = limpiezaS;
            datos.lim_inferior = 0F;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_limpieza.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Limpio";
            datos.proba =limpiezaL;
            datos.lim_inferior = inter_limpieza[0].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_limpieza.Add(datos);

            datos = new Datos_Intervalos();
            datos.info = "Aceptable";
            datos.proba = limpiezaA;
            datos.lim_inferior = inter_limpieza[1].lim_superior;
            datos.lim_superior = datos.lim_inferior + datos.proba;
            inter_limpieza.Add(datos);

        }


        float meserosE, meserosM, meserosB;  float comidaE, comidaF, comidaM;  float limpiezaA, limpiezaL, limpiezaS;
        private void cmdConfirmarSer_Click(object sender, EventArgs e)
        {
            if (validarMeseros)
            {
                MessageBox.Show("Verifique que los datos sean validos");
            }
            else if (txtMeserosM.Text == "" || txtMeserosB.Text == "" || txtMeserosE.Text == "")
            {
                MessageBox.Show("Verifique que no haya espacios en blanco");
            }
            else
            {
                float suma = 0F;

                //Recuperacion de datos ingresados por el usuario
                meserosE = (float)Math.Round(float.Parse(txtMeserosE.Text) * 0.01F, 2);
                meserosM = (float)Math.Round(float.Parse(txtMeserosM.Text) * 0.01F, 2);
                meserosB = (float)Math.Round(float.Parse(txtMeserosB.Text) * 0.01F, 2);

                suma = (meserosE + meserosM + meserosB);

                txtSuma1.Text = "" + suma;

                if (suma == 1)
                {
                    Meseros = true;
                    Confirmado(cmdConfirmarSer);
                    LimitesMeseros();
                    //Crear distribucion acumulada
                }
                else
                {
                    Meseros = false;
                    Desconfirmado(cmdConfirmarSer);
                    if (suma > 1)
                    {
                        MessageBox.Show("La suma de la distribucion de probabilidad supera el 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                    else
                    {
                        MessageBox.Show("La suma de la distribucion es menor a 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                }
                txtTotal1.Visible = true;
            }
        }

        private void cmdConfirmarCom_Click(object sender, EventArgs e)
        {
            if (validarComida)
            {
                MessageBox.Show("Verifique que los datos sean validos");
            }
            else if (txtComidaE.Text == "" || txtComidaF.Text == "" || txtComidaM.Text == "")
            {
                MessageBox.Show("Verifique que no haya espacios en blanco");
            }
            else
            {
                float suma = 0F;

                //Recuperacion de datos ingresados por el usuario
                comidaE = (float)Math.Round(float.Parse(txtComidaE.Text) * 0.01F, 2);
                comidaF = (float)Math.Round(float.Parse(txtComidaF.Text) * 0.01F, 2);
                comidaM = (float)Math.Round(float.Parse(txtComidaM.Text) * 0.01F, 2);

                suma = (comidaE + comidaF + comidaM);

                txtSuma2.Text = "" + suma;

                if (suma == 1)
                {
                    Comida = true;
                    Confirmado(cmdConfirmarCom);
                    LimitesComida();
                    //Crear distribucion acumulada
                }
                else
                {
                    Comida = false;
                    Desconfirmado(cmdConfirmarCom);
                    if (suma > 1)
                    {
                        MessageBox.Show("La suma de la distribucion de probabilidad supera el 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                    else
                    {
                        MessageBox.Show("La suma de la distribucion es menor a 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                }
                txtTotal2.Visible = true;
            }
        }

        private void cmdConfirmarLimpi_Click(object sender, EventArgs e)
        {
            if (validarLimpieza)
            {
                MessageBox.Show("Verifique que los datos sean validos");
            }
            else if (txtLimpiezaA.Text == "" || txtLimpiezaL.Text == "" || txtLimpiezaS.Text == "")
            {
                MessageBox.Show("Verifique que no haya espacios en blanco");
            }
            else
            {
                float suma = 0F;

                //Recuperacion de datos ingresados por el usuario
                limpiezaS = (float)Math.Round(float.Parse(txtLimpiezaS.Text) * 0.01F, 2);
                limpiezaL = (float)Math.Round(float.Parse(txtLimpiezaL.Text) * 0.01F, 2);
                limpiezaA = (float)Math.Round(float.Parse(txtLimpiezaA.Text) * 0.01F, 2);

                suma = (limpiezaS + limpiezaL + limpiezaA);

                txtSuma3.Text = "" + suma;

                if (suma == 1)
                {
                    Limpieza = true;
                    Confirmado(cmdConfirmarLimpi);
                    LimitesLimpieza();
                    //Crear distribucion acumulada
                }
                else
                {
                    Limpieza = false;
                    Desconfirmado(cmdConfirmarLimpi);
                    if (suma > 1)
                    {
                        MessageBox.Show("La suma de la distribucion de probabilidad supera el 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                    else
                    {
                        MessageBox.Show("La suma de la distribucion es menor a 1, Favor de verificar los datos", "Error al ingresar datos");
                    }
                }
                txtTotal3.Visible = true;
            }
        }

        
        private void Confirmado(Button boton)
        {
            boton.BackColor = Color.YellowGreen;
        }

        private void Desconfirmado(Button boton)
        {
            boton.BackColor = Color.FromArgb(242, 145, 153);
        }

        //Validaciones de TextBox Meseros
        private void txtMeserosM_Validating(object sender, CancelEventArgs e)
        {
            validarMeseros = validacion.ValidarNumeros(txtMeserosM, error, e);
        }

        private void txtMeserosM_Validated(object sender, EventArgs e)
        {
            error.SetError(txtMeserosM, "");
        }

        private void txtMeserosM_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarSer);
        }

        private void txtMeserosE_Validating(object sender, CancelEventArgs e)
        {
            validarMeseros = validacion.ValidarNumeros(txtMeserosE, error, e);
        }

        private void txtMeserosE_Validated(object sender, EventArgs e)
        {
            error.SetError(txtMeserosE, "");
        }

        private void txtMeserosE_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarSer);
        }

        private void txtMeserosB_Validated(object sender, EventArgs e)
        {
            error.SetError(txtMeserosB, "");
        }

        private void txtMeserosB_Validating(object sender, CancelEventArgs e)
        {
            validarMeseros = validacion.ValidarNumeros(txtMeserosB, error, e);
        }

        private void txtMeserosB_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarSer);
        }


        //Validaciones de TextBox Comida
        private void txtComidaF_Validating(object sender, CancelEventArgs e)
        {
            validarComida = validacion.ValidarNumeros(txtComidaF, error, e);
        }

        private void txtComidaF_Validated(object sender, EventArgs e)
        {
            error.SetError(txtComidaF, "");
        }

        private void txtComidaF_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarCom);
        }

        private void txtComidaM_Validating(object sender, CancelEventArgs e)
        {
            validarComida = validacion.ValidarNumeros(txtComidaM, error, e);
        }

        private void txtComidaM_Validated(object sender, EventArgs e)
        {
            error.SetError(txtComidaM, "");
        }

        private void txtComidaM_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarCom);
        }

        private void txtComidaE_Validating(object sender, CancelEventArgs e)
        {
            validarComida = validacion.ValidarNumeros(txtComidaE, error, e);
        }

        private void txtComidaE_Validated(object sender, EventArgs e)
        {
            error.SetError(txtComidaE, "");
        }

        private void txtComidaE_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarCom);
        }


        //Validaciones de TextBox Limpieza
        private void txtLimpiezaS_Validating(object sender, CancelEventArgs e)
        {
            validarLimpieza = validacion.ValidarNumeros(txtLimpiezaS, error, e);
        }

        private void txtLimpiezaS_Validated(object sender, EventArgs e)
        {
            error.SetError(txtLimpiezaS, "");
        }

        private void txtLimpiezaS_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarLimpi);
        }

        private void txtLimpiezaL_Validating(object sender, CancelEventArgs e)
        {
            validarLimpieza = validacion.ValidarNumeros(txtLimpiezaL, error, e);
        }

        private void txtLimpiezaL_Validated(object sender, EventArgs e)
        {
            error.SetError(txtLimpiezaL, "");
        }

        private void txtLimpiezaL_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarLimpi);
        }

        private void txtLimpiezaA_Validating(object sender, CancelEventArgs e)
        {
            validarLimpieza = validacion.ValidarNumeros(txtLimpiezaA, error, e);
        }

        private void txtLimpiezaA_Validated(object sender, EventArgs e)
        {
            error.SetError(txtLimpiezaA, "");
        }

        private void txtLimpiezaA_TextChanged(object sender, EventArgs e)
        {
            Desconfirmado(cmdConfirmarLimpi);
        }


    }

    public class Datos_Intervalos
    {
        public string info;
        public float lim_superior, lim_inferior, proba;
    }
}
