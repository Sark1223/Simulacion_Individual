using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestas_Restaurante
{
    internal class ValidacionDeValores
    {
        public bool ValidarNumeros(TextBox txt, ErrorProvider er, CancelEventArgs c)
        {
            //ciclo para recorrer caracter por caracter 
            foreach (char caracter in txt.Text)
            {
                //si alguno de los caracteres es un numero el error es true
                if (!char.IsDigit(caracter))
                {
                    c.Cancel = true;
                    txt.Select(0, txt.Text.Length);
                    er.SetError(txt, "No se admiten letras ni espacios en blanco\nIngrese números solamente");
                    return true;
                }
            }
            return false;
        }
    }
}
