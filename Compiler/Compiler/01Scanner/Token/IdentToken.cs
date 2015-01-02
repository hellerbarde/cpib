using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/IdentToken.cs
  /// <summary>
  /// Identifier Token (e.g. Variable names)
  /// </summary>
  public class IdentToken : GenericParamToken<string>
  {
    public IdentToken(string ident) : base(Terminals.IDENT, ident)
=======
    /// <summary>
    /// Identifier Token (e.g. Variable names)
    /// </summary>
    [Serializable]
    public class IdentToken : GenericParamToken<string>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/IdentToken.cs
    {
    }
  }
}
