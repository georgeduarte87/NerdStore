using System;
using FluentValidation;
using NerdStore.Core.Messages;


namespace NerdStore.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        //public Guid PedidoId { get; private set; }  // CLiente só pode ter um pedido aberto
        public string CodigoVoucher { get; private set; }

        public AplicarVoucherPedidoCommand(Guid clienteId, /*Guid pedidopId, */ string codigoVoucher)
        {
            ClienteId = clienteId;
            //PedidoId = pedidopId;
            CodigoVoucher = codigoVoucher;
        }

        public override bool EhValido()
        {
            ValidationResult = new AplicarVoucherPedidoValidatrion().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AplicarVoucherPedidoValidatrion : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AplicarVoucherPedidoValidatrion()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");
            /*
            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido"); */

            RuleFor(c => c.CodigoVoucher)
                .NotEmpty()
                .WithMessage("O código voucher não pode ser vazio");
        }
    }
}
