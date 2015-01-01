using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListFLOWMODE : IOptParamList
  {
    public IParam Param { get; set; }
  
    public IRepParamList RepParamList { get; set; }
  
    public OptParamListFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
