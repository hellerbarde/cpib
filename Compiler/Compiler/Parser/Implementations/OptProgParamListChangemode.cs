using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListCHANGEMODE : IOptProgParamList
  {
    public IProgParam ProgParam { get; set; }
  
    public IRepProgParamList RepProgParamList { get; set; }
  
    public OptProgParamListCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
