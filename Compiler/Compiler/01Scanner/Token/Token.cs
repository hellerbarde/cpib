using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
  /// <summary>
  /// Represents a basic Token, which is a single element of the tokenlist (tokenlist=output of the scanner)
  /// </summary>
  public class Token
  {
    /// <summary>
    /// Row the original token was located in
    /// </summary>
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/Token.cs
    public int Row { get; set; }

    /// <summary>
    /// Column the original token was located in (Usually the last column of the token)
    /// </summary>
    public int Column { get; set; }

    public Terminals Terminal { get; private set; }

    public Token(Terminals terminal)
    {
      this.Terminal = terminal;
    }

    public override string ToString()
=======
    [Serializable]
    public class Token
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/Token.cs
    {
      return "[L" + Row + "C" + Column + "]:" + Terminal.ToString();
    }
  }
}
