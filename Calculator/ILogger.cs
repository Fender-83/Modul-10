using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ILogger
    {
        void Error (string message);
        void Info (string message);
    }
}
