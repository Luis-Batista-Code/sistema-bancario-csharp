using System;
using SistemaBancarioApp;

internal class Program
{
    private static void Main(string[] args)
    {
        SistemaBancario sistema = new SistemaBancario();
        
        Console.WriteLine("=== Bem-vindo ao Bank (Versão C#) ===");

        bool rodando = true;
        while (rodando)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Transferência via PIX");
            Console.WriteLine("5 - Investir");
            Console.WriteLine("6 - Mostrar histórico");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("\nNome do cliente: ");
                    string nome = Console.ReadLine();
                    Console.Write("CPF do cliente: ");
                    string cpf = Console.ReadLine();
                    Console.Write("Número da conta: ");
                    string numeroConta = Console.ReadLine();

                    sistema.CriarConta(nome, cpf, numeroConta);
                    break;

                case 2:
                    Console.Write("\nNúmero da conta para depósito: ");
                    string contaDeposito = Console.ReadLine();
                    Conta contaDep = sistema.BuscarConta(contaDeposito);
                    if (contaDep != null)
                    {
                        Console.Write("Valor para depositar: ");
                        if (double.TryParse(Console.ReadLine(), out double valorDep))
                        {
                            contaDep.Depositar(valorDep);
                            sistema.SalvarContas();
                            Console.WriteLine("\nDepósito realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nValor inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nConta não encontrada!");
                    }
                    break;

                case 3:
                    Console.Write("\nNúmero da conta para saque: ");
                    string contaSaque = Console.ReadLine();
                    Conta contaSaq = sistema.BuscarConta(contaSaque);
                    if (contaSaq != null)
                    {
                        Console.Write("Valor para sacar: ");
                        if (double.TryParse(Console.ReadLine(), out double valorSaq))
                        {
                            contaSaq.Sacar(valorSaq);
                            sistema.SalvarContas();
                        }
                        else
                        {
                            Console.WriteLine("\nValor inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nConta não encontrada!");
                    }
                    break;

                case 4:
                    Console.Write("\nNúmero da conta origem: ");
                    string contaOrigem = Console.ReadLine();
                    Console.Write("Número da conta destino: ");
                    string contaDestino = Console.ReadLine();
                    Console.Write("Valor para transferir: ");
                    if (double.TryParse(Console.ReadLine(), out double valorPix))
                    {
                        sistema.RealizarPIX(contaOrigem, contaDestino, valorPix);
                    }
                    else
                    {
                        Console.WriteLine("\nValor inválido.");
                    }
                    break;

                case 5:
                    Console.Write("\nNúmero da conta para investimento: ");
                    string contaInv = Console.ReadLine();
                    Conta contaInvest = sistema.BuscarConta(contaInv);
                    if (contaInvest != null)
                    {
                        try
                        {
                            Console.Write("Valor para investir: ");
                            double valorInvest = double.Parse(Console.ReadLine());
                            Console.Write("Rendimento mensal (ex: 0.02 para 2%): ");
                            double rendimento = double.Parse(Console.ReadLine());
                            Console.Write("Meses para simular: ");
                            int meses = int.Parse(Console.ReadLine());

                            sistema.Investir(contaInv, valorInvest, rendimento, meses);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nValor ou meses inválidos.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nConta não encontrada!");
                    }
                    break;

                case 6:
                    Console.Write("\nNúmero da conta para mostrar histórico: ");
                    string contaHist = Console.ReadLine();
                    Conta contaHistEx = sistema.BuscarConta(contaHist);
                    if (contaHistEx != null)
                    {
                        contaHistEx.ExibirHistorico();
                    }
                    else
                    {
                        Console.WriteLine("\nConta não encontrada!");
                    }
                    break;

                case 0:
                    rodando = false;
                    Console.WriteLine("\nObrigado por usar o Bank. Até mais!");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida.");
                    break;
            }
        }
    }
}