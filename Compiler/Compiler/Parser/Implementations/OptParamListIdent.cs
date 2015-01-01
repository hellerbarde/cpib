using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListIDENT : IOptParamList
  {
    public IParam Param { get; set; }
  
    public IRepParamList RepParamList { get; set; }
  
    public OptParamListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
