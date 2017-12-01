using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace refatoracao.R24.ChangeUniToBi.depois
{
    class Program
    {
        void Main()
        {
            var cliente = new Cliente();

            Pedido pedido = cliente.AdicionaPedido();
            cliente.RemovePedido(pedido);

            //acessando pedidos a partir do cliente
            foreach (var p in cliente.Pedidos)
            {
                Console.WriteLine($"Pedido: {pedido}");
            }

            //acessando cliente a partir do pedido (agora é possível!)
            Console.WriteLine($"Cliente: {pedido.Cliente}");
        }
    }

    class Pedido
    {
        private Cliente cliente;
        internal Cliente Cliente => cliente;

        public Pedido(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void RemoveCliente()
        {
            cliente = null;
        }

        //Código do pedido aqui...
    }

    class Cliente
    {
        private IList<Pedido> pedidos = new List<Pedido>();
        public IReadOnlyCollection<Pedido> Pedidos
        {
            get { return new ReadOnlyCollection<Pedido>(pedidos); }
        }

        internal Pedido AdicionaPedido()
        {
            var pedido = new Pedido(this);
            pedidos.Add(pedido);
            return pedido;
        }

        internal void RemovePedido(Pedido pedido)
        {
            pedido.RemoveCliente();
            pedidos.Remove(pedido);
        }

        //Mais código do cliente aqui...
    }
}
