using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListIDENT : IOptParamList
  {
    public IParam param { get; set; }
  
    public IRepParamList repparamlist { get; set; }
  
    public OptParamListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
