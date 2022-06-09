using System;
using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItem;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItem;

        // EF Rel
        public  Voucher Voucher { get; private set; }

    }
}
