using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R30.ReplaceTypeCodeWStateStrategy.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario funcionario1 = new Funcionario(new Engenheiro(), 2000, 0, 0);
            Funcionario funcionario2 = new Funcionario(new Vendedor(), 2000, 1500, 0);
            Funcionario funcionario3 = new Funcionario(new Gerente(), 3000, 0, 1000);

            var valorFolhaDePagamento =
                funcionario1.GetPagamento()
                + funcionario2.GetPagamento()
                + funcionario3.GetPagamento();
        }
    }

    //Veja também: 
    //SOLID com Java: Orientação a Objetos com Java
    //https://www.alura.com.br/curso-online-orientacao-a-objetos-avancada-e-principios-solid

    class Funcionario
    {
        private readonly decimal salario;
        public decimal Salario { get; }

        private readonly decimal comissao;
        public decimal Comissao { get; }

        private readonly decimal bonus;
        public decimal Bonus { get; }

        private TipoFuncionario tipo;
        public TipoFuncionario Tipo => tipo;

        public Funcionario(TipoFuncionario tipo, decimal salario, decimal comissao, decimal bonus)
        {
            this.tipo = tipo;
            this.salario = salario;
            this.comissao = comissao;
            this.bonus = bonus;
        }

        public void TrocarTipo(TipoFuncionario tipo)
        {
            this.tipo = tipo;
        }

        public decimal GetPagamento()
        {
            return tipo.GetPagamento(this);
        }
    }

    class TipoFuncionario
    {
        public virtual decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario;
        }
    }

    class Engenheiro : TipoFuncionario
    {
    }

    class Vendedor : TipoFuncionario
    {
        public override decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario + funcionario.Comissao;
        }
    }

    class Gerente : TipoFuncionario
    {
        public override decimal GetPagamento(Funcionario funcionario)
        {
            return funcionario.Salario + funcionario.Bonus;
        }
    }

}
