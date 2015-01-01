using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListMECHMODE : IOptParamList
  {
    public IParam Param { get; set; }
  
    public IRepParamList RepParamList { get; set; }
  
    public OptParamListMECHMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
