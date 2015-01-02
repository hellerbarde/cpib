using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/OperatorToken.cs
  public class OperatorToken : GenericParamToken<Operators>
  {
    public OperatorToken(Terminals terminal, Operators op) : base(terminal, op)
=======
    [Serializable]
    public class OperatorToken : GenericParamToken<Operators>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/OperatorToken.cs
    {
    }
  }
}
