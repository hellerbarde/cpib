using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListFLOWMODE : IOptProgParamList
  {
    public IProgParam ProgParam { get; set; }
  
    public IRepProgParamList RepProgParamList { get; set; }
  
    public OptProgParamListFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
