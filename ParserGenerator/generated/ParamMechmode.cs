using System;
using System.Text;

namespace Compiler
{
  public class ParamMechmode : Iparam
  {
    public IoptModeFlow optModeFlow { get; set; }
  
    public IoptModeMech optModeMech { get; set; }
  
    public IstoreDecl storeDecl { get; set; }
  
    public IrepParam repParam { get; set; }
  
    public ParamMechmode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
