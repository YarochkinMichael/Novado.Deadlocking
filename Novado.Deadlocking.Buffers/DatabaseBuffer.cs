using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;

namespace Novado.Deadlocking.Buffers
{
    class DatabaseBuffer : IBuffer
    {
        public String GetCurrentInstruction()
        {
            throw new NotImplementedException();
        }
        public void MoveOn(int shift)
        {
            throw new NotImplementedException();
        }
    }
}
