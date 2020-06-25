using Novado.Deadlocking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novado.Deadlocking.Core.Interfaces
{
    public interface IBuffer
    {
        String GetCurrentInstruction();

        void MoveOn(int shift);
    }
}
