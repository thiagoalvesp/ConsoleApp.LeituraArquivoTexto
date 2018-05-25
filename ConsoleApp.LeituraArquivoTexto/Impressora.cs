using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LeituraArquivoTexto
{
    public class Impressora
    {
        public static void Imprimir()
        {
            Repositorio.Consultar().ForEach(cl =>
            {
                string linha = FormataCampo(cl.Nome, 30, false) + "|" + FormataCampo(cl.Endereco, 50, false) + "|" + FormataCampo(cl.Telefone, 15, false);
                Console.WriteLine(linha);
            });
        }

        public static string FormataCampo(string valor, int tamanho, bool leftPad)
        {
            valor = valor ?? "";
            StringBuilder sb = new StringBuilder();
            if (leftPad)
            {
                valor = valor.PadLeft(tamanho, '0');
            }
            else
            {
                valor = valor.PadRight(tamanho, ' ');
            }

            sb.Append(valor, 0, tamanho);
            return sb.ToString();
        }
    }
}
