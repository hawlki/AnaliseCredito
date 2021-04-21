using System;

namespace analisecredito
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Beep();

            Console.WriteLine("------------------------------");
            Console.WriteLine("       Análise  crédito       ");
            Console.WriteLine("------------------------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Insira o valor do empréstimo: ");
            bool emprestimoValido = decimal.TryParse(Console.ReadLine(), out decimal emprestimo);
            Console.Write("Insira a quantidade de parcelas desejada: ");
            bool parcelasValida = Int32.TryParse(Console.ReadLine(), out Int32 parcelas);
            Console.Write("Insira sua renda mensal: ");
            bool rendaValida = decimal.TryParse(Console.ReadLine(), out decimal renda);
            Console.WriteLine();

            if(!emprestimoValido || !parcelasValida || !rendaValida)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite somente números");
                Console.ResetColor();
                Environment.Exit(1);
            }

            decimal valorParcela = emprestimo / parcelas;
            decimal pRenda = (renda / 100) * 30;

            if(valorParcela > pRenda)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Não é possível efetuar seu empréstimo, pois o valor da parcela (R${valorParcela}) ultrapassa os 30% de sua renda mensal (R${renda})");
                Console.ResetColor();
                Environment.Exit(1);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Empréstimo aprovado no valor de R${emprestimo} dividido em {parcelas} vezes de R${valorParcela}");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }
    }
}
