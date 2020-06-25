using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Core.Models;
using Novado.Deadlocking.Computers;

namespace Novado.Deadlocking.Factory
{
    class ComputerFactory
    {
        static public IComputer GetCustomComputer(int id, IBus bus, IBuffer buffer, int speed)
        {
            return new CustomComputer(id, bus, new Register(), buffer, speed);
        }
        static public IComputer GetFastComputer(int id, IBus bus, IBuffer buffer)
        {
            return new FastComputer(id, bus, new Register(), buffer);
        }
        static public IComputer GetSlowComputer(int id, IBus bus, IBuffer buffer)
        {
            return new SlowComputer(id, bus, new Register(), buffer);
        }
    }
}
