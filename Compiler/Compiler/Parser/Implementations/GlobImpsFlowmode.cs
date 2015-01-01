using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsFLOWMODE : IGlobImps
  {
    public IGlobImp GlobImp { get; set; }
  
    public IRepGlobImps RepGlobImps { get; set; }
  
    public GlobImpsFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
