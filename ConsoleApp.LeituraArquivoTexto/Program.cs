using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LeituraArquivoTexto
{
    class Program
    {
        static void Main(string[] args)
        {

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Ler arquivo.");
                Console.WriteLine("2 - Imprimir em tela.");
                Console.WriteLine("3 - Apagar os dados.");
                Console.WriteLine("4 - Sair.");
                var op = Console.ReadLine();

                Console.WriteLine("");

                if ("1".Equals(op))
                    Arquivo.Ler();
                else if ("2".Equals(op))
                    Impressora.Imprimir();
                else if ("3".Equals(op))
                    Repositorio.Apagar();
                else if ("4".Equals(op))
                    continuar = false;
                else
                    Console.WriteLine("Opção inválida.");

                Console.WriteLine("");
    
            }

            

        }
    }
}
