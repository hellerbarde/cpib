using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/FlowModeToken.cs
  public class FlowModeToken : GenericParamToken<FlowMode>
  {
    public FlowModeToken(FlowMode value) : base(Terminals.FLOWMODE, value)
=======
    [Serializable]
    public class FlowModeToken : GenericParamToken<FlowMode>
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/FlowModeToken.cs
    {
    }
  }
}
