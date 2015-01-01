using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsCHANGEMODE : IGlobImps
  {
    public IGlobImp GlobImp { get; set; }
  
    public IRepGlobImps RepGlobImps { get; set; }
  
    public GlobImpsCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
