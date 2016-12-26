﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Pipeline;
using Mediator.Net.Test.Messages;
using NUnit.Framework;
using TestStack.BDDfy;

namespace Mediator.Net.Test
{
    class CommandShouldBeSendToItsHandler
    {
        private IMediator _mediator;
        public void GivenAMediator()
        {
            var builder = new MediatorBuilder();
            builder.RegisterHandlersFor(this.GetType().Assembly);
            IReceivePipe<IMessage, IReceiveContext<IMessage>> receivePipe = new ReceivePipe<IMessage, IReceiveContext<IMessage>>(null);
            _mediator = new Mediator(receivePipe, null);
        }

        public async Task WhenACommandIsSent()
        {
            await _mediator.SendAsync(new TestBaseCommand(Guid.NewGuid()));
        }

        public void ThenItShouldReachTheRightHandler()
        {
            
        }

        [Test]
        public void Run()
        {
            this.BDDfy();
        }
    }
}