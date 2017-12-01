using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R18.SelfEncapsulateField.depois
{
    class Programa
    {
        void Main()
        {
            var conta = new ContaCorrente(100);
            conta.Depositar(100);
            conta.Sacar(75);
            //conta.saldo -= 35; //não é mais permitido!!
        }
    }

    class ContaCorrente
    {
        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
        }

        public ContaCorrente(decimal saldo)
        {
            this.saldo = saldo;
        }

        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                throw new ArgumentException("Saldo insuficiente");
            }

            this.saldo -= valor;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
        }
    }
}
