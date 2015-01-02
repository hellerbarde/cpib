using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/TypeToken.cs
  public class TypeToken : GenericParamToken<Type>
  {
    public TypeToken(Type value) : base(Terminals.TYPE, value)
=======
    [Serializable]
    public class TypeToken : GenericParamToken<Type>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/TypeToken.cs
    {
    }
  }
}
