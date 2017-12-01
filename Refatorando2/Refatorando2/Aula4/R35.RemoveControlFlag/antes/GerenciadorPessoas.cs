using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R35.RemoveControlFlag.antes
{
    class Programa
    {
        void Main()
        {
            var gerenciador =
                new GerenciadorPessoas()
                .EncontrarPessoaEspecial(new List<string> { "Diego", "Caio" });
        }
    }

    class GerenciadorPessoas
    {
        public GerenciadorPessoas()
        {
            IList<string> pessoas = new List<string>
            {
                "Marcelo",
                "Marcos",
                "Diego",
                "Caio",
                "Marlon"
            };

            var encontrouPessoa = EncontrarPessoaEspecial(pessoas);
        }

        public bool EncontrarPessoaEspecial(IList<string> pessoas)
        {
            bool encontrouPessoa = false;
            foreach (var person in pessoas)
            {
                if (person.Equals("Diego"))
                {
                    EnviarAlerta();
                    encontrouPessoa = true;
                }
                if (person.Equals("João"))
                {
                    EnviarAlerta();
                    encontrouPessoa = true;
                }
            }
            return encontrouPessoa;
        }

        private static void EnviarAlerta()
        {
            //código para enviar um alerta
        }
    }

}
