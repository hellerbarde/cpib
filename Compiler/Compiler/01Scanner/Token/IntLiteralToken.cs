using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/IntLiteralToken.cs
  public class IntLiteralToken : GenericParamToken<int>
  {
    public IntLiteralToken(int value) : base(Terminals.LITERAL, value)
=======
    [Serializable]
    public class IntLiteralToken : GenericParamToken<int>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/IntLiteralToken.cs
    {
    }
  }
}
