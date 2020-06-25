using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Factory;
using Novado.Deadlocking.Core.Interfaces;


namespace Novado.Deadlocking
{
    class Program
    {
        static void Main(string[] args)
        {
            IBus bus = BusFactory.GetInmemoryBus();

            IBuffer firstComputerBuffer = BufferFactory.GetInMemoryBuffer("deadlocking - input");
            IBuffer secondComputerBuffer = BufferFactory.GetInMemoryBuffer("deadlocking - input");

            IComputer firstComputer = ComputerFactory.GetFastComputer(0, bus, firstComputerBuffer);
            IComputer secondComputer = ComputerFactory.GetSlowComputer(1, bus, secondComputerBuffer);

            firstComputer.StartExecution();
            secondComputer.StartExecution();

            while (true) ;
        }
    }
}
