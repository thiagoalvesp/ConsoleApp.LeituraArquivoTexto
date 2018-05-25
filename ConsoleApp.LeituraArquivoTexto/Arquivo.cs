using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LeituraArquivoTexto
{
    public class Arquivo
    {
        public static void Ler()
        {
            Console.WriteLine("Por favor informe o caminho do arquivo:");
            var arquivo = Console.ReadLine();

            if (File.Exists(arquivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        String linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            Repositorio.Gravar(linha.Split(';'));
                        }
                        Console.WriteLine("Arquivo lido com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(" O arquivo " + arquivo + "não foi localizado!");
            }
        }
    }
}
