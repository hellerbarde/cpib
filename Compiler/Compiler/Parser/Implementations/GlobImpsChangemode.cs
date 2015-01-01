using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsCHANGEMODE : IGlobImps
  {
    public IGlobImp globimp { get; set; }
  
    public IRepGlobImps repglobimps { get; set; }
  
    public GlobImpsCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
