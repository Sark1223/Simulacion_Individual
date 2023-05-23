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
        frmIntervalos intervalos = new frmIntervalos();

        //Arreglo para guardar numeros
        public float[] Ri = new float[1050];

        bool numerosGenerados = false;
        private void cmdGenerarNumeros_Click(object sender, EventArgs e)
        {
            numeros.ObtenerObjetoPruebas(pruebas);
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

                    //Arreglos para guardar resultados
                    string[] DiaMesero= new string[7];
                    string[] DiaComida= new string[7];
                    string[] DiaLimpieza= new string[7];

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

                        DiaMesero[dias] = RecorrerMeseros(mes);
                        DiaComida[dias] = RecorrerComida(com);
                        DiaLimpieza[dias] = RecorrerLimpieza(lim);

                        string w  = "Las respuestas más obtenidas hacia:" +
                            $"\r\n - Meseros:{DiaMesero[dias]}" +
                            $"\r\n - Comida:{DiaComida[dias]}" +
                            $"\r\n - Limpieza:{DiaLimpieza[dias]}";

                        dgvResultados.Rows[renglon].Cells[5].Value = w;


                        dias++;

                    } while (dias < 7);

                    string resMeseros = RecorrerMeseros(DiaMesero);
                    string resComida = RecorrerComida(DiaComida);
                    string resLimpieza = RecorrerLimpieza(DiaLimpieza);

                    lblMeseros.Text = "El servicio de los meseros fue calificado por los clientes mayormente como: " + resMeseros;
                    lblComida.Text = "La calidad del estado en el que se encontraba la comida fue mayormente: " + resComida;
                    lblLimpieza.Text = "Segun los clientes encuestados, la limpieza del restaurante se encontraba mayormente: " + resLimpieza;


                    //Resultados
                    {

                        if (resMeseros == "Excelente" && resComida == "Excelente presentación" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "El servicio de los meseros, la limpieza del restaurante y el estado de la comida" +
                                " se encuentran en condiciones excelentes, el problema se podria encontrar en un punto no contemplado ó que " +
                                "las calificaciones recibidas en las paginas sean falsas.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Excelente presentación" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "El servicio de los meseros y la calidad de la comida son excelentes, hay un pequeño detalle " +
                                "en la limpieza, puede ser el motivo de las calificaciones negativas.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Excelente presentación" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "El servicio de los meseros y la calidad de la comida son excelentes, pero, la el restaurante " +
                                "fue encontradao SUCIO por muchos clientes, se deben tomar medidas al respecto.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Mal servida" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "Tanto la limpieza, como el servicio proporcionado por los meseros, es optimo, sin embargo, " +
                                "la comida se considero por los clientes 'MAL SERVIDA', se recomienda poner más atencion en el area de cocina.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Mal servida" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "Se recomienda que el restaurante se limpie con un poco más de constancia y que se ponga un poco más " +
                                "de atencion en la presentación de la comida, puede que sean los causantes de las malas calificiones.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Mal servida" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "La LIMPIEZA del restaurante es INEFICIENTE y la COMIDA se encuentra MAL SERVIDA, se deben tomar medidas al " +
                                "respecto para mejorar las calificaciones del restaurante.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Fria" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "La limpieza y el servicio son eficientes, mientras tanto, las personas reportaron " +
                                "que recibieron su comida fria, mejore este punto para poder mejorar sus calificaciones.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Fria" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "Los meseros realizan un trabajo impecable, pero la comida le llego fria a la mayoria de los clientes " +
                                "y la limpieza no es muy buena, sus calificaciones podrian mejorar si mejora estos ultimos 2 puntos.";
                        }

                        else if (resMeseros == "Excelente" && resComida == "Fria" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "La comida se encontro mayormente fria y el restaurante sucio, es indispensble tomar medidas al respecto " +
                                "para que puedan mejorar las calificaciones del restaurante.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Excelente presentación" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "Se debe trabajar un poco en la calidad del servicio de los meseros,puede que así mejoren las calificaciones." +
                                "La Limpieza y la comida son excelentes, puede que así mejoren las calificaciones.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Excelente presentación" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "La calidad del servicio de los meseros y la limpieza del restauranate no son muy buenas, si se mejoran " +
                                "podrian subir las calificaciones positivas del restaurante.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Excelente presentación" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "La calidad del servicio de los meseros y la limpieza del restauranate no son muy buenas, si se mejoran " +
                                "podrian subir las calificaciones positivas del restaurante.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Mal servida" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "La comida se encontro mayormente mal servida y el servicio de los meseros es bueno pero podria mejorar, " +
                                "estos puntos pueden ser los causantes de las malas claificaciones obtenidas.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Mal servida" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "La comida se encontro mayormente mal servida y el servicio de los meseros es bueno pero podria mejorar, " +
                                "estos puntos pueden ser los causantes de las malas claificaciones obtenidas.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Mal servida" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "Se debe mejorar la limpieza del restaurante y el estado en que se sirve la comida, ademas, la calidad del " +
                                "servicio de los meseros no es mala pero podria ser mejor. Si arregla estos puntos las calificaciones negativas podrian disminuir.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Fria" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "La comida se entrego fria a los clientes y la calidad del servicio de los meseros fue buena " +
                                "pero no excelente, si mejora estos puntos puede que las calificaciones hacia el restaurante mejoren..";
                        }

                        else if (resMeseros == "Buena" && resComida == "Fria" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "La comida se entrego fria, la limpieza y el servicio no son tan malos, pero puede que esten causando malas calificaciones" +
                                " hacia el restaurante.";
                        }

                        else if (resMeseros == "Buena" && resComida == "Fria" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "La COMIDA se entrego mayormente FRIA, el RESTAURANTE se encontro SUCIO, y el servicio de los meseros " +
                                "no se resalta mucho, puede que esto este provocando las malas calificaciones.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Excelente presentación" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "Aunque la comida es excelente y el restaurante se encontro mayormente limpio, el servicio de los meseros es malo, " +
                                "esto puede estar provocando las malas calificaciones en el restaurante.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Excelente presentación" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "Aunque la comida es Excelente, la calificacion del servicio de los meseros es mala y la limpieza no es muy buena, " +
                                "para mejorar las calificaciones debe mejorar la limpieza  y la atencion de los meseros.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Excelente presentación" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "Aunque la comida es Excelente, si el restaurante esta sucio y el servicio de los meseros es malo, " +
                                "las calificaciones negativas persistiran para le restaurante ";
                        }

                        else if (resMeseros == "Mala" && resComida == "Mal servida" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "La comida constantemente se sirve mal y el servicio de los meseros es malo, estas pueden ser las caudas de tener calificaciones negativas.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Mal servida" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "Posibles causas de las calificaciones negativas del restaurante: Mal servicio por parte de los meseros y que la comida no se ha " +
                                "estado sirviendo en buenas condiciones.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Mal servida" && resLimpieza == "Sucio")
                        {
                            txtConclusionGeneral.Text = "Es indispensable que los tres puntos de la encuesta (servicio de meseros, comida y limpieza) mejoren lo antes " +
                                "posible, esto podria mejorar las calificaciones del restaurante.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Fria" && resLimpieza == "Limpio")
                        {
                            txtConclusionGeneral.Text = "Es indispensable que el servicio de meseros y la comida mejoren lo antes " +
                                "posible, esto podria mejorar las calificaciones del restaurante.";
                        }

                        else if (resMeseros == "Mala" && resComida == "Fria" && resLimpieza == "Aceptable")
                        {
                            txtConclusionGeneral.Text = "Es indispensable que los tres puntos de la encuesta (servicio de meseros, comida y limpieza) mejoren lo antes " +
                                "posible, esto podria mejorar las calificaciones del restaurante.";
                        }

                        else
                        {
                            txtConclusionGeneral.Text = "La COMIDA se encontro mayormente FRIA, el RESTAURANTE SUCIO y el SERVICIO de los meseros es " +
                                "MALO, es indispensble tomar medidas al respecto para que puedan mejorar las calificaciones del restaurante.";
                        }
                }

                    pbAbajo.Location = new Point(435, cmdConfirmarCom.Location.Y + cmdConfirmarCom.Height +10);
                    pbAbajo.Visible = true;

                    pnResultados.Location = new Point(36, pnResEncabezado.Location.Y + pnResEncabezado.Height - 5);
                    pnResultados.Visible = true;

                    GuardarHisto();
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

        //HISTORIAL de Experimentos ----------------------------------------------------------------------
        public void GuardarHisto()
        {
            //Agrega nueva fila
            int n = historial.dgvHistorial.Rows.Add();

            //Agregar datos de numeros pseudo
            string datos = $"Xo = {numeros.txtSemilla.Text}\r\n" +
                           $"a = {numeros.txtA.Text}\r\n" +
                           $"c = {numeros.txtC.Text}\r\n" +
                           $"m = {numeros.txtM.Text}\r\n";
            historial.dgvHistorial.Rows[n].Cells[0].Value = datos;

            //AGREGAR datos de los ANIMALES -----------------
            {
                //Guardar probabilidad de meseros, comida y limpieza
                string proMese = "", proComi ="", proLim ="";
                for (int i = 0; i < inter_meseros.Count; i++)
                {
                    proMese += $"{inter_meseros[i].info} = {inter_meseros[i].proba}\r\n";
                    proComi += $"{inter_comida[i].info} = {inter_comida[i].proba}\r\n";
                    proLim += $"{inter_limpieza[i].info} = {inter_limpieza[i].proba}\r\n";
                }
                historial.dgvHistorial.Rows[n].Cells[1].Value = proMese;
                historial.dgvHistorial.Rows[n].Cells[2].Value = proComi;
                historial.dgvHistorial.Rows[n].Cells[3].Value = proLim;

                //Conclusion General
                historial.dgvHistorial.Rows[n].Cells[4].Value = txtConclusionGeneral.Text;
                ////Imprimir probabilidad de Comida
                //string proMese = "";
                //for (int i = 0; i < inter_comida.Count; i++)
                //{
                //    proMese += $"{inter_comida[i].info} = {inter_comida[i].proba}\r\n";
                //}
                //historial.dgvHistorial.Rows[n].Cells[1].Value = proMese;


            }
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
                    inter_meseros.Clear();
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
                    inter_comida.Clear();
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
                    inter_limpieza.Clear();
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
            pnResultados.Visible = false;
        }

        private void cmdIntervalos_Click(object sender, EventArgs e)
        {
            if (Meseros && Limpieza && Comida)
            {
                MostrarIntervalos();
                intervalos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero confirme las probabilidades.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public void MostrarIntervalos()
        {
            //Limpia las filas de las tablas de animales y de agua
            intervalos.dgvMeseros.Rows.Clear();
            intervalos.dgvComida.Rows.Clear();
            intervalos.dgvLimpieza.Rows.Clear();

            for (int i = 0; i < inter_meseros.Count; i++)
            {
                int n = intervalos.dgvMeseros.Rows.Add();
                intervalos.dgvMeseros.Rows[n].Cells[0].Value = inter_meseros[i].info;
                intervalos.dgvMeseros.Rows[n].Cells[1].Value = inter_meseros[i].proba;
                intervalos.dgvMeseros.Rows[n].Cells[2].Value = inter_meseros[i].lim_inferior;
                intervalos.dgvMeseros.Rows[n].Cells[3].Value = inter_meseros[i].lim_superior;
            }
            for (int i = 0; i < inter_comida.Count; i++)
            {
                int m = intervalos.dgvComida.Rows.Add();
                intervalos.dgvComida.Rows[m].Cells[0].Value = inter_comida[i].info;
                intervalos.dgvComida.Rows[m].Cells[1].Value = inter_comida[i].proba;
                intervalos.dgvComida.Rows[m].Cells[2].Value = inter_comida[i].lim_inferior;
                intervalos.dgvComida.Rows[m].Cells[3].Value = inter_comida[i].lim_superior;
            }
            for (int i = 0; i < inter_limpieza.Count; i++)
            {
                int w = intervalos.dgvLimpieza.Rows.Add();
                intervalos.dgvLimpieza.Rows[w].Cells[0].Value = inter_limpieza[i].info;
                intervalos.dgvLimpieza.Rows[w].Cells[1].Value = inter_limpieza[i].proba;
                intervalos.dgvLimpieza.Rows[w].Cells[2].Value = inter_limpieza[i].lim_inferior;
                intervalos.dgvLimpieza.Rows[w].Cells[3].Value = inter_limpieza[i].lim_superior;
            }

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
            Meseros = false;
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
            Meseros = false;
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
            Meseros = false;
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
            Comida = false;
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
            Comida = false;
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
            Comida = false;
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
            Limpieza = false;
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
            Limpieza = false;
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
            Limpieza = false;
        }


    }

    public class Datos_Intervalos
    {
        public string info;
        public float lim_superior, lim_inferior, proba;
    }
}
