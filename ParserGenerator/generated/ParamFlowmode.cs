using System;
using System.Text;

namespace Compiler
{
  public class ParamFlowmode : Iparam
  {
    public IoptModeFlow optModeFlow { get; set; }
  
    public IoptModeMech optModeMech { get; set; }
  
    public IstoreDecl storeDecl { get; set; }
  
    public IrepParam repParam { get; set; }
  
    public ParamFlowmode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
