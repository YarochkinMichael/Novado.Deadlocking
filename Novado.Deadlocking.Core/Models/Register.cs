using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novado.Deadlocking.Core.Models
{

    public class Register
    {
        Hashtable _registers;

        public Register()
        {
            _registers = new Hashtable();
        }

        public void SetRegister(String register, int value)
        {
            _registers.Add(register, value);
        }

        public int GetRegister(String register)
        {
            int t= (int)_registers[register];

            return (int)_registers[register];
        }
    }
}
