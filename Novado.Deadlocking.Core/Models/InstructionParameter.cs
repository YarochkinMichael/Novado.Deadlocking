using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novado.Deadlocking.Core.Models
{
    public enum InstructionParameterType
    {
        None,
        Register,
        Value
    }

    public class InstructionParameter
    {
        public InstructionParameterType type = InstructionParameterType.None;

        public String name;
        public int value;

        public InstructionParameter()
        {
            type = InstructionParameterType.None;
        }

        public InstructionParameter(String parameter)
        {
            try
            {
                value = Int32.Parse(parameter);
                type = InstructionParameterType.Value;
            }
            catch (FormatException)
            {
                name = parameter;
                type = InstructionParameterType.Register;
            }
        }
    }
}
