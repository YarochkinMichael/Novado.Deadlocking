using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Novado.Deadlocking.Core.Interfaces;
using Novado.Deadlocking.Core.Models;

namespace Novado.Deadlocking.Computers
{
    public class CustomComputer : IComputer
    {
        int _id;
        Timer _executionTimer;
        IBuffer _buffer;

        CPU _cpu;

        public CustomComputer(int id, IBus bus, Register register, IBuffer buffer, int speed)
        {
            _cpu = new CPU(bus, register);

            _id = id;
            _buffer = buffer;

            _executionTimer = new Timer(speed);
            _executionTimer.Elapsed += _executionTimer_Elapsed;
        }

        private void _executionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ExecuteNextInstruction();
        }

        void ExecuteNextInstruction()
        {
            Instruction instruction = new Instruction(_buffer.GetCurrentInstruction());

            _buffer.MoveOn(_cpu.Execute(instruction));
        }

        public void StartExecution()
        {
            _executionTimer.Start();
        }
    }
}
