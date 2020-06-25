using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;

namespace Novado.Deadlocking.Buffers
{
    public class InMemoryBuffer : IBuffer
    {
        String[] _instructions;
        int _position = 0;

        public InMemoryBuffer(String[] instructions)
        {
            _instructions = instructions;
        }

        public String GetCurrentInstruction()
        {
            return _instructions[_position];
        }

        public void MoveOn(int shift)
        {
            _position += shift;
        }
    }
}
