using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace refatoracao.R20.ChangeValueToReference.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario.CarregarFuncionarios();
            var projeto = new Projeto("João Snow");
            projeto.SetGerente("Sonia Stark");
        }

        private static int QtdePedidosDe(IList<Projeto> orders, string nomeCliente)
        {
            return orders.Count(o => o.Gerente.Nome == nomeCliente);
        }
    }

    class Funcionario
    {
        private readonly String nome;
        public string Nome => nome;

        public static void CarregarFuncionarios()
        {
            new Funcionario("João Snow").Save();
            new Funcionario("Sonia Stark").Save();
            new Funcionario("Daniele Targaryen").Save();
        }

        private Funcionario(String nome)
        {
            this.nome = nome;
        }

        private void Save()
        {
            funcionarios.Add(this.nome, this);
        }

        private static IDictionary<string, Funcionario> funcionarios
            = new Dictionary<string, Funcionario>();

        public static Funcionario Get(string nome)
        {
            Funcionario funcionario = (Funcionario)funcionarios[nome];
            if (funcionario == null)
            {
                funcionario = new Funcionario(nome);
                funcionarios.Add(nome, funcionario);
            }
            return funcionario;
        }
    }

    class Projeto
    {
        private Funcionario gerente;
        internal Funcionario Gerente { get => gerente; }

        public Projeto(String nomeGerente)
        {
            this.gerente = Funcionario.Get(nomeGerente);
        }

        public void SetGerente(string nomeFuncionario)
        {
            this.gerente = Funcionario.Get(nomeFuncionario);
        }
    }
}
