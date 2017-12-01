using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace refatoracao.R19.ReplaceDataValueWithObject.antes
{
    class Exemplo
    {
        void Teste()
        {
            var pedido = new Pedido("José da Silva");
            pedido.AddItem("Alphakix", 10, 3);
            pedido.AddItem("Stocklab", 15, 5);
            pedido.AddItem("Statstrong", 6, 2);
        }
    }

    class Pedido
    {
        private readonly string cliente;
        public string Cliente { get; }

        private readonly IList<Item> itens = new List<Item>();
        public IReadOnlyCollection<Item> Itens => new ReadOnlyCollection<Item>(itens);
        
        public Pedido(string cliente)
        {
            this.cliente = cliente;
        }

        public static int QuantidadeDePedidosDe(IEnumerable<Pedido> pedidos, string cliente)
        {
            return pedidos
                .Count(p => 
                    p.Cliente.Equals(cliente, 
                        StringComparison.CurrentCultureIgnoreCase));
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
}
