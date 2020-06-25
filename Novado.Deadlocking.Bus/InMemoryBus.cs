using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;

namespace Novado.Deadlocking.Bus
{
    public class InMemoryBus : IBus
    {
        public int Receive()
        {
            throw new NotImplementedException();
        }

        public void Send(int value)
        {
            throw new NotImplementedException();
        }
    }
}
