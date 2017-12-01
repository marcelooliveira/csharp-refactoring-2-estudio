using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R18.ReplaceMagicNumber.depois
{
    class Programa
    {
        void Main()
        {
            var valorImposto = ICMS.CalcularValor(1000, "SP");
        }
    }

    class ICMS
    {
        private const decimal ICMS_SP_PARA_SP = 0.18m;
        private const decimal ICMS_PADRAO = 0.15m;
        private const string SAO_PAULO = "SP";

        public static decimal CalcularValor(decimal valorProdutos, string uf)
        {
            if (uf == SAO_PAULO)
            {
                return valorProdutos * ICMS_SP_PARA_SP;
            }
            return valorProdutos * ICMS_PADRAO;
        }
    }
}
