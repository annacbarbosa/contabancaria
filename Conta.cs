namespace atcsharp
{

    public class Conta
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public double Saldo { get; private set; }

        public Conta(int id, string nome, double saldo)
        {
            Id = id;
            Nome = nome;
            Saldo = saldo;
        }

        public void AlterarSaldo(double valor)
        {
            Saldo += valor;
        }

        public override string ToString()
        {
            return $"{Id};{Nome};{Saldo}";
        }
    }
}