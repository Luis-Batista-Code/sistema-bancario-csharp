using System;

namespace SistemaBancarioApp
{
    public class Investimento
    {
        private double valorInvestido;
        private double rendimentoMensal;

        public Investimento(double valorInvestido, double rendimentoMensal)
        {
            this.valorInvestido = valorInvestido;
            this.rendimentoMensal = rendimentoMensal;
        }

        public double SimularLucro(int meses)
        {
            return valorInvestido * Math.Pow(1 + rendimentoMensal, meses) - valorInvestido;
        }
    }
}