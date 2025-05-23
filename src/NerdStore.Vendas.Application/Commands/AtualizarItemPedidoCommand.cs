﻿using FluentValidation;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AtualizarItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        //public Guid PedidoId { get; private set; }  // Cliente só pode ter um pedido aberto
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public AtualizarItemPedidoCommand(Guid clienteId, /*Guid pedidoId, */ Guid produtoId, int quantidade)
        {
            ClienteId = clienteId;
            //PedidoId = pedidoId; 
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarItemPedidoValidation : AbstractValidator<AtualizarItemPedidoCommand>
    {
        public AtualizarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            /*
            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido"); */

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade mínima de um item é 1");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade máxima de um item é 15");
        }
    }
}
