using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Core.Models;

namespace Novado.Deadlocking.Computers
{
    class CPU
    {
        IBus _bus;
        Register _register;

        public CPU(IBus bus, Register register)
        {
            _bus = bus;
            _register = register;
        }

        public int Execute(Instruction instruction)
        {
            if(instruction.type == InstructionType.jgz)
                return ExecuteJgz(instruction.firstParemeter, instruction.secondParemeter);

            switch (instruction.type)
            {
                case InstructionType.set:  ExecuteSet(instruction.firstParemeter, instruction.secondParemeter); break;
                case InstructionType.add: ExecuteAdd(instruction.firstParemeter, instruction.secondParemeter); break;
                case InstructionType.mul: ExecuteMul(instruction.firstParemeter, instruction.secondParemeter); break;
                case InstructionType.mod: ExecuteMod(instruction.firstParemeter, instruction.secondParemeter); break;
                case InstructionType.snd: ExecuteSnd(instruction.firstParemeter); break;
                case InstructionType.rcv: ExecuteRcv(instruction.firstParemeter); break;
            }

            return 1;
        }
        public void ExecuteSet(InstructionParameter register, InstructionParameter value)
        {
            switch (value.type)
            {
                case InstructionParameterType.Value:
                    _register.SetRegister(register.name, value.value);
                    break;
                case InstructionParameterType.Register:
                    _register.SetRegister(register.name, _register.GetRegister(value.name));
                    break;
            }
        }
        public void ExecuteAdd(InstructionParameter register, InstructionParameter addition)
        {
            switch (addition.type)
            {
                case InstructionParameterType.Value:
                    _register.SetRegister(register.name, _register.GetRegister(register.name)+ addition.value);
                    break;
                case InstructionParameterType.Register:
                    _register.SetRegister(register.name, _register.GetRegister(register.name) + _register.GetRegister(addition.name));
                    break;
            }
        }
        public void ExecuteMul(InstructionParameter register, InstructionParameter factor)
        {
            switch (factor.type)
            {
                case InstructionParameterType.Value:
                    _register.SetRegister(register.name, _register.GetRegister(register.name) * factor.value);
                    break;
                case InstructionParameterType.Register:
                    _register.SetRegister(register.name, _register.GetRegister(register.name) * _register.GetRegister(factor.name));
                    break;
            }
        }
        public void ExecuteMod(InstructionParameter register, InstructionParameter basis)
        {
            switch (basis.type)
            {
                case InstructionParameterType.Value:
                    _register.SetRegister(register.name, _register.GetRegister(register.name) % basis.value);
                    break;
                case InstructionParameterType.Register:
                    _register.SetRegister(register.name, _register.GetRegister(register.name) % _register.GetRegister(basis.name));
                    break;
            }
        }
        public int ExecuteJgz(InstructionParameter register, InstructionParameter value)
        {
            if (_register.GetRegister(register.name) > 0)
                return value.value;

            return 1;
        }
        public void ExecuteSnd(InstructionParameter register)
        {
            switch (register.type)
            {
                case InstructionParameterType.Value:
                    _bus.Send(register.value);
                    break;
                case InstructionParameterType.Register:
                    _bus.Send(_register.GetRegister(register.name));
                    break;
            }
        }
        public void ExecuteRcv(InstructionParameter register)
        {
            switch (register.type)
            {
                case InstructionParameterType.Register:
                    _register.SetRegister(register.name, _bus.Receive());
                    break;
            }

        }
    }
}
