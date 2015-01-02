using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/GenericParamToken.cs
  public abstract class GenericParamToken<E> : Token
  {
    public E Value { get; private set; }

    protected GenericParamToken(Terminals terminal, E value) : base(terminal)
    {
      this.Value = value;
    }

    public override string ToString()
=======
    [Serializable]
    public abstract class GenericParamToken<E> : Token
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/GenericParamToken.cs
    {
      return String.Format("({0}, {1})", base.ToString(), Value.ToString());
    }
  }
}
