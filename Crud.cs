namespace atcsharp
{

    public class Crud
    {

         static void IncluirConta(List<Conta> contas)
        {
            Console.Write("Digite o número da conta: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do correntista (nome e sobrenome): ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            if (contas.Exists(c => c.Id == id))
            {
                Console.WriteLine("Erro: Número de conta já existe.");
                return;
            }

            if (nome.Split(' ').Length < 2)
            {
                Console.WriteLine("Erro: O nome deve conter pelo menos dois nomes (nome e sobrenome).");
                return;
            }

            if (saldo < 0)
            {
                Console.WriteLine("Erro: O saldo inicial deve ser maior ou igual a zero.");
                return;
            }

            contas.Add(new Conta(id, nome, saldo));
            Console.WriteLine("Conta incluída com sucesso.");
        }

         static void AlterarSaldo(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Erro: Lista de contas vazia.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            int id = int.Parse(Console.ReadLine());

            Conta conta = contas.Find(c => c.Id == id);

            if (conta == null)
            {
                Console.WriteLine("Erro: Conta não encontrada.");
                return;
            }

            Console.Write("Digite o valor a ser creditado ou debitado: ");
            double valor = double.Parse(Console.ReadLine());

            if (valor <= 0)
            {
                Console.WriteLine("Erro: O valor deve ser maior que zero.");
                return;
            }

            conta.AlterarSaldo(valor);
            Console.WriteLine("Saldo alterado com sucesso.");
        }

         static void ExcluirConta(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Erro: Lista de contas vazia.");
                return;
            }

            Console.Write("Digite o número da conta: ");
            int id = int.Parse(Console.ReadLine());

            Conta conta = contas.Find(c => c.Id == id);

            if (conta == null)
            {
                Console.WriteLine("Erro: Conta não encontrada.");
                return;
            }

            if (conta.Saldo != 0)
            {
                Console.WriteLine("Erro: O saldo da conta não é zero. Não é possível excluir.");
                return;
            }

            contas.Remove(conta);
            Console.WriteLine("Conta excluída com sucesso.");
        }

         static void GerarRelatorios(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Erro: Lista de contas vazia.");
                return;
            }

            Console.WriteLine("Opções de relatórios:");
            Console.WriteLine("1. Listar clientes com saldo negativo");
            Console.WriteLine("2. Listar clientes com saldo acima de um determinado valor");
            Console.WriteLine("3. Listar todas as contas");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ListarClientesSaldoNegativo(contas);
                    break;
                case 2:
                    ListarClientesSaldoAcimaDe(contas);
                    break;
                case 3:
                    ListarTodasAsContas(contas);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

         static void ListarClientesSaldoNegativo(List<Conta> contas)
        {
            var clientesSaldoNegativo = contas.FindAll(c => c.Saldo < 0);
            if (clientesSaldoNegativo.Count == 0)
            {
                Console.WriteLine("Nenhum cliente com saldo negativo encontrado.");
                return;
            }

            Console.WriteLine("Clientes com saldo negativo:");
            foreach (var cliente in clientesSaldoNegativo)
            {
                Console.WriteLine(cliente);
            }
        }

         static void ListarClientesSaldoAcimaDe(List<Conta> contas)
        {
            Console.Write("Digite o valor mínimo de saldo: ");
            double valorMinimo = double.Parse(Console.ReadLine());

            var clientesSaldoAcimaDe = contas.FindAll(c => c.Saldo > valorMinimo);
            if (clientesSaldoAcimaDe.Count == 0)
            {
                Console.WriteLine("Nenhum cliente com saldo acima do valor informado encontrado.");
                return;
            }

            Console.WriteLine($"Clientes com saldo acima de {valorMinimo}:");
            foreach (var cliente in clientesSaldoAcimaDe)
            {
                Console.WriteLine(cliente);
            }
        }

         static void ListarTodasAsContas(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada.");
                return;
            }

            Console.WriteLine("Todas as contas:");
            foreach (var conta in contas)
            {
                Console.WriteLine(conta);
            }
        }


    }
}