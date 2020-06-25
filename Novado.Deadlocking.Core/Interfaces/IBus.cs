﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novado.Deadlocking.Core.Interfaces
{
    public interface IBus
    {
        void Send(int value);

        int Receive();
    }
}
