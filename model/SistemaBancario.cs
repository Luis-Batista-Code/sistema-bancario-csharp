using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaBancarioApp
{
    public class SistemaBancario
    {
        private Dictionary<string, ContaCorrente> contas;
        private const string ARQUIVO_DADOS = "contas.json";

        public SistemaBancario()
        {
            contas = CarregarContas();
        }

        // ==============================================================
        // MÉTODOS DE PERSISTÊNCIA (O "BANCO DE DADOS")
        // ==============================================================

        private Dictionary<string, ContaCorrente> CarregarContas()
        {
            if (File.Exists(ARQUIVO_DADOS))
            {
                try
                {
                    string json = File.ReadAllText(ARQUIVO_DADOS);
                    return JsonSerializer.Deserialize<Dictionary<string, ContaCorrente>>(json) 
                           ?? new Dictionary<string, ContaCorrente>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao carregar dados: {ex.Message}. Começando com banco de dados zerado.");
                    return new Dictionary<string, ContaCorrente>();
                }
            }
            return new Dictionary<string, ContaCorrente>();
        }

        public void SalvarContas()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true }; 
                string json = JsonSerializer.Serialize(contas, options);
                File.WriteAllText(ARQUIVO_DADOS, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro fatal ao salvar dados: {ex.Message}");
            }
        }

        // ==============================================================
        // MÉTODOS DE NEGÓCIO
        // ==============================================================
        
        public void CriarConta(string nome, string cpf, string numeroConta)
        {
            if (contas.ContainsKey(numeroConta))
            {
                Console.WriteLine("\nErro: Número de conta já existente.");
                return;
            }
            Cliente cliente = new Cliente(nome, cpf);
            ContaCorrente conta = new ContaCorrente(cliente, numeroConta);
            contas.Add(numeroConta, conta);
            SalvarContas();
            Console.WriteLine("\nConta criada com sucesso!");
        }

        public Conta BuscarConta(string numero)
        {
            contas.TryGetValue(numero, out ContaCorrente conta);
            return conta;
        }

        public void RealizarPIX(string origem, string destino, double valor)
        {
            Conta contaOrigem = BuscarConta(origem);
            Conta contaDestino = BuscarConta(destino);

            if (contaOrigem != null && contaDestino != null)
            {
                contaOrigem.Transferir(contaDestino, valor);
                SalvarContas();
                Console.WriteLine("\nTransferência realizada (se saldo suficiente).");
            }
            else
            {
                Console.WriteLine("\nConta origem ou destino não encontrada!");
            }
        }

        public void Investir(string numeroConta, double valor, double rendimento, int meses)
        {
            Conta conta = BuscarConta(numeroConta);
            if (conta != null && conta.Saldo >= valor)
            {
                conta.Sacar(valor);
                Investimento investimento = new Investimento(valor, rendimento);
                double lucro = investimento.SimularLucro(meses);
                conta.Depositar(valor + lucro);
                
                conta.Historico.Add($"Investimento: lucro de R${lucro:F2}");
                SalvarContas();
                Console.WriteLine("\nInvestimento realizado e lucro aplicado.");
            }
            else
            {
                Console.WriteLine("\nConta não encontrada ou saldo insuficiente para investir.");
            }
        }
    }
}