using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novado.Deadlocking.Core.Models
{
    public enum InstructionType
    {
        set,
        add,
        mul,
        mod,
        jgz,
        snd,
        rcv
    }

     public class Instruction
    {
        public InstructionType type;
        public InstructionParameter firstParemeter = new InstructionParameter();
        public InstructionParameter secondParemeter = new InstructionParameter();

        public Instruction(String code)
        {
            String[] split = code.Split(' ');

            type = getType(split[0]);

            switch (split.Length)
            {
                case 3: ParseTwoParametersInstruction(split); break;
                case 2: ParseOneParameterInstruction(split); break;
                default: throw new NotSupportedException();
            }
        }

        void ParseTwoParametersInstruction(String[] split)
        {
            switch (type)
            {
                case InstructionType.set:
                case InstructionType.add:
                case InstructionType.mul:
                case InstructionType.mod:
                case InstructionType.jgz:
                    firstParemeter = new InstructionParameter(split[1]);
                    secondParemeter = new InstructionParameter(split[2]);
                    break;

                default: throw new NotSupportedException();
            }
        }

        void ParseOneParameterInstruction(String[] split)
        {
            switch (type)
            {
                case InstructionType.snd:
                case InstructionType.rcv:
                    firstParemeter = new InstructionParameter(split[1]);
                    break;
                default: throw new NotSupportedException();
            }
        }

        InstructionType getType(String name)
        {
            InstructionType type;
            Enum.TryParse(name, out type);

            return type;
        }
    }
}
