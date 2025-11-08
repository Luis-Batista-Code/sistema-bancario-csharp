using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaBancarioApp
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Cliente cliente, string numeroConta)
            : base(cliente, numeroConta) { }

        [JsonConstructor]
        public ContaCorrente(Cliente cliente, string numeroConta, double saldo, List<string> historico)
            : base(cliente, numeroConta, saldo, historico) { }

        public override void Sacar(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                Historico.Add($"Saque: R${valor}");
                Console.WriteLine("Saque realizado com sucesso!"); // Feedback
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
                Historico.Add("Falha no saque: saldo insuficiente");
            }
        }
    }
}