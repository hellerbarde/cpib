using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsFLOWMODE : IGlobImps
  {
    public IGlobImp globimp { get; set; }
  
    public IRepGlobImps repglobimps { get; set; }
  
    public GlobImpsFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
