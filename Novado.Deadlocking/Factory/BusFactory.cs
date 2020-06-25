using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Bus;

namespace Novado.Deadlocking.Factory
{
    class BusFactory
    {
        static public IBus GetInmemoryBus()
        {
            return new InMemoryBus();
        }
        static public IBus GetActiveMqBus()
        {
            return new ActiveMqBus();
        }

        static public IBus GetKafkaBus()
        {
            return new KafkaBus();
        }
    }
}
