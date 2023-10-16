using System.IO;

namespace atcsharp
{

     public class ManipulacaoArquivo

{

         static void LerArquivo(List<Conta> contas)
        {
            try
            {
                string[] linhas = File.ReadAllLines("contas.csv");
                foreach (var linha in linhas)
                {
                    string[] dados = linha.Split(';');
                    int id = int.Parse(dados[0]);
                    string nome = dados[1];
                    double saldo = double.Parse(dados[2]);
                    contas.Add(new Conta(id, nome, saldo));
                }
            }
          catch (FileNotFoundException) {
            Console.Write("Erro: arquivo de destino não encontrado");
          }
        }

            static void GravarArquivo(List<Conta> contas)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("contas.csv"))
                    {
                        foreach (var conta in contas)
                        {
                            sw.WriteLine(conta.ToString());
                        }
                    }

                    Console.WriteLine("Dados gravados com sucesso.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao gravar o arquivo: {e.Message}");
                }

            }
        }
  }