using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsIDENT : IGlobImps
  {
    public IGlobImp GlobImp { get; set; }
  
    public IRepGlobImps RepGlobImps { get; set; }
  
    public GlobImpsIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
