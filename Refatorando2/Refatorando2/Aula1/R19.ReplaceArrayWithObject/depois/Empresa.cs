using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace refatoracao.R19.ReplaceArrayWithObject.depois
{
    class Empresa
    {
        public Empresa()
        {
            using (var streamReader = File.OpenText("clientes.csv"))
            {
                string linha = string.Empty;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] campos = linha.Split(',');
                    var cliente = new Cliente(
                        campos[0], campos[1], campos[2], campos[3]);

                    Console.WriteLine("Dados do Cliente");
                    Console.WriteLine("================");
                    Console.WriteLine("ID: " + cliente.Id);
                    Console.WriteLine("Nome: " + cliente.Nome);
                    Console.WriteLine("Telefone: " + cliente.Fone);
                    Console.WriteLine("Website: " + cliente.Website);
                    Console.WriteLine("================");
                }
            }
        }
    }

    internal class Cliente
    {
        readonly string id;
        readonly string nome;
        readonly string fone;
        readonly string website;

        public Cliente(string id, string nome, string fone, string website)
        {
            this.id = id;
            this.nome = nome;
            this.fone = fone;
            this.website = website;
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public string Fone
        {
            get
            {
                return fone;
            }
        }

        public string Website
        {
            get
            {
                return website;
            }
        }
    }
}
