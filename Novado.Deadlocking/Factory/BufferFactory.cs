using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Buffers;
using System.IO;

namespace Novado.Deadlocking.Factory
{
    class BufferFactory
    {
        static public IBuffer GetInMemoryBuffer(String fileName)
        {
            //need to make sure file in the same folder
            String[] instructions = File.ReadAllLines(fileName + ".txt");

            return new InMemoryBuffer(instructions);
        }
    }
}
