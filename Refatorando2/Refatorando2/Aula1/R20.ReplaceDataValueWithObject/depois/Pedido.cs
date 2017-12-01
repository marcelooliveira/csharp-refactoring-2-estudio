using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.R20.ReplaceDataValueWithObject.depois
{
    class Exemplo
    {
        void Teste()
        {
            Cliente cliente = new Cliente("José da Silva");
            var pedido = new Pedido(cliente);
            pedido.AddItem("Alphakix", 10, 3);
            pedido.AddItem("Stocklab", 15, 5);
            pedido.AddItem("Statstrong", 6, 2);
        }
    }

    class Pedido
    {
        private readonly Cliente cliente;
        public Cliente Cliente { get; }

        private readonly IList<Item> itens = new List<Item>();
        public IReadOnlyCollection<Item> Itens => new ReadOnlyCollection<Item>(itens);

        public Pedido(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public static int QuantidadeDePedidosDe(IEnumerable<Pedido> pedidos, Cliente cliente)
        {
            return pedidos
                .Count(p =>
                    p.Cliente.Equals(cliente));
        }

        public void AddItem(string produto, decimal precoUnitario, int quantidade)
        {
            itens.Add(new Item(produto, precoUnitario, quantidade));
        }

        public void RemoveItem(string produto)
        {
            var item = itens.Where(i => i.Produto.Equals(produto, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            if (item != null)
            {
                itens.Remove(item);
            }
        }
    }

    class Item
    {
        readonly string produto;
        public string Produto => produto;

        readonly decimal precoUnitario;
        public decimal PrecoUnitario => precoUnitario;

        readonly int quantidade;
        public int Quantidade => quantidade;

        public Item(string produto, decimal precoUnitario, int quantidade)
        {
            this.produto = produto;
            this.precoUnitario = precoUnitario;
            this.quantidade = quantidade;
        }
    }

    class Cliente
    {
        private readonly string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public override bool Equals(object obj)
        {
            return this.nome.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.nome.GetHashCode();
        }
    }
}
