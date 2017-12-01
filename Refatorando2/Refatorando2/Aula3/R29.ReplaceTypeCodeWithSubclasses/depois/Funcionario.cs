using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R29.ReplaceTypeCodeWithSubclasses.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario engenheiro = new Engenheiro("José da Silva", 1000);
            Funcionario vendedor = new Vendedor("Maria Bonita", 2000);
            Funcionario gerente = new Gerente("João das Neves", 3000);

            var valorFolhaDePagamento =
                engenheiro.Salario
                + vendedor.Salario
                + gerente.Salario;
        }
    }

    abstract class Funcionario
    {
        readonly string nome;
        public string Nome => nome;

        readonly decimal salario;
        public decimal Salario => salario;

        public Funcionario(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }
    }
    
    class Engenheiro : Funcionario
    {
        public Engenheiro(string nome, decimal salario) 
            : base(nome, salario) { }
    }

    class Vendedor : Funcionario
    {
        public Vendedor(string nome, decimal salario) 
            : base(nome, salario) { }
    }

    class Gerente : Funcionario
    {
        public Gerente(string nome, decimal salario) 
            : base(nome, salario) { }
    }

}
