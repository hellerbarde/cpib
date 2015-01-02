using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/ChangeModeToken.cs
  public class ChangeModeToken : GenericParamToken<ChangeMode>
  {
    public ChangeModeToken(ChangeMode value) : base(Terminals.CHANGEMODE, value)
=======
    [Serializable]
    public class ChangeModeToken : GenericParamToken<ChangeMode>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/ChangeModeToken.cs
    {
    }
  }
}
