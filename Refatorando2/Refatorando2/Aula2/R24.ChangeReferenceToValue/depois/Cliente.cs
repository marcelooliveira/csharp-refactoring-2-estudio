using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace refatoracao.R24.ChangeReferenceToValue.depois
{
    class Programa
    {
        public void Main()
        {
            Cliente joao = new Cliente("João Snow", 
                new DateTime(1985, 1, 1));
        }
    }

    class Cliente
    {
        private readonly string nome;
        public string Nome { get => nome; }

        private readonly DateTime dataNascimento;
        public DateTime DataNascimento { get => dataNascimento; }

        public Cliente(string nome, DateTime dataNascimento)
        {
            this.nome = nome;
            this.dataNascimento = dataNascimento;
        }

        public override bool Equals(object obj)
        {
            Cliente outro = obj as Cliente;
            if (outro == null)
            {
                return false; //early return
            }
            return base.Equals(outro);
        }

        public override int GetHashCode()
        {
            return nome.GetHashCode();
        }
    }
}
