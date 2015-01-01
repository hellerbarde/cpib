using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListMECHMODE : IOptParamList
  {
    public IParam param { get; set; }
  
    public IRepParamList repparamlist { get; set; }
  
    public OptParamListMECHMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
