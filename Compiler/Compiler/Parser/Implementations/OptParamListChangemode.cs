using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListCHANGEMODE : IOptParamList
  {
    public IParam param { get; set; }
  
    public IRepParamList repparamlist { get; set; }
  
    public OptParamListCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
