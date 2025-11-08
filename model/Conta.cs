using System;
using System.Collections.Generic;

namespace SistemaBancarioApp
{
    public abstract class Conta
    {
        public double Saldo { get; protected set; }
        public Cliente Cliente { get; set; }
        public string NumeroConta { get; set; }
        public List<string> Historico { get; set; } = new List<string>();

        public Conta(Cliente cliente, string numeroConta)
        {
            Cliente = cliente;
            NumeroConta = numeroConta;
            Saldo = 0;
        }

        public Conta(Cliente cliente, string numeroConta, double saldo, List<string> historico)
        {
            Cliente = cliente;
            NumeroConta = numeroConta;
            Saldo = saldo;
            Historico = historico;
        }


        public abstract void Sacar(double valor);

        public void Depositar(double valor)
        {
            Saldo += valor;
            Historico.Add($"Depósito: R${valor}");
        }

        public void Transferir(Conta destino, double valor)
        {
            if (valor <= Saldo)
            {
                this.Sacar(valor);
                destino.Depositar(valor);
                Historico.Add($"Transferência PIX para {destino.NumeroConta}: R${valor}");
            }
            else
            {
                Historico.Add($"Falha na transferência PIX para {destino.NumeroConta}: saldo insuficiente");
                Console.WriteLine("Saldo insuficiente para transferência!");
            }
        }

        public void ExibirHistorico()
        {
            Console.WriteLine($"\nHistórico da conta {NumeroConta}:");
            foreach (string linha in Historico)
            {
                Console.WriteLine(linha);
            }
        }
    }
}