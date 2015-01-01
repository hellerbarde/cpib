using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListFLOWMODE : IOptParamList
  {
    public IParam param { get; set; }
  
    public IRepParamList repparamlist { get; set; }
  
    public OptParamListFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
