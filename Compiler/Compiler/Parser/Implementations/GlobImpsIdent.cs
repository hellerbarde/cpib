using System;
using System.Text;

namespace Compiler
{
  public partial class GlobImpsIDENT : IGlobImps
  {
    public IGlobImp globimp { get; set; }
  
    public IRepGlobImps repglobimps { get; set; }
  
    public GlobImpsIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
