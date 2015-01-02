using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/BoolLiteralToken.cs
  public class BoolLiteralToken : GenericParamToken<bool>
  {
    public BoolLiteralToken(bool value) : base(Terminals.LITERAL, value)
=======
    [Serializable]
    public class BoolLiteralToken : GenericParamToken<bool>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/BoolLiteralToken.cs
    {
    }
  }
}
