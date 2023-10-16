using System;
using System.Collections.Generic;
using static atcsharp.Crud;
using static atcsharp.ManipulacaoArquivo;

namespace atcsharp
{

    class Program
    {
        public static List<Conta> contas = new List<Conta>(contas);

        static void main(string[] args)
        {
            ManipulacaoArquivo.LerArquivo(contas);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Inclusão de conta");
                Console.WriteLine("2. Alteração de saldo");
                Console.WriteLine("3. Exclusão de conta");
                Console.WriteLine("4. Relatórios gerenciais");
                Console.WriteLine("5. Sair");
                int inp = int.Parse(Console.ReadLine());

                switch (inp)
                {
                    case 1:
                        Crud.IncluirConta(contas);
                        break;
                    case 2:
                        Crud.AlterarSaldo(contas);
                        break;
                    case 3:
                        Crud.ExcluirConta(contas);
                        break;
                    case 4:
                        Crud.GerarRelatorios(contas);
                        break;
                    case 5:
                        ManipulacaoArquivo.GravarArquivo(contas);
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
