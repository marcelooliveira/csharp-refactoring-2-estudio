using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R29.ReplaceTypeCodeWithSubclasses.antes
{
    class Programa
    {
        void Main()
        {
            Funcionario engenheiro = Funcionario.Criar(Funcionario.TipoFuncionario.Engenheiro, "José da Silva", 1000);
            Funcionario vendedor = Funcionario.Criar(Funcionario.TipoFuncionario.Vendedor, "Maria Bonita", 2000);
            Funcionario gerente = Funcionario.Criar(Funcionario.TipoFuncionario.Gerente, "João das Neves", 3000);

            var valorFolhaDePagamento = 
                engenheiro.Salario 
                + vendedor.Salario 
                + gerente.Salario;
        }
    }

    class Funcionario
    {
        public enum TipoFuncionario
        {
            Engenheiro = 0,
            Vendedor = 1,
            Gerente = 2
        }

        readonly TipoFuncionario tipo;
        public TipoFuncionario Tipo { get; }

        readonly string nome;
        public string Nome => nome;

        readonly decimal salario;
        public decimal Salario => salario;

        private Funcionario(TipoFuncionario tipo, string nome, decimal salario)
        {
            this.tipo = tipo;
            this.nome = nome;
            this.salario = salario;
        }

        public static Funcionario Criar(TipoFuncionario tipo, string nome, decimal salario)
        {
            return new Funcionario(tipo, nome, salario);
        }
    }

}
