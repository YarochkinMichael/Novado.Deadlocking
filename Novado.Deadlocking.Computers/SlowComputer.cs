using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Core.Models;

namespace Novado.Deadlocking.Computers
{
    public class SlowComputer : CustomComputer
    {
        public SlowComputer(int id, IBus bus, Register register, IBuffer buffer) : base(id, bus, register, buffer, 1000)
        {
        }
    }
}
