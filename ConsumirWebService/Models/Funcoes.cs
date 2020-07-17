using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsumirWebService.Models
{
    public class Funcoes
    {
        public static bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");
            if (!Rgx.IsMatch(cep))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string ExtraiNumeros(string texto)
        {
            var sb = new StringBuilder(texto.Length);
            foreach (var letra in texto)
                if (Char.IsDigit(letra))
                    sb.Append(letra);
            return sb.ToString();
        }

        public static string FormatarCep(string cep)
        {
            string cepFormatado = ExtraiNumeros(cep);
            if (cepFormatado.Length == 8)
            {
                return cepFormatado.Substring(0, 5) + "-" + cepFormatado.Substring(5, 3);
            }
            return "";
        }
    }
}
